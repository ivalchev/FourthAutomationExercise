using OpenQA.Selenium;
using System.Collections.Generic;
using System.Linq;

namespace Framework.Extensions
{
    public static class WebElementExtensions
    {
        /// <summary>
        /// Get element from collection with text
        /// </summary>
        /// <param name="collection"></param>
        /// <param name="text"></param>
        /// <returns></returns>
        public static IWebElement GetElementFromCollection(this IEnumerable<IWebElement> collection, string text)
        {
            var element = collection.Where(c => c.GetAttribute("textContent").Equals(text)).FirstOrDefault();

            return element;
        }

        /// <summary>
        /// Get element from collection with index
        /// </summary>
        /// <param name="collection"></param>
        /// <param name="text"></param>
        /// <returns></returns>
        public static IWebElement GetElementFromCollection(this IEnumerable<IWebElement> collection, int index)
        {
            var element = collection.ElementAt(index);

            return element;
        }
    }
}
