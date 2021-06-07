using OpenQA.Selenium;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

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

        public static void ClickWithRetry(this IWebElement element)
        {
            int attempts = 0;
            while (attempts < 3)
            {
                try
                {
                    element.Click();
                    break;
                }
                catch (StaleElementReferenceException)
                {
                    Thread.Sleep(attempts * 300);
                }
                catch (ElementClickInterceptedException)
                {
                    Thread.Sleep((attempts + 1) * 300);
                }
                catch (ElementNotInteractableException)
                {
                    Thread.Sleep((attempts + 1) * 300);
                }
                attempts++;
            }
        }


    }
}
