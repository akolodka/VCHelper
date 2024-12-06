namespace VCHelper.Migration.Extensions
{
    public static class StringExtensions
    {
        public static string GetValueFromKeyValuePairLine(this string @string)
        {
            return @string.Substring(@string.IndexOf("=") + 1);
        }
    }
}
