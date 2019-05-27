using BDR.Sample.Selenium.Helper;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BDR.Sample.Selenium.PageObjects
{
    public class InstallerRegistrationPageObjects
    {
        private RemoteWebDriver webDriver;
        private SeleniumAddOns seleniumAddOns;

        public InstallerRegistrationPageObjects(RemoteWebDriver driver)
        {
            this.webDriver = driver;
            this.seleniumAddOns = new SeleniumAddOns(driver);
        }

        #region IWebElements / Selectors

        #region AddingOfProducts
        private IWebElement SelectSingleAddress => webDriver.FindElementByCssSelector("label[for='single-upload']");
        private IWebElement SelectStart => webDriver.FindElementByCssSelector("div[class='proceed-selection '] a[class='button arrow-right']");
        private IWebElement SelectAddInBulk => webDriver.FindElementByCssSelector("label[for='bulk-upload']");
        private IWebElement ProductSerialNumber => webDriver.FindElementByCssSelector("div[class='row serial-input'] input");
        ReadOnlyCollection<IWebElement> ProductAddedList => webDriver.FindElementsByCssSelector("div[class*='product-list--added']");
        ReadOnlyCollection<IWebElement> SelectedRegularProductList => webDriver.FindElementsByCssSelector("div[class='installer--dropdown-options'] li span");
        private IWebElement ProductLoytalPoints => webDriver.FindElementByCssSelector("p[class*='product-list--points ']");
        ReadOnlyCollection<IWebElement> ProductLoytalPointsList => webDriver.FindElementsByCssSelector("p[class*='product-list--points ']");
        private IWebElement ProductErrorMessageText => webDriver.FindElementByCssSelector("div[class='product-reg-message-text'] p");
        private IWebElement ProductFoundLabel => webDriver.FindElementByCssSelector("label[class='result-title']");
        private IWebElement ProductCombiOverviewImage => webDriver.FindElementByCssSelector("div[class='product-list--overview product-list--combi'] div[class='product-list--img']");
        private IWebElement ProductCombiOverviewTitle => webDriver.FindElementByCssSelector("div[class='product-list--overview product-list--combi'] div[class='product-list--desc'] p");
        private IWebElement SecondaryProduct => webDriver.FindElementByCssSelector("div[class='product-list--added product-list--combi']");
        private IWebElement ProductAddedCombiOverviewImage => webDriver.FindElementByCssSelector("div[class='product-list--added product-list--combi']  div[class='product-list--img']");
        private IWebElement ProductAddedCombiOverviewTitle => webDriver.FindElementByCssSelector("div[class='product-list--added product-list--combi']  div[class='product-list--desc'] p");
        private ReadOnlyCollection<IWebElement> ProductCombiOverviewList => webDriver.FindElementsByCssSelector("div[class*='product-list--overview']");
        private IWebElement AddedProductsLabel => webDriver.FindElementByCssSelector("label[class='list-title']");
        private IWebElement ProductAddedImage => webDriver.FindElementByCssSelector("div[class='product-list--img'] img");
        private IWebElement ProductUnknownImage => webDriver.FindElementByCssSelector("div[class='product-reg--img'] img");
        private IWebElement ProductAddedTitle => webDriver.FindElementByCssSelector("p[class='product-list--title']");
        private IWebElement ProductAddedSerialNumber => webDriver.FindElementByCssSelector("p[class='product-list--serial']");
        private IWebElement ProductAddedLink => webDriver.FindElementByClassName("product-list--add");
        private IWebElement ProductRegularAddLink => webDriver.FindElementByCssSelector("div[class='product-reg--add'] a");
        private IWebElement ProductRemoveLink => webDriver.FindElementByClassName("product-list--remove");
        ReadOnlyCollection<IWebElement> ProductRemoveLinkList => webDriver.FindElementsByClassName("product-list--remove");
        private IWebElement ProductAdddedLoytalPoints => webDriver.FindElementByClassName("product-list--points ");
        private IWebElement NotFoundProductSerialNumberText => webDriver.FindElementByCssSelector("p[class='product-reg--serial']");
        private IWebElement ProductAdddedClosebutton => webDriver.FindElementByClassName("close-button");
        private By ProductAdddedClosebuttonSelector = By.CssSelector("i[class='close-button']");
        private IWebElement UnRecognizedSerialNumberErrorMessage => webDriver.FindElementByCssSelector("div[class='product-reg-message-text shake'] p");
        private IWebElement ReTypeProductSerialNumberInput => webDriver.FindElementByCssSelector("div[class='product-reg--detailes-retype-serial'] input");
        private IWebElement ProductResultPopup => webDriver.FindElementByCssSelector("div[class='product-list--result']");
        private IWebElement CloseLink => webDriver.FindElementByCssSelector("a[class='text-link']");
        private IWebElement SelectTheProductText => webDriver.FindElementByCssSelector("span[class='installer--dropdown-selected']");
        private IWebElement ArrangeAndFinalizeOGPButton => webDriver.FindElementByCssSelector("div[class='form-group service-buttons'] a[id='project_select']");
        private IWebElement InstallerDropdownSelected => webDriver.FindElementByCssSelector("span[class='installer--dropdown-selected']");
        ReadOnlyCollection<IWebElement> InstallerDropdownSelectedList => webDriver.FindElementsByCssSelector("div[class='installer--dropdown-wrapper ']");
        private By InstallerDropdownSelectedSelector = By.CssSelector("span[class='installer--dropdown-selected']");
        private IWebElement SelectOGP => webDriver.FindElementByCssSelector("select[class='ogp']");
        ReadOnlyCollection<IWebElement> InstallerDropdownOptionList => webDriver.FindElementsByCssSelector("div[class*='installer--dropdown-options'] ul li");
        private By InstallerDropdownOptionListSelector = By.CssSelector("div[class*='installer--dropdown-options'] ul li");
        ReadOnlyCollection<IWebElement> MultipleInstallerDropdownOptionList => webDriver.FindElementsByCssSelector("div[class*='installer--dropdown-options']");
        private IWebElement ArrangeYourPartsWarrantyPlanImmediatelyHeaderText => webDriver.FindElementByCssSelector("div[class='form--single-upload '] div[class='contextual-title-bold'] span");
        private IWebElement OgpSectionProductAddedTitle => webDriver.FindElementByCssSelector("div[class='form--single-upload '] p[class='product-list--title']");
        private IWebElement OgpSectionProductAddedImage => webDriver.FindElementByCssSelector("div[class='form--single-upload '] div[class='product-list--img'] img");
        private IWebElement OgpSectionProductAddedLoytalPoints => webDriver.FindElementByCssSelector("div[class='form--single-upload '] p[class='product-list--points']");
        private By OgpSectionProductAddedLoytalPointsSelector = By.CssSelector("div[class='form--single-upload '] p[class='product-list--points']");
        private IWebElement OgpSectionProductSerialNumberText => webDriver.FindElementByCssSelector("div[class='form--single-upload '] p[class='product-list--serial']");
        private IWebElement OgpSectionPartsWarrantyPlanLabelText => webDriver.FindElementByCssSelector("div[class='product-list--ogp'] label span");
        private IWebElement CompleteRegistration => webDriver.FindElementById("project_register_afronden");
        private IWebElement SuccessRegistrationImage => webDriver.FindElementByCssSelector("img[src='../images/icons/icons-success.svg']");
        private IWebElement OgpBackButton => webDriver.FindElementByCssSelector("a[class='button back']");
        private IWebElement SuccessRegistrationMessage => webDriver.FindElementByClassName("thank-you--content");
        #endregion

        #region HeaderAndFooter
        private IWebElement MainHeader => webDriver.FindElementByCssSelector("header[class='mainHeader ']");
        private IWebElement BackLink => webDriver.FindElementByCssSelector("a[class='back-link']");
        private IWebElement ProfileMessagesLink => webDriver.FindElementByCssSelector("a[class='profile-links']");
        private IWebElement ProfileNameLink => webDriver.FindElementByCssSelector("a[class='profile-links-no-border']");
        private IWebElement RemehaLogo => webDriver.FindElementByCssSelector("figure[class*='logo-container'] img[src*='logo-black.svg']");
        private IWebElement ProductRegistrationMenu => webDriver.FindElementByCssSelector("a[data-subnav='Productregistratie']");
        ReadOnlyCollection<IWebElement> MenuList => webDriver.FindElementsByCssSelector("div[class='nav__mainNav'] a");
        private IWebElement OgpMenu => webDriver.FindElementByCssSelector("a[data-subnav='Utiliteits-producten']");
        ReadOnlyCollection<IWebElement> SubMenusList => webDriver.FindElementsByCssSelector("a[class='with-sub-menu']");
        private IWebElement ShopMenuLink => webDriver.FindElementByCssSelector("a[class='nav_ShopLink']");
        private IWebElement ShoppingCartIcon => webDriver.FindElementByCssSelector("a[class='icon-cart'] i");
        private By ShoppingCartIconSelector = By.CssSelector("a[class='icon-cart'] i");
        private IWebElement ShoppingCartPoints => webDriver.FindElementByCssSelector("a[class='account-points'] span");
        private IWebElement AccountPoints => webDriver.FindElementByCssSelector("a[class='account-points']");
        private IWebElement Footer => webDriver.FindElementByCssSelector("footer[class='footer']");
        private IWebElement RemehaLogoWhite => webDriver.FindElementByCssSelector("div[class*='footer'] img[src*='white']");
        ReadOnlyCollection<IWebElement> FooterLinksList => webDriver.FindElementsByCssSelector("ul[class='footer__link-list'] li");
        private IWebElement TradeMark => webDriver.FindElementByCssSelector("div[class='footer__trademark-text'] p");
        #endregion

        #region Instillation Date
        private IWebElement IntallationDateMonthPicker => webDriver.FindElementByCssSelector("span[class='rdrMonthPicker'] select");
        private IWebElement IntallationDateYearPicker => webDriver.FindElementByCssSelector("span[class='rdrYearPicker'] select");
        ReadOnlyCollection<IWebElement> IntallationDateDayPickerList => webDriver.FindElementsByCssSelector("button[class*='rdrDay']:not([class*='rdrDayPassive'])");
        private IWebElement DatePickerWrapper => webDriver.FindElementByCssSelector("label[class='datepicker-wrapper ']");
        #endregion

        #region Project Switch
        private IWebElement ProjectSwitchInput => webDriver.FindElementByCssSelector("label[for='project_switch']");
        private IWebElement ProjectSwitchWhatDoesThisMeanLink => webDriver.FindElementByXPath("//label[@for='project_switch']//following-sibling::*");
        private IWebElement ProjectIdInput => webDriver.FindElementById("project-selector");
        private By ProjectIdInputSelector = By.Id("project-selector");
        private IWebElement ProjectIdSuccessMessage => webDriver.FindElementByCssSelector("span[class='project input-validation has-success']");
        private IWebElement ProjectIdErrorMessage => webDriver.FindElementByCssSelector("span[class='project input-validation has-error']");
        private IWebElement SelectProjectButton => webDriver.FindElementByCssSelector("a[id*='project_select']:not([class*='button secondary hide'])");
        private By SelectProjectButtonSelector = By.CssSelector("a[id*='project_select']:not([class*='button secondary hide'])");
        ReadOnlyCollection<IWebElement> SelectProjectLinks => webDriver.FindElementsById("project-selector");
        #endregion

        #region Address
        private IWebElement PostCodeInput => webDriver.FindElementById("post-code");
        private IWebElement HouseNumberInput => webDriver.FindElementById("house-number");
        private IWebElement AddressSuccessMessage => webDriver.FindElementByCssSelector("span[class='input-validation has-success']");
        private IWebElement AddressErrorMessage => webDriver.FindElementByCssSelector("span[class='input-validation has-error']");
        #endregion

        #region CustomerData
        private IWebElement CustomerDataHeaderTitle => webDriver.FindElementByCssSelector(".customer-data div[class='contextual-title-bold'] label");
        private IWebElement CustomerDataAdditionalInforAnswer => webDriver.FindElementByCssSelector("label[for='with-additional-info']");
        ReadOnlyCollection<IWebElement> CustomerDataSalutationLabel => webDriver.FindElementsByCssSelector("div[class*='salutation'] label");
        ReadOnlyCollection<IWebElement> CustomerDataSalutationSpanList => webDriver.FindElementsByCssSelector("div[class*='salutation'] label span");
        private IWebElement CustomerDataMrLabel => webDriver.FindElementByCssSelector("label[for='radioMr'] span:not([class*='checkmark'])");
        private IWebElement CustomerDataMrsLabel => webDriver.FindElementByCssSelector("label[for='radioMrs'] span:not([class*='checkmark'])");
        private IWebElement CustomerDataFirstNameLabel => webDriver.FindElementByCssSelector("div[class='input-row--first-name']");
        private IWebElement CustomerDataLastNameLabel => webDriver.FindElementByCssSelector("div[class='input-row--last-name']");
        private IWebElement CustomerDataFirstNameInput => webDriver.FindElementById("customer-first-name");
        private IWebElement CustomerDataLastNameInput => webDriver.FindElementById("customer-last-name");
        ReadOnlyCollection<IWebElement> CustomerDataTelephoneNumberLabelList => webDriver.FindElementsByCssSelector("label[for='customer-telefon']");
        private IWebElement CustomerDataTelephoneNumberInput => webDriver.FindElementById("customer-telefon");
        private IWebElement CustomerDataEmailAddressLabel => webDriver.FindElementByXPath("//label[contains(., 'E-mail adres')]");
        private IWebElement CustomerDataEmailAddressAnswers => webDriver.FindElementByCssSelector("label[for='with-customer-email']");
        private IWebElement CustomerDataEmailAddressInput => webDriver.FindElementById("customer-email");
        private IWebElement CustomerDataEmailAddressSubNote => webDriver.FindElementByCssSelector("p[class='sub-note']");
        private By CustomerDateContainerInputSelector = By.CssSelector("div[class*='customer-input']");
        private IWebElement CustomerDataTelephoneNumberErrorMessage => webDriver.FindElementByCssSelector("span[class='input-validation error']");
        private IWebElement CustomerDataEmailAddressErrorMessage => webDriver.FindElementByCssSelector("span[class='input-validation error']");
        private By CustomerDataEmailAddressErrorMessageSelector = By.CssSelector("span[class='input-validation error']");
        #endregion

        #region Thank You page
        ReadOnlyCollection<IWebElement> ThankYouPagePromoComponentList => webDriver.FindElementsByXPath("//div[@class='reg-box--section']");
        ReadOnlyCollection<IWebElement> ThankYouPageHeaderBoxesTextList => webDriver.FindElementsByCssSelector("p[class='reg-box--title']");
        ReadOnlyCollection<IWebElement> ThankYouPageContentBoxesTextList => webDriver.FindElementsByCssSelector("p[class='reg-box--content']");
        ReadOnlyCollection<IWebElement> ThankYouPageButtonBoxesTextList => webDriver.FindElementsByXPath("//div[@class='reg-box--section']//following-sibling::a");
        private IWebElement DownloadResumeBox => webDriver.FindElementByCssSelector(".dl-pdf");
        private IWebElement StartNowesumeBox => webDriver.FindElementByCssSelector(".niuewe");
        private IWebElement ThankYouHeader => webDriver.FindElementByCssSelector("div[class='c-reg--main']");
        #endregion

        #endregion

        #region Header and Footer
        public void ClickOnSingleUploadButton()
        {
            seleniumAddOns.WaitUntilElementIsVisible(SelectSingleAddress, 5);
            seleniumAddOns.Click(SelectSingleAddress);

            seleniumAddOns.Click(SelectStart);
        }

        public string ReturnMainHeaderBackgroundColor()
        {
            Thread.Sleep(1000);
            return seleniumAddOns.VerifyBackgroundColor(MainHeader);
        }

        public string ReturnHeaderBackLinkText()
        {
            return seleniumAddOns.GetElementText(BackLink);
        }

        public string ReturnProfileMessagesLinkText()
        {
            return seleniumAddOns.GetElementText(ProfileMessagesLink);
        }

        public string ReturnProfileNameLinkText()
        {
            return seleniumAddOns.GetElementText(ProfileNameLink);
        }

        public bool ReturnRemehaLogoIsDisplayed()
        {
            return seleniumAddOns.VerifyIsElementDisplayed(RemehaLogo);
        }

        public string ReturnProductRegistrationMenuText()
        {
            return seleniumAddOns.GetElementText(ProductRegistrationMenu);
        }
        public string ReturnOgpMenuText()
        {
            var OgpMenu = seleniumAddOns.GetElementByIndex(MenuList, 3);
            return seleniumAddOns.GetElementText(OgpMenu);
        }

        public string ReturnShopMenuLinkMenuText()
        {
            var OgpMenu = seleniumAddOns.GetElementByIndex(MenuList, 3);
            return seleniumAddOns.GetElementText(OgpMenu);
        }

        public IWebElement ReturnShoppingCartIconIsDisplayed()
        {
            return seleniumAddOns.VerifyIfElementExists(ShoppingCartIconSelector);
        }

        public string ReturnAccountPointsText()
        {
            return seleniumAddOns.GetElementText(AccountPoints);
        }

        public string ReturnCustomerSubMenuText()
        {
            var customerMenu = seleniumAddOns.GetElementByIndex(MenuList, 4);
            return seleniumAddOns.GetElementText(customerMenu);
        }

        public string ReturnTrainingSubMenuText()
        {
            var trainingMenu = seleniumAddOns.GetElementByIndex(MenuList, 5);
            return seleniumAddOns.GetElementText(trainingMenu);
        }

        public string ReturnServiceSubMenuText()
        {
            var serviceMenu = seleniumAddOns.GetElementByIndex(MenuList, 6);
            return seleniumAddOns.GetElementText(serviceMenu);
        }

        public string ReturnActionsSubMenuText()
        {
            var actionsMenu = seleniumAddOns.GetElementByIndex(MenuList, 7);
            return seleniumAddOns.GetElementText(actionsMenu);
        }

        public string ReturnHelpSubMenuText()
        {
            var helpMenu = seleniumAddOns.GetElementByIndex(MenuList, 8);
            return seleniumAddOns.GetElementText(helpMenu);
        }

        public string ReturnProductRegistrationMenuBackgroundColor()
        {
            return seleniumAddOns.VerifyBackgroundColor(ProductRegistrationMenu);
        }

        public bool ReturnFooterIsDisplayed()
        {
            return seleniumAddOns.VerifyIsElementDisplayed(Footer);
        }

        public string ReturnFooterBackgroundColor()
        {
            return seleniumAddOns.VerifyFontColor(Footer);
        }

        public bool ReturnFooterRemehaLogoWhiteIsDisplayed()
        {
            return seleniumAddOns.VerifyIsElementDisplayed(RemehaLogoWhite);
        }

        public string ReturnTermsOfUseText()
        {
            var termsOfUse = seleniumAddOns.GetElementByIndex(FooterLinksList, 1);
            return seleniumAddOns.GetElementText(termsOfUse);
        }

        public string ReturnCookiesAndPrivacyPolicyText()
        {
            var cookiesAndPrivacyPolicy = seleniumAddOns.GetElementByIndex(FooterLinksList, 2);
            return seleniumAddOns.GetElementText(cookiesAndPrivacyPolicy);
        }

        public string ReturnCompanyInformationText()
        {
            var companyInformation = seleniumAddOns.GetElementByIndex(FooterLinksList, 3);
            return seleniumAddOns.GetElementText(companyInformation);
        }
        public string ReturnTradeMarkText()
        {
            return seleniumAddOns.GetElementText(TradeMark);
        }
        #endregion

        #region Common Page Commands/Actions
        public void ClickOnArrangeAndFinalizeOGPButton()
        {
            seleniumAddOns.WaitUntilElementIsVisible(ArrangeAndFinalizeOGPButton, 5);
            seleniumAddOns.Click(ArrangeAndFinalizeOGPButton);
        }
        public bool ReturnArrangeAndFinalizeOGPButtonIsDisplayed()
        {
            return seleniumAddOns.VerifyIsElementDisplayed(ArrangeAndFinalizeOGPButton);
        }
        public void ClickCompleteRegistrationButton()
        {
            //var ElementVisible = seleniumAddOns.WaitUntilCollectonOfElementsExist(30, CompleteRegistration);
            seleniumAddOns.Click(CompleteRegistration);
            Thread.Sleep(2000);
        }

        public void ClickOgpBackButton()
        {
            seleniumAddOns.WaitUntilElementIsVisible(OgpBackButton, 10);
            seleniumAddOns.Click(OgpBackButton);
        }

        public void SelecOGP(string ogpValue)
        {
            seleniumAddOns.WaitUntilElementIsVisible(InstallerDropdownSelected, 5);
            seleniumAddOns.ScrollAndClick(InstallerDropdownSelected);

            var selectOgp = InstallerDropdownOptionList.FirstOrDefault(item => item.Text.Equals(ogpValue));
            seleniumAddOns.Click(selectOgp);
        }

        public void SelecMultipleOGP(int productItemNumber, string ogpValue)
        {
            seleniumAddOns.WaitUntilElementIsVisible(BackLink, 5);

            var productItemDropdownSelected = seleniumAddOns.GetElementByIndex(InstallerDropdownSelectedList, productItemNumber);
            var productItemDropdown = productItemDropdownSelected.FindElement(InstallerDropdownSelectedSelector);
            seleniumAddOns.ScrollAndClick(productItemDropdown);

            var productItem = productItemDropdownSelected.FindElements(InstallerDropdownOptionListSelector).FirstOrDefault(item => item.Text.Equals(ogpValue));
            seleniumAddOns.Click(productItem);
        }

        public bool ReturnSelectOGPElement()
        {
            return seleniumAddOns.VerifyIsElementDisplayed(InstallerDropdownSelected);
        }

        public bool ReturnSuccessRegistrationImage()
        {
            return seleniumAddOns.VerifyIsElementDisplayed(SuccessRegistrationImage);
        }

        public bool ReturnSuccessRegistrationMessage()
        {
            return seleniumAddOns.VerifyIsElementDisplayed(SuccessRegistrationMessage);
        }

        public string ReturnWindowUrl()
        {
            return seleniumAddOns.GetWindowUrl();
        }
        #endregion

        #region Address
        public string ReturnPostalCodeBorderBottomColor()
        {
            return seleniumAddOns.VerifyBorderBottomColor(PostCodeInput);
        }

        public string ReturnHouseNumberBorderBottomColor()
        {
            return seleniumAddOns.VerifyBorderBottomColor(HouseNumberInput);
        }

        public string ReturnAddressSuccessMessageVerifyFontFamily()
        {
            return seleniumAddOns.VerifyFontFamily(AddressSuccessMessage);
        }

        public string ReturnRegisterAddressSuccessMessage()
        {
            return seleniumAddOns.GetElementText(AddressSuccessMessage);
        }

        public string ReturnRegisterAddressErrorMessage()
        {
            return seleniumAddOns.GetElementText(AddressErrorMessage);
        }

        public string ReturnAddressErrorMessageVerifyFontFamily()
        {
            return seleniumAddOns.VerifyFontFamily(AddressErrorMessage);
        }

        public void EnterPostalCodeAndHouseNumber(string postCode, string houseNumber)
        {
            seleniumAddOns.WaitUntilElementIsVisible(PostCodeInput, 5);
            seleniumAddOns.SendKeys(PostCodeInput, postCode);
            seleniumAddOns.WaitUntilElementIsVisible(HouseNumberInput, 5);
            seleniumAddOns.SendKeys(HouseNumberInput, houseNumber);
            Thread.Sleep(5000);
        }

        public string ReturnPostCodeInputPlaceholderValue()
        {
            return seleniumAddOns.GetInputTypeValue(PostCodeInput, "placeholder");
        }

        public string ReturnHouseNumberInputPlaceholderValue()
        {
            return seleniumAddOns.GetInputTypeValue(HouseNumberInput, "placeholder");
        }

        public string ReturnCustomerDataEmailAddressAnswersText()
        {
            return seleniumAddOns.GetElementText(CustomerDataEmailAddressAnswers);
        }

        public IWebElement ReturnCustomerDateContainerInputSelectorIsDisplayed()
        {
            return seleniumAddOns.VerifyIfElementExists(CustomerDateContainerInputSelector);
        }
        #endregion

        #region Adding of products
        public void EnterProductSerialNumber(string serialNumber)
        {
            seleniumAddOns.WaitUntilElementIsVisible(ProductSerialNumber, 10);
            seleniumAddOns.SendKeys(ProductSerialNumber, serialNumber);
            Thread.Sleep(3000);
        }

        public void ClickOnProductLinkAdd()
        {
            seleniumAddOns.WaitUntilElementIsVisible(ProductAddedLink, 5);
            seleniumAddOns.Click(ProductAddedLink);
        }

        public int ReturnNumberOfAddedProducts()
        {
            return seleniumAddOns.GetElementCount(ProductAddedList);
        }

        public int ReturnNumberOfCombiAddedProducts()
        {
            return seleniumAddOns.GetElementCount(ProductCombiOverviewList);
        }

        public string ReturnMessageWhenAddingFiveProducts()
        {
            seleniumAddOns.WaitUntilElementIsVisible(ProductErrorMessageText, 5);
            return seleniumAddOns.GetElementText(ProductErrorMessageText);
        }

        public string ReturnProductFoundLabelText()
        {
            return seleniumAddOns.GetElementText(ProductFoundLabel);
        }

        public string ReturnProductErrorMessageText()
        {
            return seleniumAddOns.GetElementText(ProductErrorMessageText);
        }

        public string ReturnAddedProductsLabelText()
        {
            return seleniumAddOns.GetElementText(AddedProductsLabel);
        }

        public string ReturnAddedProductImage()
        {
            return seleniumAddOns.GetInputTypeValue(ProductAddedImage, "src");
        }

        public string ReturnProductUnknownImage()
        {
            return seleniumAddOns.GetInputTypeValue(ProductUnknownImage, "src");
        }

        public string ReturnProductAddedTitleText()
        {
            return seleniumAddOns.GetElementText(ProductAddedTitle);
        }

        public string ReturnProductAddedSerialNumberText()
        {
            return seleniumAddOns.GetElementText(ProductAddedSerialNumber);
        }

        public string ReturnProductAddedSerialFontColor()
        {
            return seleniumAddOns.VerifyFontColor(ProductAddedSerialNumber);
        }

        public string ReturnProductAddedSerialBackgroundColor()
        {
            return seleniumAddOns.VerifyBackgroundColor(ProductAddedSerialNumber);
        }

        public bool ReturnProductAddLinkIsDisplayed()
        {
            return seleniumAddOns.VerifyIsElementDisplayed(ProductAddedLink);
        }

        public bool ReturnProductRemoveLinkIsDisplayed()
        {
            return seleniumAddOns.VerifyIsElementDisplayed(ProductRemoveLink);
        }

        public string ReturnProductAddLinkFontColor()
        {
            return seleniumAddOns.VerifyFontColor(ProductAddedLink);
        }

        public string ReturnProductErrorMessageTextFontColor()
        {
            return seleniumAddOns.VerifyFontColor(ProductErrorMessageText);
        }

        public string ReturnProductRemoveLinkFontColor()
        {
            return seleniumAddOns.VerifyFontColor(ProductRemoveLink);
        }

        public string ReturnProductAdddedLoytalPointsIsDisplayed()
        {
            return seleniumAddOns.GetElementText(ProductAdddedLoytalPoints);
        }

        public string ReturnProductAdddedLoytalPointsFontColor()
        {
            return seleniumAddOns.VerifyFontColor(ProductAdddedLoytalPoints);
        }

        public bool ReturnPProductAdddedClosebuttonIsDisplayed()
        {
            return seleniumAddOns.VerifyIsElementDisplayed(ProductAdddedClosebutton);
        }

        public void RemoveTheFirstAddedProduct()
        {
            var firstAddedProductElementRemoveLink = seleniumAddOns.GetElementByIndex(ProductRemoveLinkList, 0);
            seleniumAddOns.Click(firstAddedProductElementRemoveLink);
        }

        public string ReturnProductSerialNumberPlaceholderValue()
        {
            return seleniumAddOns.GetInputTypeValue(ProductSerialNumber, "placeholder");
        }

        public string ReturnProductPointsLoyaltyClassValue()
        {
            return seleniumAddOns.GetInputTypeValue(ProductLoytalPoints, "class");
        }

        public List<string> ReturnAllProductPointsLoyaltyText()
        {
            //TODO: refactor
            var porduct1Points = seleniumAddOns.GetElementByIndex(ProductLoytalPointsList, 0);
            var porduct2Points = seleniumAddOns.GetElementByIndex(ProductLoytalPointsList, 1);
            var porduct3Points = seleniumAddOns.GetElementByIndex(ProductLoytalPointsList, 2);

            var porduct1PointsClassValue = seleniumAddOns.GetElementText(porduct1Points);
            var porduct2PointsClassValue = seleniumAddOns.GetElementText(porduct2Points);
            var porduct3PointsClassValue = seleniumAddOns.GetElementText(porduct3Points);
            var list = new List<string>() { porduct1PointsClassValue, porduct2PointsClassValue, porduct3PointsClassValue };
            return list;
            //var xxxs = ProductLoytalPointsList.All(item => item.GetAttribute.);
            //return seleniumAddOns.GetInputTypeValue(ProductLoytalPoints, "class");
            // var elementState = element.GetAttribute(attribute);
            //return elementState;
        }

        //TODO: refactor
        public List<string> ReturnAllProductPointsLoyaltyClassValue()
        {
            var porduct1Points = seleniumAddOns.GetElementByIndex(ProductLoytalPointsList, 0);
            var porduct2Points = seleniumAddOns.GetElementByIndex(ProductLoytalPointsList, 1);
            var porduct3Points = seleniumAddOns.GetElementByIndex(ProductLoytalPointsList, 2);

            var porduct1PointsClassValue = seleniumAddOns.GetInputTypeValue(porduct1Points, "class");
            var porduct2PointsClassValue = seleniumAddOns.GetInputTypeValue(porduct2Points, "class");
            var porduct3PointsClassValue = seleniumAddOns.GetInputTypeValue(porduct3Points, "class");
            var list = new List<string>() { porduct1PointsClassValue, porduct2PointsClassValue, porduct3PointsClassValue };
            return list;
            //var xxxs = ProductLoytalPointsList.All(item => item.GetAttribute.);
            //return seleniumAddOns.GetInputTypeValue(ProductLoytalPoints, "class");
            // var elementState = element.GetAttribute(attribute);
            //return elementState;
        }

        public string ReturnProductCloseLinkIsDisplayed()
        {
            return seleniumAddOns.GetElementText(CloseLink);
        }

        public string ReturnSelectTheProductTextIsDisplayed()
        {
            return seleniumAddOns.GetElementText(SelectTheProductText);
        }

        public string ReturnProductRegularAddLinkText()
        {
            return seleniumAddOns.GetElementText(ProductRegularAddLink);
        }

        public string ReturnNotFoundProductSerialNumberText()
        {
            return seleniumAddOns.GetElementText(NotFoundProductSerialNumberText);
        }

        public void SelectNewProductFromTheList(string product)
        {
            seleniumAddOns.ScrollAndClick(SelectTheProductText);
            var selectedProduct = SelectedRegularProductList.FirstOrDefault(item => item.Text.Equals(product));
            seleniumAddOns.Click(selectedProduct);

            seleniumAddOns.Click(ProductRegularAddLink);
            Thread.Sleep(1000);
        }

        public string ReturnNUnRecognizedSerialNumberErrorMessageText()
        {
            Thread.Sleep(500);
            return seleniumAddOns.GetElementText(UnRecognizedSerialNumberErrorMessage);
        }

        public void ReEnterProductSerialNumber(string serialNum)
        {
            seleniumAddOns.WaitUntilElementIsVisible(ReTypeProductSerialNumberInput, 5);
            seleniumAddOns.SendKeys(ReTypeProductSerialNumberInput, serialNum);
        }

        public void ClickOnCloseButtonProductResultPopUpWindow()
        {
            seleniumAddOns.WaitUntilElementIsVisible(ProductAdddedClosebutton, 5);
            seleniumAddOns.Click(ProductAdddedClosebutton);
        }

        public IWebElement ReturnProductResultPopUpWindowIsDisplayed()
        {
            return seleniumAddOns.VerifyIfElementExists(ProductAdddedClosebuttonSelector);
        }

        public string ReturnProductPointsText()
        {
            return seleniumAddOns.GetElementText(ProductLoytalPoints);
        }

        public void ClickOnRegularProductAddLink()
        {
            seleniumAddOns.Click(ProductRegularAddLink);
        }

        public bool ReturnCombiProductImage()
        {
            return seleniumAddOns.VerifyIsElementDisplayed(ProductCombiOverviewImage);
        }

        public string ReturnCombiProductTitleText()
        {
            return seleniumAddOns.GetElementText(ProductCombiOverviewTitle);
        }

        public bool ReturnCombiAddedProductImage()
        {
            return seleniumAddOns.VerifyIsElementDisplayed(ProductAddedCombiOverviewImage);
        }

        public string ReturnCombiAddedProductTitleText()
        {
            return seleniumAddOns.GetElementText(ProductAddedCombiOverviewTitle);
        }

        public string ReturnSecondarProductMarginLeftPxValue()
        {
            return seleniumAddOns.VerifyMarginLeft(SecondaryProduct);
        }
        #endregion

        #region Instillation Date
        public void SelectInstallationDate(string date)
        {
            //seleniumAddOns.ScrollToAnElement(DatePickerWrapper);
            var installationDate = GetDate(date);
            CultureInfo dutch = new CultureInfo("nl-NL");
            var monthValue = installationDate.ToString("MMMM", dutch);
            var yearValue = installationDate.Year.ToString();
            var dayValue = installationDate.Day.ToString();

            // click on date picker label
            seleniumAddOns.Click(DatePickerWrapper);

            // set month
            seleniumAddOns.SelectFromDropdownByText(IntallationDateMonthPicker, monthValue);

            // set year
            seleniumAddOns.SelectFromDropdownByText(IntallationDateYearPicker, yearValue);

            // select day
            Thread.Sleep(1500);
            var selectDay = IntallationDateDayPickerList.FirstOrDefault(m => m.Text.Equals(dayValue) && m.Displayed.Equals(true));

            //var selectDayIsClickable = seleniumAddOns.VerifyIfElementIsClickable();
            if (seleniumAddOns.VerifyIfElementIsClickable(selectDay) == true)
            {
                seleniumAddOns.Click(selectDay);
            }
        }

        public DateTime GetDate(string input)
        {
            var strDate = new DateTime();
            switch (input.ToUpper())
            {
                case "TOMORROW":
                    strDate = DateTime.Today.AddDays(1);
                    break;
                case "TODAY":
                    strDate = DateTime.Today;
                    break;
                case "NEXT-WEEK":
                    strDate = DateTime.Today.AddDays(7);
                    break;
                case "MID-MONTH":
                    strDate = DateTime.Today.AddDays(15);
                    break;
                case "NEXT-MONTH":
                    strDate = DateTime.Today.AddDays(30);
                    break;
                case "NEXT-TWO-MONTHS":
                    strDate = DateTime.Today.AddDays(60);
                    break;
                case "LAST-WEEK":
                    strDate = DateTime.Today.AddDays(-7);
                    break;
                case "TODAY + 1":
                    strDate = DateTime.Today.AddDays(1);
                    break;
                case "TODAY - 28":
                    strDate = DateTime.Today.AddDays(-28);
                    break;
                case "TODAY - 29":
                    strDate = DateTime.Today.AddDays(-29);
                    break;
                case "TODAY + 29":
                    strDate = DateTime.Today.AddDays(29);
                    break;
                case "TODAY + 28":
                    strDate = DateTime.Today.AddDays(28);
                    break;
            }
            return strDate;
        }

        public string ReturnSelectedInstillationDate()
        {
            Thread.Sleep(10000);
            return seleniumAddOns.GetElementText(DatePickerWrapper);
        }

        public string ReturnConvertedDutchInstillationDate(string selectedDate)
        {
            string date = "";
            var installationDate = GetDate(selectedDate);
            CultureInfo dutch = new CultureInfo("nl-NL");

            if (installationDate == DateTime.Today)
            {
                date = installationDate.ToString("dddd, dd MMMM", dutch).ToUpper();
            }
            else
                //date = installationDate.ToString("dddd, dd MMMM yyyy", dutch).ToUpper();
                date = installationDate.ToString("dddd, dd MMMM", dutch).ToUpper();

            return date;
        }

        public string ReturnInstillationSelectDayIsDisabled(string date)
        {
            //seleniumAddOns.ScrollToAnElement(DatePickerWrapper);
            var installationDate = GetDate(date);
            CultureInfo dutch = new CultureInfo("nl-NL");
            var monthValue = installationDate.ToString("MMMM", dutch);
            var yearValue = installationDate.Year.ToString();
            var dayValue = installationDate.Day.ToString();

            // click on date picker label
            seleniumAddOns.Click(DatePickerWrapper);

            // set month
            seleniumAddOns.SelectFromDropdownByText(IntallationDateMonthPicker, monthValue);

            // set year
            seleniumAddOns.SelectFromDropdownByText(IntallationDateYearPicker, yearValue);

            // select day
            Thread.Sleep(1500);
            var selectDay = IntallationDateDayPickerList.FirstOrDefault(m => m.Text.Equals(dayValue) && m.Displayed.Equals(true));

            return seleniumAddOns.GetInputTypeValue(selectDay, "class");
        }
        #endregion

        #region Project Switch
        public void SelectProject(string val)
        {
            seleniumAddOns.WaitUntilElementIsVisible(ProjectSwitchInput, 5);
            seleniumAddOns.Click(ProjectSwitchInput);

            var projectSwitchValue = seleniumAddOns.GetElementText(ProjectSwitchInput);

            if (projectSwitchValue != val)
            {
                seleniumAddOns.Click(ProjectSwitchInput);
            }
        }

        public string ReturnDefaultSelectedProjectSwitch()
        {
            seleniumAddOns.WaitUntilElementIsVisible(ProjectSwitchInput, 5);
            return seleniumAddOns.GetElementText(ProjectSwitchInput);
        }

        public string ReturnProjectSwitchBackgroundColor()
        {
            return seleniumAddOns.VerifyBackgroundColor(ProjectSwitchInput);
        }

        public string ReturnProjectSwitchWhatDoesThisMeanLink()
        {
            seleniumAddOns.WaitUntilElementIsVisible(ProjectSwitchWhatDoesThisMeanLink, 5);
            return seleniumAddOns.GetElementText(ProjectSwitchWhatDoesThisMeanLink);
        }

        public void EnterProjectId(string projectId)
        {
            //enter project id
            seleniumAddOns.WaitUntilElementIsVisible(ProjectIdInput, 5);
            seleniumAddOns.SendKeys(ProjectIdInput, projectId);
            Thread.Sleep(500);
        }

        public string ReturnProjectIdInputBorderBottomColor()
        {
            return seleniumAddOns.VerifyBorderBottomColor(ProjectIdInput);
        }

        public string ReturnProjectIdSuccessMessage()
        {
            return seleniumAddOns.GetElementText(ProjectIdSuccessMessage);
        }

        public string ReturnProjectIdSuccessMessageFontColor()
        {
            return seleniumAddOns.VerifyFontColor(ProjectIdSuccessMessage);
        }

        public string ReturnProjectIdPlaceholderValue()
        {
            return seleniumAddOns.GetInputTypeValue(ProjectIdInput, "placeholder");
        }

        public bool ReturnSelectProjectButtonIsDisplayed()
        {
            return seleniumAddOns.VerifyIsElementDisplayed(SelectProjectButton);
        }

        public string ReturnSelectProjectButtonBackgroundColor()
        {
            return seleniumAddOns.VerifyBackgroundColor(SelectProjectButton);
        }

        public string ReturnProjectIdErrorMessage()
        {
            return seleniumAddOns.GetElementText(ProjectIdErrorMessage);
        }

        public string ReturnProjectIdErrorMessageFontColor()
        {
            return seleniumAddOns.VerifyFontColor(ProjectIdErrorMessage);
        }

        public IWebElement ReturnProjectIdInputIsDisplayed()
        {
            return seleniumAddOns.VerifyIfElementExists(ProjectIdInputSelector);
        }

        public IWebElement ReturnSelectProjectIdIsDisplayed()
        {
            return seleniumAddOns.VerifyIfElementExists(SelectProjectButtonSelector);
        }
        #endregion

        #region CustomerData
        public string ReturnCustomerDateHeaderTitleText()
        {
            return seleniumAddOns.GetElementText(CustomerDataHeaderTitle);
        }

        public string ReturnCustomerDateAdditionalInforAnswerText()
        {
            return seleniumAddOns.GetElementText(CustomerDataAdditionalInforAnswer);
        }

        public string ReturnCustomerDateAdditionalInforAnswerBackgroundColor()
        {
            return seleniumAddOns.VerifyBackgroundColor(CustomerDataAdditionalInforAnswer);
        }

        public void SelectAdditionalCustomerDataInformation(string val)
        {
            seleniumAddOns.WaitUntilElementIsVisible(CustomerDataAdditionalInforAnswer, 5);
            seleniumAddOns.Click(CustomerDataAdditionalInforAnswer);

            var projectSwitchValue = seleniumAddOns.GetElementText(CustomerDataAdditionalInforAnswer);

            if (projectSwitchValue != val)
            {
                seleniumAddOns.Click(CustomerDataAdditionalInforAnswer);
            }
        }

        public string ReturnCustomerDataSalutationText()
        {
            var CustomerDataSalutationLabelElement = seleniumAddOns.GetElementByIndex(CustomerDataSalutationLabel, 0);
            return seleniumAddOns.GetElementText(CustomerDataSalutationLabelElement);
        }

        public string ReturnCustomerDataSalutationClassValue()
        {
            var CustomerDataSalutationLabelElement = seleniumAddOns.GetElementByIndex(CustomerDataSalutationSpanList, 0);
            return seleniumAddOns.GetInputTypeValue(CustomerDataSalutationLabelElement, "class");
        }

        public string ReturnCustomerDataMrLabelText()
        {
            return seleniumAddOns.GetElementText(CustomerDataMrLabel);
        }

        public string ReturnCustomerDataMrsLabelText()
        {
            return seleniumAddOns.GetElementText(CustomerDataMrsLabel);
        }

        public string ReturnCustomerDataFirstNameLabelText()
        {
            return seleniumAddOns.GetElementText(CustomerDataFirstNameLabel);
        }

        public string ReturnCustomerDataLastNameLabelText()
        {
            return seleniumAddOns.GetElementText(CustomerDataLastNameLabel);
        }

        public string ReturnCustomerDataFirstNameInputPlacholderValue()
        {
            return seleniumAddOns.GetInputTypeValue(CustomerDataFirstNameInput, "placeholder");
        }

        public string ReturnCustomerDataFirstNameInputText()
        {
            return seleniumAddOns.GetElementText(CustomerDataFirstNameInput);
        }

        public string ReturnCustomerDataLastNameInputText()
        {
            return seleniumAddOns.GetElementText(CustomerDataLastNameInput);
        }

        public string ReturnCustomerDataTelephoneNumberInputText()
        {
            return seleniumAddOns.GetElementText(CustomerDataTelephoneNumberInput);
        }

        public string ReturnCustomerDataEmailAddressInputText()
        {
            return seleniumAddOns.GetElementText(CustomerDataEmailAddressInput);
        }

        public string ReturnCustomerDataLastNameInputPlacholderValue()
        {
            return seleniumAddOns.GetInputTypeValue(CustomerDataLastNameInput, "placeholder");
        }

        public void EnterCustomerDataFirstName(string firstname)
        {
            seleniumAddOns.SendKeys(CustomerDataFirstNameInput, firstname);
        }
        public void EnterCustomerDataLastName(string lastName)
        {
            seleniumAddOns.SendKeys(CustomerDataLastNameInput, lastName);
        }

        public string ReturnCustomerDataTelephoneNumberLabelText()
        {
            var CustomerDataTelephoneNumberElement = seleniumAddOns.GetElementByIndex(CustomerDataTelephoneNumberLabelList, 0);
            return seleniumAddOns.GetElementText(CustomerDataTelephoneNumberElement);
        }

        public string RetrunCustomerDataTelephoneNumberInputPlacholderValue()
        {
            return seleniumAddOns.GetInputTypeValue(CustomerDataTelephoneNumberInput, "placeholder");
        }

        public void EnterTelephoneNumber(string number)
        {
            seleniumAddOns.SendKeys(CustomerDataTelephoneNumberInput, number);
        }

        public string ReturnCustomerDataEmailAddressLabelText()
        {
            return seleniumAddOns.GetElementText(CustomerDataEmailAddressLabel);
        }

        public void SelecToAnswerEmailAddressInformation(string val)
        {
            seleniumAddOns.WaitUntilElementIsVisible(CustomerDataEmailAddressAnswers, 5);
            seleniumAddOns.Click(CustomerDataEmailAddressAnswers);

            var projectSwitchValue = seleniumAddOns.GetElementText(CustomerDataEmailAddressAnswers);

            if (projectSwitchValue != val)
            {
                seleniumAddOns.Click(CustomerDataEmailAddressAnswers);
            }
        }

        public void EnterEmailAddress(string emailAdd)
        {
            seleniumAddOns.SendKeys(CustomerDataEmailAddressInput, emailAdd);
        }

        public string RetrunCustomerDataEmailAddressInputPlacholderValue()
        {
            return seleniumAddOns.GetInputTypeValue(CustomerDataEmailAddressInput, "placeholder");
        }
        public string ReturnCustomerDataEmailAddressSubNoteText()
        {
            return seleniumAddOns.GetElementText(CustomerDataEmailAddressSubNote);
        }

        public string ReturnCustomerDataEmailAddressAnswersBackgroundColor()
        {
            return seleniumAddOns.VerifyBackgroundColor(CustomerDataEmailAddressAnswers);
        }

        public void SelectSalutation(string salutationValue)
        {
            switch (salutationValue)
            {
                case "Mr":
                    seleniumAddOns.Click(CustomerDataMrLabel);
                    break;
                case "Mrs":
                    seleniumAddOns.Click(CustomerDataMrsLabel);
                    break;
                default:
                    seleniumAddOns.Click(CustomerDataMrLabel);
                    break;
            }
        }

        public string ReturnCustomerDataTelephoneNumberBorderBottomColor()
        {
            return seleniumAddOns.VerifyBorderBottomColor(CustomerDataTelephoneNumberInput);
        }

        public string ReturnCustomerDataTelephoneNumberErrorMessageErrorMessageText()
        {
            return seleniumAddOns.GetElementText(CustomerDataTelephoneNumberErrorMessage);
        }

        public string ReturnCustomerDataTelephoneNumberErrorMessageErrorMessageTextFontColor()
        {
            return seleniumAddOns.VerifyFontColor(CustomerDataTelephoneNumberErrorMessage);
        }

        public string ReturnCustomerDataEmailAddressInputClassValue()
        {
            return seleniumAddOns.GetInputTypeValue(CustomerDataEmailAddressInput, "class");
        }

        public string ReturnCustomerDataEmailAddressErrorMessageText()
        {
            return seleniumAddOns.GetElementText(CustomerDataEmailAddressErrorMessage);
        }

        public IWebElement ReturnCustomerDataEmailAddressErrorMessageIsDisplayed()
        {
            return seleniumAddOns.VerifyIfElementExists(CustomerDataEmailAddressErrorMessageSelector);
        }
        #endregion

        #region OGP section
        public string ReturnArrangeYourPartsWarrantyPlanImmediatelyHeaderText()
        {
            return seleniumAddOns.GetElementText(ArrangeYourPartsWarrantyPlanImmediatelyHeaderText);
        }

        public string ReturnOgpSectionProductAddedTitleText()
        {
            return seleniumAddOns.GetElementText(OgpSectionProductAddedTitle);
        }

        public bool ReturnOgpSectionProductAddedImageIsDisplayed()
        {
            return seleniumAddOns.VerifyIsElementDisplayed(OgpSectionProductAddedImage);
        }

        public string ReturnOgpSectionProductAdddedLoytalPointsText()
        {
            return seleniumAddOns.GetElementText(OgpSectionProductAddedLoytalPoints);
        }

        public string ReturnOgpSectionProductAdddedLoytalPointsFontColor()
        {
            return seleniumAddOns.VerifyFontColor(OgpSectionProductAddedLoytalPoints);
        }

        public string ReturnOgpSectionProductSerialNumberText()
        {
            return seleniumAddOns.GetElementText(OgpSectionProductSerialNumberText);
        }

        public string ReturnOgpSectionPartsWarrantyPlanLabelText()
        {
            return seleniumAddOns.GetElementText(OgpSectionPartsWarrantyPlanLabelText);
        }

        public string ReturnNoOgpSelectedYetLabelText()
        {
            return seleniumAddOns.GetElementText(SelectTheProductText);
        }

        public string ReturnOgpBackButtonText()
        {
            return seleniumAddOns.GetElementText(OgpBackButton);
        }
        public IWebElement ReturnOgpSectionProductAddedLoytalPointsSelectorIsDisplayed()
        {
            return seleniumAddOns.VerifyIfElementExists(OgpSectionProductAddedLoytalPointsSelector);
        }
        #endregion

        #region Thank You Page
        public int ReturnPromoComponentListCount()
        {
            return seleniumAddOns.GetElementCount(ThankYouPagePromoComponentList);
        }

        public string ReturnPartsWarrantyPlanHeaderText()
        {
            var PartsWarrantyPlanHeaderElement = seleniumAddOns.GetElementByIndex(ThankYouPageHeaderBoxesTextList, 0);
            return seleniumAddOns.GetElementText(PartsWarrantyPlanHeaderElement);
        }

        public string ReturnPointsUpdatedHeaderText()
        {
            var PointsUpdatedHeaderElement = seleniumAddOns.GetElementByIndex(ThankYouPageHeaderBoxesTextList, 1);
            return seleniumAddOns.GetElementText(PointsUpdatedHeaderElement);
        }

        public string ReturnResumeHeaderText()
        {
            var ResumeHeaderElement = seleniumAddOns.GetElementByIndex(ThankYouPageHeaderBoxesTextList, 2);
            return seleniumAddOns.GetElementText(ResumeHeaderElement);
        }

        public string ReturnResumeHeaderTextFontColor()
        {
            var ResumeHeaderElement = seleniumAddOns.GetElementByIndex(ThankYouPageHeaderBoxesTextList, 2);
            return seleniumAddOns.VerifyFontColor(ResumeHeaderElement);
        }

        public string ReturnNeRegistrationHeaderText()
        {
            var NewRegistrationHeaderElement = seleniumAddOns.GetElementByIndex(ThankYouPageHeaderBoxesTextList, 3);
            return seleniumAddOns.GetElementText(NewRegistrationHeaderElement);
        }

        public string ReturnPartsWarrantyPlanContentText()
        {
            var PartsWarrantyPlanHeaderElement = seleniumAddOns.GetElementByIndex(ThankYouPageContentBoxesTextList, 0);
            return seleniumAddOns.GetElementText(PartsWarrantyPlanHeaderElement);
        }

        public string ReturnPointsUpdatedContentText()
        {
            var PointsUpdatedHeaderElement = seleniumAddOns.GetElementByIndex(ThankYouPageContentBoxesTextList, 1);
            return seleniumAddOns.GetElementText(PointsUpdatedHeaderElement);
        }

        public string ReturnResumeContentText()
        {
            var ResumeHeaderElement = seleniumAddOns.GetElementByIndex(ThankYouPageContentBoxesTextList, 2);
            return seleniumAddOns.GetElementText(ResumeHeaderElement);
        }

        public string ReturnResumeContentTextFontColor()
        {
            var ResumeHeaderElement = seleniumAddOns.GetElementByIndex(ThankYouPageContentBoxesTextList, 2);
            return seleniumAddOns.VerifyFontColor(ResumeHeaderElement);
        }

        public string ReturnNeRegistrationContentText()
        {
            var NewRegistrationHeaderElement = seleniumAddOns.GetElementByIndex(ThankYouPageContentBoxesTextList, 3);
            return seleniumAddOns.GetElementText(NewRegistrationHeaderElement);
        }

        public string ReturnPartsWarrantyPlanButtonText()
        {
            var PartsWarrantyPlanHeaderElement = seleniumAddOns.GetElementByIndex(ThankYouPageButtonBoxesTextList, 0);
            return seleniumAddOns.GetElementText(PartsWarrantyPlanHeaderElement);
        }

        public string ReturnPartsWarrantyPlanButtonBorderBottomColor()
        {
            var PartsWarrantyPlanHeaderElement = seleniumAddOns.GetElementByIndex(ThankYouPageButtonBoxesTextList, 0);
            return seleniumAddOns.VerifyBorderBottomColor(PartsWarrantyPlanHeaderElement);
        }

        public string ReturnPartsWarrantyPlanButtonBorderLeftColor()
        {
            var PartsWarrantyPlanHeaderElement = seleniumAddOns.GetElementByIndex(ThankYouPageButtonBoxesTextList, 0);
            return seleniumAddOns.VerifyBorderLeftColor(PartsWarrantyPlanHeaderElement);
        }

        public string ReturnPartsWarrantyPlanButtonBorderRightColor()
        {
            var PartsWarrantyPlanHeaderElement = seleniumAddOns.GetElementByIndex(ThankYouPageButtonBoxesTextList, 0);
            return seleniumAddOns.VerifyBorderRightColor(PartsWarrantyPlanHeaderElement);
        }

        public string ReturnPartsWarrantyPlanButtonBorderTopColor()
        {
            var PartsWarrantyPlanHeaderElement = seleniumAddOns.GetElementByIndex(ThankYouPageButtonBoxesTextList, 0);
            return seleniumAddOns.VerifyBorderTopColor(PartsWarrantyPlanHeaderElement);
        }

        public string ReturnPointsUpdatedButtonText()
        {
            var PointsUpdatedHeaderElement = seleniumAddOns.GetElementByIndex(ThankYouPageButtonBoxesTextList, 1);
            return seleniumAddOns.GetElementText(PointsUpdatedHeaderElement);
        }

        public string ReturnPointsUpdatedButtonFontColor()
        {
            var PointsUpdatedHeaderElement = seleniumAddOns.GetElementByIndex(ThankYouPageButtonBoxesTextList, 1);
            var PointsUpdatedHeaderElementFontColor = PointsUpdatedHeaderElement.FindElement(By.TagName("span"));
            return seleniumAddOns.VerifyFontColor(PointsUpdatedHeaderElementFontColor);
        }

        public string ReturnPointsUpdatedButtonBackgroundColor()
        {
            var PointsUpdatedHeaderElement = seleniumAddOns.GetElementByIndex(ThankYouPageButtonBoxesTextList, 1);
            return seleniumAddOns.VerifyBackgroundColor(PointsUpdatedHeaderElement);
        }

        public string ReturnResumeButtonText()
        {
            var ResumeHeaderElement = seleniumAddOns.GetElementByIndex(ThankYouPageButtonBoxesTextList, 2);
            return seleniumAddOns.GetElementText(ResumeHeaderElement);
        }

        public string ReturnResumeButtonTextFontColor()
        {
            var ResumeHeaderElement = seleniumAddOns.GetElementByIndex(ThankYouPageButtonBoxesTextList, 2);
            return seleniumAddOns.VerifyFontColor(ResumeHeaderElement);
        }

        public string ReturnResumeButtonTextBackgroundColor()
        {
            var ResumeHeaderElement = seleniumAddOns.GetElementByIndex(ThankYouPageButtonBoxesTextList, 2);
            return seleniumAddOns.VerifyBackgroundColor(ResumeHeaderElement);
        }

        public string ReturnDownloadResumeBorderBoxBackgroundColor()
        {
            return seleniumAddOns.VerifyBackgroundColor(DownloadResumeBox);
        }

        public string ReturnNeRegistrationButtonText()
        {
            var NewRegistrationHeaderElement = seleniumAddOns.GetElementByIndex(ThankYouPageButtonBoxesTextList, 3);
            return seleniumAddOns.GetElementText(NewRegistrationHeaderElement);
        }

        public string ReturnStartNowesumeBoxBackgroundColor()
        {
            return seleniumAddOns.VerifyBackgroundColor(StartNowesumeBox);
        }

        public string ReturnNewRegistrationHeaderTextFontColor()
        {
            var newRegistrationElement = seleniumAddOns.GetElementByIndex(ThankYouPageHeaderBoxesTextList, 3);
            return seleniumAddOns.VerifyFontColor(newRegistrationElement);
        }

        public string ReturnReturnNewRegistrationContentTextFontColor()
        {
            var newRegistrationElement = seleniumAddOns.GetElementByIndex(ThankYouPageContentBoxesTextList, 3);
            return seleniumAddOns.VerifyFontColor(newRegistrationElement);
        }

        public string ReturnReturnNewRegistrationButtonTextFontColor()
        {
            var ReturnNewRegistrationElement = seleniumAddOns.GetElementByIndex(ThankYouPageButtonBoxesTextList, 2);
            return seleniumAddOns.VerifyFontColor(ReturnNewRegistrationElement);
        }

        public string ReturnReturnNewRegistrationTextBackgroundColor()
        {
            var ReturnReturnNewRegistrationTextBackgroundColor = seleniumAddOns.GetElementByIndex(ThankYouPageButtonBoxesTextList, 2);
            return seleniumAddOns.VerifyBackgroundColor(ReturnReturnNewRegistrationTextBackgroundColor);
        }

        public string ReturnThankYouHeaderBorderTopColor()
        {
            return seleniumAddOns.VerifyBorderTopColor(ThankYouHeader);
        }
        #endregion
    }
}
