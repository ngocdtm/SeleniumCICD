namespace Selenium_Learn.Extentions
{
    public static class SeleniumCustomMethods
    {
        //1. method should get the locator
        //2. start getting the type of identifier
        //3. perform operation on the locator

        public static void ClickElement(this IWebElement locator)
        {
            locator.Click();
        }

        public static void SubmitElement(this IWebElement locator)
        {
            locator.Submit();
        }

        public static void EnterText(this IWebElement locator, string text)
        {
            locator.Clear();
            locator.SendKeys(text);
        }

        public static void SelectDropdownByText(this IWebElement locator, string text)
        {
            var selectElement = new SelectElement(locator);
            selectElement.SelectByText(text);
        }

        public static void SelectDropdownByValue(this IWebElement locator, string value)
        {
            var selectElement = new SelectElement(locator);
            selectElement.SelectByValue(value);
        }

        public static void MultiSelectElements(this IWebElement locator, string[] values)
        {
            var multiSelect = new SelectElement(locator);

            foreach (var value in values)
            {
                multiSelect.SelectByValue(value);
            }
        }

        public static List<string> GetAllSelectedList(this IWebElement locator)
        {
            var options = new List<string>();
            var multiSelect = new SelectElement(locator);

            IList<IWebElement> selectdeOption = multiSelect.AllSelectedOptions;

            foreach (IWebElement option in selectdeOption)
            {
                options.Add(option.Text);
            }
            return options;
        }

    }
}
