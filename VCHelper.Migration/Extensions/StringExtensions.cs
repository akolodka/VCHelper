namespace VCHelper.Migration.Extensions
{
    public static class StringExtensions
    {
        public static string GetValueFromPair(this string @string)
        {
            return @string.Substring(@string.IndexOf("=") + 1);
        }
    }
}
