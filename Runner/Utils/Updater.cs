using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Runner.Events;
using Runner.Extensions;
using System;
using System.IO;
using System.Net;
using System.Text;

namespace Runner.Utils
{
    [JsonObject(NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
    internal class Asset
    {
        public string Name { get; set; } = null;
        public string BrowserDownloadUrl { get; set; } = null;
    }

    [JsonObject(NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
    internal class Release
    {
        public string TagName { get; set; } = null;
        public Asset[] Assets { get; set; } = null;
    }

    internal class Updater
    {
        public WebClient Client { get; private set; } = null;

        public readonly string RepositoryUrl = "https://api.github.com/repos/MatrixDJ96/Runner";

        public readonly string UserAgent = "Mozilla/5.0 (X11; Linux x86_64; rv:109.0) Gecko/20100101 Firefox/113.0";

        public event UpdaterCompletedEventHandler DownloadCompleted;

        public event DownloadProgressChangedEventHandler DownloadProgressChanged;

        ~Updater()
        {
            Cancel();
        }

        private void InitializeClient()
        {
            // Clean previous client
            Cancel();

            // Create new client
            Client = new WebClient();

            // Set user agent for the client
            Client.Headers[HttpRequestHeader.UserAgent] = UserAgent;

            Client.DownloadProgressChanged += DownloadProgressChanged;
        }

        private string DownloadString(string url)
        {
            return Encoding.UTF8.GetString(Client.DownloadData(url));
        }

        private void DownloadFileAsync(string url)
        {
            Client.DownloadDataAsync(new Uri(url));
        }

        private void OnDownloadUpdateCompleted(object sender, DownloadDataCompletedEventArgs e, string filename, Version version)
        {
            var dce = new UpdaterCompletedEventArgs() { Error = e.Error };

            if (!e.Cancelled && e.Error == null)
            {
                try
                {
                    // Get header from response
                    var contentDisposition = Client.ResponseHeaders["Content-Disposition"];

                    if (contentDisposition != null)
                    {
                        // Try to parse filename for header
                        var responseFilename = contentDisposition.Substring(
                            contentDisposition.IndexOf("filename=") + "filename=".Length
                        ).Replace("\"", "");

                        if (!responseFilename.IsEmpty())
                        {
                            // Assign new filename (without path)
                            filename = Path.GetFileName(responseFilename);
                        }
                    }

                    // Set destination path
                    var newPath = Path.Combine(
                        Path.GetDirectoryName(Program.ExecutablePath),
                        filename
                   );

                    // Set temp path to write file
                    var tmpPath = Path.GetTempFileName();

                    using (var stream = new FileStream(tmpPath, FileMode.Create, FileAccess.Write))
                    {
                        // Write new file
                        stream.Write(e.Result, 0, e.Result.Length);
                    }

                    // Define old path
                    var oldPath = Program.ExecutablePath + ".old";

                    if (File.Exists(oldPath))
                    {
                        // Remove old file
                        File.Delete(oldPath);
                    }

                    // Backup current file
                    File.Move(Program.ExecutablePath, oldPath);

                    if (File.Exists(newPath))
                    {
                        if (File.Exists(newPath + ".bak"))
                        {
                            // Delete previous backup
                            File.Delete(newPath + ".bak");
                        }

                        // Backup existing new file
                        File.Move(newPath, newPath + ".bak");
                    }

                    // Move new file from tmp
                    File.Move(tmpPath, newPath);

                    // Set path of downloaded file
                    dce.FilePath = newPath;

                    // Set version of download file
                    dce.FileVersion = version;

                    // Set as completed!
                    dce.Success = true;
                }
                catch (Exception ex)
                {
                    // Update new error
                    dce.Error = ex;
                }
            }

            DownloadCompleted?.Invoke(sender, dce);
        }

        public bool Update()
        {
            var result = false;

            try
            {
                // Initialize client
                InitializeClient();

                // Download data from GitHub
                var content = DownloadString(RepositoryUrl + "/releases/latest");

                // Convert received data into object
                var release = JsonConvert.DeserializeObject<Release>(content);

                if (release.TagName != null && release.Assets != null)
                {
                    var lastVersion = new Version(
                        release.TagName.Substring(1)
                    );

                    // Compare current version with git
                    if (lastVersion > Program.ExecutableVersion)
                    {
                        foreach (var asset in release.Assets)
                        {
                            // Check if asset name correspond to executable name (using git version)
                            if (Path.GetFileNameWithoutExtension(asset.Name).StartsWith(Program.ExecutableName))
                            {
                                // Check if asset is and executable
                                if (Path.GetExtension(asset.Name).ToLower() == ".exe")
                                {
                                    // Listen download complete event
                                    Client.DownloadDataCompleted += (s, e) => OnDownloadUpdateCompleted(s, e, asset.Name, lastVersion);

                                    // Start download update
                                    DownloadFileAsync(asset.BrowserDownloadUrl);

                                    // Set as update ok
                                    result = true;

                                    break;
                                }
                            }
                        }
                    }
                    else
                    {
                        // No new version found so trigger download complete
                        DownloadCompleted?.Invoke(this, new UpdaterCompletedEventArgs());

                        // Set as update ok
                        result = true;
                    }
                }
            }
            catch { }

            return result;
        }

        public bool Cancel()
        {
            var result = false;

            if (Client == null || Client.IsBusy)
            {
                // Ask to cancel
                Client?.CancelAsync();
                // Clean object
                Client?.Dispose();

                result = true;
            }

            return result;

        }
    }
}
