using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BDR.Sample.Selenium.Helper
{
    public class SeleniumAddOns
    {
        public RemoteWebDriver webDriver;
        private readonly IJavaScriptExecutor driverJavaScriptExecutor;

        public SeleniumAddOns(RemoteWebDriver driver)
        {
            webDriver = driver;
            this.driverJavaScriptExecutor = driver as IJavaScriptExecutor;
        }

        #region Click

        public void Click(IWebElement element)
        {

            try
            {
                element.Click();
            }
            catch (Exception excp1)
            {
                Console.WriteLine(excp1.Message + " Now try ScrollAndClick");
                try
                {
                    ScrollAndClick(element);
                }
                catch (Exception excp2)
                {
                    Console.WriteLine(excp2.Message + " Now try WaitAndClick");

                }
            }
        }

        public void Click(By selector)
        {
            this.webDriver.FindElement(selector);
        }

        public void ScrollAndClick(IWebElement el)
        {
            this.driverJavaScriptExecutor.ExecuteScript("arguments[0].scrollIntoView(true);", el);
            this.driverJavaScriptExecutor.ExecuteScript("arguments[0].click();", el);
        }
        #endregion

        #region SendKeys
        public void SendKeys(IWebElement element, string value)
        {
            element.Clear();
            element.SendKeys(value);
        }

        public void SendKeys(By selector, string value)
        {
            var element = this.webDriver.FindElement(selector);
            element.Clear();
            element.SendKeys(value);
        }
        #endregion

        #region Wait Time
        // Waits before clicking an element.
        public void WaitAndClick(IWebElement el)
        {
            try
            {
                WebDriverWait wait = new WebDriverWait(this.webDriver, TimeSpan.FromSeconds(3));
                //this.ScrollToElement(el);
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(el)).Click();
            }
#pragma warning disable CS0168 // The variable 'wde' is declared but never used
            catch (WebDriverException wde)
#pragma warning restore CS0168 // The variable 'wde' is declared but never used
            {
                WebDriverWait wait = new WebDriverWait(this.webDriver, TimeSpan.FromSeconds(3));
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.InvisibilityOfElementLocated(By.ClassName("loader")));
                //this.ScrollToElement(el);
                el.Click();
            }
        }
        public void WaitImplicitly(int timeInSecs)
        {
            this.webDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(timeInSecs);
        }

        public void WaitUntilElementIsVisible(IWebElement element, int timeInSecs)
        {
            WebDriverWait wait = new WebDriverWait(this.webDriver, TimeSpan.FromSeconds(timeInSecs));
            wait.Until(webDriver => element.Displayed);
        }

        public void WaitUntilElementIsVisible(By by, int timeInSecs)
        {
            WebDriverWait wait = new WebDriverWait(this.webDriver, TimeSpan.FromSeconds(timeInSecs));
            wait.Until(webDriver => webDriver.FindElement(by).Displayed);
        }
        public IWebElement FindListElementIfExists(By by)
        {
            var elements = webDriver.FindElements(by);
            return (elements.Count >= 1) ? elements.First() : null;
        }

        public IWebElement WaitUntilCollectonOfElementsExist(int duration, ReadOnlyCollection<IWebElement> element)
        {
            WebDriverWait wait = new WebDriverWait(webDriver, TimeSpan.FromSeconds(duration));
            var myDynamicElement = wait.Until(d => element.FirstOrDefault(x => x.Displayed));
            return myDynamicElement;
        }
        #endregion

        #region Common helper

        public IWebElement FindFirstOrDefaultByTextValue(ReadOnlyCollection<IWebElement> elements, string value)
        {
            //TODO: remove this -
            Thread.Sleep(5000);
            var element = elements.FirstOrDefault(item => item.Text.Equals(value));
            return element;
        }

        #endregion

        #region DropDown
        public void SelectFromDropdownByText(IWebElement element, string value)
        {
            SelectElement select = new SelectElement(element);
            select.SelectByText(value);
        }

        public void SelectFromDropdownByValue(IWebElement element, string value)
        {
            SelectElement select = new SelectElement(element);
            select.SelectByValue(value);
        }

        // Gets the text of selected dropdown (list) option.
        public string SelectFromDropdownBySelectedText(By dropDownElement)
        {
            SelectElement dropDown = new SelectElement(webDriver.FindElement(dropDownElement));
            return dropDown.SelectedOption.Text;
        }

        public string SelectFromDropdownBySelectedText(IWebElement dropDownElement)
        {
            SelectElement dropDown = new SelectElement(dropDownElement);
            return dropDown.SelectedOption.Text;
        }



        #endregion

        #region CSS Verification methods
        public bool VerifyIsElementDisplayed(IWebElement element)
        {
            //WaitUntilVisible(element, 5);
            //return element.Displayed;

            //if (element != null)
            //{
            //    var elementVisibility = element.Displayed && element.Enabled;
            //    if (elementVisibility == false)
            //    {
            //        throw new Exception("Element is not visible");
            //    }
            //    return true;
            //}

            //throw new Exception("Element is not available");
            try
            {
                return element.Displayed;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public bool VerifyIsElementDisplayed(By element)
        {
            try
            {
                return webDriver.FindElement(element).Displayed;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public string GetInputTypeValue(By element, string attribute)
        {
            var elementState = webDriver.FindElement(element).GetAttribute(attribute);
            return elementState;
        }

        public string GetInputTypeValue(IWebElement element, string attribute)
        {
            var elementState = element.GetAttribute(attribute);
            return elementState;
        }
        public IWebElement VerifyIfElementExists(By by)
        {
            var elements = webDriver.FindElements(by);
            return (elements.Count >= 1) ? elements.First() : null;
        }

        //// ..
        //public string GetInputTypeValue(IWebElement element)
        //{
        //    this.WaitUntilVisible(element, 10);
        //    var elementState = element.GetAttribute("type");
        //    return elementState;
        //}

        // Return css background-color
        public string VerifyBackgroundColor(IWebElement element)
        {
            this.WaitUntilElementIsVisible(element, 10);
            var actualValue = element.GetCssValue("background-color");
            return element.GetCssValue("background-color");
        }

        // Return css border-bottom-color
        public string VerifyBorderBottomColor(IWebElement element)
        {
            this.WaitUntilElementIsVisible(element, 10);
            var actualValue = element.GetCssValue("border-bottom-color");
            return element.GetCssValue("border-bottom-color");
        }

        // Return css border-left-color
        public string VerifyBorderLeftColor(IWebElement element)
        {
            this.WaitUntilElementIsVisible(element, 10);
            var actualValue = element.GetCssValue("border-left-color");
            return element.GetCssValue("border-left-color");
        }

        // Return css border-left-color
        public string VerifyBorderRightColor(IWebElement element)
        {
            this.WaitUntilElementIsVisible(element, 10);
            var actualValue = element.GetCssValue("border-right-color");
            return element.GetCssValue("border-right-color");
        }

        // Return css border-top-color
        public string VerifyBorderTopColor(IWebElement element)
        {
            this.WaitUntilElementIsVisible(element, 10);
            var actualValue = element.GetCssValue("border-top-color");
            return element.GetCssValue("border-top-color");
        }

        // Return css font-family
        public string VerifyFontFamily(IWebElement element)
        {
            this.WaitUntilElementIsVisible(element, 10);
            var actualValue = element.GetCssValue("font-family");
            return element.GetCssValue("font-family");
        }

        // Return css font-weight
        public string VerifyFontWeight(IWebElement element)
        {
            this.WaitUntilElementIsVisible(element, 10);
            var actualValue = element.GetCssValue("font-weight");
            return element.GetCssValue("font-weight");
        }

        // Return css font-color
        public string VerifyFontColor(IWebElement element)
        {
            this.WaitUntilElementIsVisible(element, 10);
            var actualValue = element.GetCssValue("color");
            return element.GetCssValue("color");
        }

        // Return css font-size
        public string VerifyFontSize(IWebElement element)
        {
            this.WaitUntilElementIsVisible(element, 10);
            var actualValue = element.GetCssValue("font-size");
            return element.GetCssValue("font-size");
        }

        // Return css text-decoration-color
        public string VerifyFontTextDecorationColor(IWebElement element)
        {
            this.WaitUntilElementIsVisible(element, 10);
            var actualValue = element.GetCssValue("text-decoration-color");
            return element.GetCssValue("text-decoration-color");
        }

        // Return css text-decoration-line
        public string VerifyFontTextDecorationLine(IWebElement element)
        {
            this.WaitUntilElementIsVisible(element, 10);
            var actualValue = element.GetCssValue("text-decoration-line");
            return element.GetCssValue("text-decoration-line");
        }

        // Return css line-height
        public string VerifyLineHight(IWebElement element)
        {
            this.WaitUntilElementIsVisible(element, 10);
            var actualValue = element.GetCssValue("line-height");
            return element.GetCssValue("line-height");
        }

        // Return css padding
        public string VerifyPadding(IWebElement element)
        {
            this.WaitUntilElementIsVisible(element, 10);
            var actualValue = element.GetCssValue("padding");
            return element.GetCssValue("padding");
        }

        // Return css border
        public string VerifyBorder(IWebElement element)
        {
            this.WaitUntilElementIsVisible(element, 10);
            var actualValue = element.GetCssValue("border");
            return element.GetCssValue("border");
        }

        // Return css box-sizing
        public string VerifyBoxSizing(IWebElement element)
        {
            this.WaitUntilElementIsVisible(element, 10);
            var actualValue = element.GetCssValue("box-sizing");
            return element.GetCssValue("box-sizing");
        }

        // Return css margin
        public string VerifyMargin(IWebElement element)
        {
            this.WaitUntilElementIsVisible(element, 10);
            var actualValue = element.GetCssValue("margin");
            return element.GetCssValue("margin");
        }

        // Return css margin left
        public string VerifyMarginLeft(IWebElement element)
        {
            this.WaitUntilElementIsVisible(element, 10);
            var actualValue = element.GetCssValue("margin-left");
            return element.GetCssValue("margin-left");
        }
        // Return css margine right
        public string VerifyMarginRight(IWebElement element)
        {
            this.WaitUntilElementIsVisible(element, 10);
            var actualValue = element.GetCssValue("margin-right");
            return element.GetCssValue("margin-right");
        }

        // Return css float value
        public string VerifyFloat(IWebElement element)
        {
            this.WaitUntilElementIsVisible(element, 10);
            var actualValue = element.GetCssValue("float");
            return element.GetCssValue("float");
        }

        // Return css height
        public string VerifyHeight(IWebElement element)
        {
            this.WaitUntilElementIsVisible(element, 10);
            var actualValue = element.GetCssValue("height");
            return element.GetCssValue("height");
        }

        // Return css min width
        public string VerifyMinWidth(IWebElement element)
        {
            this.WaitUntilElementIsVisible(element, 10);
            var actualValue = element.GetCssValue("min-width");
            return element.GetCssValue("min-width");
        }

        // Return css size
        public Size VerifyImageSize(IWebElement element)
        {
            this.WaitUntilElementIsVisible(element, 10);
            return element.Size;
        }

        // Return css height
        public string VerifyCursor(IWebElement element)
        {
            this.WaitUntilElementIsVisible(element, 10);
            var actualValue = element.GetCssValue("cursor");
            return element.GetCssValue("cursor");
        }

        // Waits for element to be there. Max duration seconds.
        //WaitUntilElementExistsCollection
        public void WaitUntilElementExistsCollection(int duration, ReadOnlyCollection<IWebElement> element)
        {
            WebDriverWait webDelay = new WebDriverWait(webDriver, TimeSpan.FromSeconds(duration));
            var xxx = webDelay.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(element));
            //var outboundFlightsListButton = outboundAvailableFlightsList.Where(element => element.Displayed.Equals(true)).Take(numberOfFlight);
        }

        public bool VerifyIfElementIsClickable(IWebElement el)
        {
            try
            {
                WebDriverWait wait = new WebDriverWait(this.webDriver, TimeSpan.FromSeconds(3));
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(el));
                return true;
            }
#pragma warning disable CS0168 // The variable 'e' is declared but never used
            catch (Exception e)
#pragma warning restore CS0168 // The variable 'e' is declared but never used
            {
                return false;
            }
        }
        #endregion

        #region IFrame // Accept // window // Switch To
        public void SwitchToIframe(By iFrameElement)
        {
            //WaitUntilElementVisible(10, iFrameElement);
            webDriver.SwitchTo().Frame(webDriver.FindElement(iFrameElement));
        }
        public void SwitchToIframe(IWebElement iFrameElement)
        {
            //WaitForElement(10, iFrameElement);
            this.WaitUntilElementIsVisible(iFrameElement, 10);
            webDriver.SwitchTo().Frame(iFrameElement);
        }
        public void SwitchToDefaultContent()
        {
            webDriver.SwitchTo().DefaultContent();
        }

        public void SwitchToParentFrame()
        {
            webDriver.SwitchTo().ParentFrame();
        }

        public void SwitchToNewWindow()
        {
            webDriver.SwitchTo().Window(webDriver.WindowHandles.Last());
        }
        public void SwitchBackToYourFirstWindow()
        {
            webDriver.SwitchTo().Window(webDriver.WindowHandles.First());
        }

        public void AcceptAlert()
        {
            // this.WaitForAlertExists(20);
            try
            {
                this.webDriver.SwitchTo().Alert().Accept();
            }
            catch
            {

                throw new Exception("No Alert available");
            }
        }
        #endregion  

        //Get Element text
        public string GetElementText(IWebElement element)
        {
            WaitUntilElementIsVisible(element, 10);
            var text = element.Text;
            return text;

        }
        #region Move to an Element Commands
        // Action move.
        public void MoveToElement(IWebElement element)
        {
            var action = new Actions(webDriver);
            action.MoveToElement(element).Perform();
        }
        // Action move & click.
        public void MoveToElementAndClick(IWebElement element)
        {
            //this.WaitForElement(10, element);
            Actions action = new Actions(webDriver);
            action.MoveToElement(element).Click().Perform();
        }
        #endregion

        #region Get Element/Value
        // Given an element, the text (if any) is returned.
        // If element is not found or when any other exception occurs, empty string is returned.
        public string GetTextFromElement(IWebElement element)
        {
            var text = "";
            try
            {
                if ((text = element.Text.Trim()) == "")
                    if ((text = element.GetAttribute("value").Trim()) == "")
                        if ((text = element.GetAttribute("placeholder").Trim()) == "")
                            text = element.GetAttribute("innerHTML").Trim();
            }
            catch (Exception) { }
            return text;
        }
        // Gets parent element from given element.
        public IWebElement GetParentElement(By element)
        {
            return webDriver.FindElement(element).FindElement(By.XPath(".."));
        }

        // Gets selected (list) option.
        public IWebElement GetSelectedOption(IWebElement optionGroup, By childElement, string selectedOption)
        {
            var parentElement = optionGroup.FindElement(By.XPath(".."));
            return parentElement == null ? null : parentElement.FindElements(childElement).FirstOrDefault(selected => selected.Text.Contains(selectedOption));
        }

        // ..
        public string GetInputTypeValue(By element)
        {
            WaitUntilElementIsVisible(element, 5);
            var elementState = webDriver.FindElement(element).GetAttribute("type");
            return elementState;
        }
        // ..
        public string GetInputTypeValue(IWebElement element)
        {
            WaitUntilElementIsVisible(element, 5);
            var elementState = element.GetAttribute("type");
            return elementState;
        }
        // ..
        public string GetObjectText(By element, string text)
        {
            WaitUntilElementIsVisible(element, 5);
            var textValue = webDriver.FindElement(element).Text;
            return textValue;
        }

        // ..
        public string GetObjectText(IWebElement element, string text)
        {
            WaitUntilElementIsVisible(element, 5);
            var textValue = element.Text;
            return textValue;
        }

        public string GetObjectText(IWebElement element)
        {
            WaitUntilElementIsVisible(element, 5);
            var textValue = element.Text;
            return textValue;
        }
        // ..
        public int GetElementCount(By element)
        {
            WaitUntilElementIsVisible(element, 5);
            var actualCount = webDriver.FindElements(element).Count();
            return actualCount;
        }

        public int GetElementCount(ReadOnlyCollection<IWebElement> elements)
        {
            WaitUntilElementExistsCollection(10, elements);
            var actualCount = elements.Count;
            return actualCount;
        }

        public IWebElement GetElementByIndex(By selector, int index)
        {
            var element = webDriver.FindElements(selector);
            return element[index];
        }

        public IWebElement GetElementByIndex(ReadOnlyCollection<IWebElement> element, int index)
        {
            // WaitUntilElementExistsCollection(20, element);
            return element[index];
        }

        public string GetWindowUrl()
        {
            return webDriver.Url;
        }
        #endregion

        #region Scroll Commands
        // Scrolls to a given element, with JS injection.
        public void ScrollToElement(IWebElement el)
        {
            this.driverJavaScriptExecutor.ExecuteScript("arguments[0].scrollIntoView(true);", el);
        }

        // Scrolls page to top left corner.
        public void ScrollToTopLeft()
        {
            this.driverJavaScriptExecutor.ExecuteScript("window.scrollTo(0,0)");
        }
        // Scrolls page to bottom.
        public void ScrollToBottom()
        {
            this.driverJavaScriptExecutor.ExecuteScript("window.scrollTo(0,document.body.scrollHeight)");
        }
        // Scrolls page to right most corner.
        public void ScrollToRightMost()
        {
            this.driverJavaScriptExecutor.ExecuteScript("window.scrollTo(0,document.body.scrollWidth)");
        }

        // Scrolls from given element to bottom.
        public void ScrollToBottomFromAnElement(IWebElement element)
        {
            this.driverJavaScriptExecutor.ExecuteScript("arguments[0].scrollIntoView();", element);
        }
        // Scrolls to an element after having waited for it.
        public void ScrollToAnElement(IWebElement element)
        {
            WaitUntilElementIsVisible(element, 5);
            ((IJavaScriptExecutor)webDriver).ExecuteScript("arguments[0].scrollIntoView(true);", element);
        }
        #endregion
    }
}
