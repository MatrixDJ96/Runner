using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using System.Web.Script.Serialization;

namespace Runner
{
    internal class Updater
    {
        public WebClient Client { get; private set; } = null;

        public JavaScriptSerializer Serializer { get; private set; } = new JavaScriptSerializer();

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

        private string GetDownloadUrl(object rawAssets, out string filename)
        {
            filename = null;

            try
            {
                // Try to decode assets list with correct type
                if (rawAssets is ArrayList list && list[0] is Dictionary<string, object> assets)
                {
                    // Try to decode asset name
                    if (assets.TryGetValue("name", out var rawName) && rawName is string name)
                    {
                        // Check if asset name correspond to executable name (using git version)
                        if (Path.GetFileNameWithoutExtension(name).StartsWith(Program.ExecutableName))
                        {
                            // Check if asset is and executable
                            if (Path.GetExtension(name).ToLower() == ".exe")
                            {
                                // Try to decode asset download url
                                if (assets.TryGetValue("browser_download_url", out var rawDownloadUrl))
                                {
                                    // Set filename
                                    filename = name;
                                    // Return download url
                                    return rawDownloadUrl as string;
                                }
                            }
                        }
                    }
                }
            }
            catch { }

            return null;
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

                    using (var stream = new FileStream(newPath, FileMode.Create, FileAccess.Write))
                    {
                        // Write new file
                        stream.Write(e.Result, 0, e.Result.Length);
                    }

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

                // Convert received data
                var json = Serializer.Deserialize<Dictionary<string, object>>(content);

                json.TryGetValue("tag_name", out var rawTagName);
                json.TryGetValue("assets", out var rawAssets);

                if (rawTagName != null && rawAssets != null)
                {
                    var lastVersion = new Version(
                        rawTagName.ToString().Substring(1)
                    );

                    // Compare current version with git
                    if (lastVersion > Program.ExecutableVersion)
                    {
                        // Try to parse download url and filename
                        var downloadUrl = GetDownloadUrl(rawAssets, out var filename);

                        if (downloadUrl != null)
                        {
                            // Listen download complete event
                            Client.DownloadDataCompleted += (s, e) => OnDownloadUpdateCompleted(s, e, filename, lastVersion);

                            // Start download update
                            DownloadFileAsync(downloadUrl);

                            // Set as update ok
                            result = true;
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
