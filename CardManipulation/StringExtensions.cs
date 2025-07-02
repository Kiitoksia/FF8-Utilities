namespace CardManipulation
{
    public static class StringExtensions
    {
        public static string Capitalize(this string s)
        {
            return s.Substring(0, 1).ToUpper() + s.Substring(1);
        }
    }
}
