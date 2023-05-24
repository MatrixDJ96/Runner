namespace Runner
{
    internal static class StringExtensions
    {
        public static bool IsEmpty(this string str)
        {
            return string.IsNullOrWhiteSpace(str);
        }
    }
}
