namespace Framework.Extensions
{
    public static class StringExtensions
    {
        /// <summary>
        /// Get substring from text with start index and lenght of the substring
        /// </summary>
        /// <param name="text"></param>
        /// <param name="startIndex"></param>
        /// <param name="lenght"></param>
        /// <returns></returns>
        public static string GetSubStringFromString(this string text, int startIndex, int lenght)
        {
            var subString = text.Substring(startIndex, lenght);

            return subString;
        }
    }
}
