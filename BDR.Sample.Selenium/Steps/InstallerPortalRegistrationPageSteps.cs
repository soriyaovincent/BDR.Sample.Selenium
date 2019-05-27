using BDR.Sample.Selenium.PageObjects;
using BDR.Sample.Selenium.StartUp;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;

namespace BDR.Sample.Selenium.Steps
{
    [Binding]
    public sealed class InstallerPortalRegistrationPageSteps
    {
        private static SeleniumWebDriver webDriver = new SeleniumWebDriver();
        private InstallerRegistrationPageObjects installerRegistrationPage = new InstallerRegistrationPageObjects(webDriver.GetWebDriver());

        [Given(@"I am on the Installer registration page")]
        public void GivenIAmOnTheInstallerRegistartionPage()
        {
            //var url = "https://rmh-nl-installer-portal.azurewebsites.net/InstallerRegistration";
            //webDriver.GetWebDriver().Navigate().GoToUrl(url);

            var url = string.Format(ConfigurationManager.AppSettings["InstallerPortalRegistrationPage"]);
            webDriver.GetWebDriver().Navigate().GoToUrl(url);

            installerRegistrationPage.ClickOnSingleUploadButton();
        }

        [StepDefinition(@"I have entered '(.*)' product serial number")]
        public void GivenIHaveEnteredProductSerialNumber(string serialNumber)
        {
            installerRegistrationPage.EnterProductSerialNumber(serialNumber);
        }

        #region Adding product
        [StepDefinition(@"I have entered the following product serial number")]
        public void GivenIHaveEnteredTheFollowingProductSerialNumber(Table table)
        {
            //var serialNumbers = table.CreateSet<InstallerProduct>();
            //foreach (InstallerProduct serialNumber in serialNumbers)
            //{
            //    installerRegistrationPage.EnterProductSerialNumber(serialNumber.ProductSerialNumber);
            //    installerRegistrationPage.ClickOnProductLinkAdd();
            //}
        }

        [Then(@"I should see '(.*)' added products")]
        public void ThenIShouldSeeAddedProducts(int expectedNumAddedProducts)
        {
            Assert.AreEqual(expectedNumAddedProducts, installerRegistrationPage.ReturnNumberOfAddedProducts());
        }

        [Then(@"I should see '(.*)' combi added products")]
        public void ThenIShouldSeeAddedCombiProducts(int expectedNumAddedProducts)
        {
            Assert.AreEqual(expectedNumAddedProducts, installerRegistrationPage.ReturnNumberOfCombiAddedProducts());
        }

        [When(@"I remove the first added product")]
        public void WhenIRemoveTheFirstAddedProduct()
        {
            installerRegistrationPage.RemoveTheFirstAddedProduct();
        }

        [StepDefinition(@"I added the product")]
        public void WhenIAddTheProduct()
        {
            installerRegistrationPage.ClickOnProductLinkAdd();
        }

        [Then(@"I should see '(.*)' warning message")]
        public void ThenIShouldSeeWarningMessage(string warningMessage)
        {
            Assert.AreEqual(warningMessage, installerRegistrationPage.ReturnMessageWhenAddingFiveProducts());
        }


        [Then(@"I should see search in products text label")]
        [Then(@"I should see product found label")]
        public void ThenIShouldSeeProductFoundLabel()
        {
            Assert.IsNotEmpty(installerRegistrationPage.ReturnProductFoundLabelText());
        }

        [Then(@"I should see that this serial number is already registered at a different address message with '(.*)' font color")]
        [Then(@"I should see no product found error message with '(.*)' font color")]
        public void ThenIShouldSeeNoProductFoundErrorMessage(string fontColor)
        {
            Assert.Multiple(() =>
            {
                Assert.IsNotEmpty(installerRegistrationPage.ReturnProductErrorMessageText());
                Assert.IsTrue(installerRegistrationPage.ReturnProductErrorMessageTextFontColor().Contains(fontColor));
            });
        }

        [Then(@"I should see product image")]
        public void ThenIShouldSeeProductImage()
        {
            Assert.IsNotEmpty(installerRegistrationPage.ReturnAddedProductImage());
        }

        [Then(@"I should see product title")]
        public void ThenIShouldSeeProductTitle()
        {
            Assert.IsNotEmpty(installerRegistrationPage.ReturnProductAddedTitleText());
        }

        [Then(@"I should see product '(.*)' serial number")]
        public void ThenIShouldSeeProductSerialNumber(string serialNumber)
        {
            Assert.AreEqual(serialNumber, installerRegistrationPage.ReturnProductAddedSerialNumberText());
        }

        [Then(@"I should see product serial number '(.*)' font color and '(.*)' background color")]
        public void ThenIShouldSeeProductSerialNumberBackgroundColor(string fontColor, string backgroundColor)
        {
            Assert.Multiple(() =>
            {
                Assert.IsTrue(installerRegistrationPage.ReturnProductAddedSerialFontColor().Contains(fontColor));
                Assert.IsTrue(installerRegistrationPage.ReturnProductAddedSerialBackgroundColor().Contains(backgroundColor));
            });
        }

        [Then(@"I should see product x close button")]
        public void ThenIShouldSeeProductXCloseButton()
        {
            Assert.IsTrue(installerRegistrationPage.ReturnPProductAdddedClosebuttonIsDisplayed());
        }

        [Then(@"I should see product close link")]
        public void ThenIShouldSeeProductCloseLink()
        {
            Assert.IsNotEmpty(installerRegistrationPage.ReturnProductCloseLinkIsDisplayed());
        }

        [Then(@"I should see unknown product image")]
        public void ThenIShouldSeeUnknownProductImage()
        {
            Assert.IsNotEmpty(installerRegistrationPage.ReturnProductUnknownImage());
        }

        [Then(@"I should see select the product text label")]
        public void ThenIShouldSeeSelectTheProductTextLabel()
        {
            Assert.IsNotEmpty(installerRegistrationPage.ReturnSelectTheProductTextIsDisplayed());
        }

        [Then(@"I should see the product regular add link")]
        public void ThenIShouldSeeTheProductRegularAddLink()
        {
            Assert.IsNotEmpty(installerRegistrationPage.ReturnProductRegularAddLinkText());
        }

        [Then(@"I should see my entered '(.*)' serial number")]
        public void ThenIShouldSeeMyEnteredSerialNumber(string serialNUmber)
        {
            Assert.AreEqual(serialNUmber, installerRegistrationPage.ReturnNotFoundProductSerialNumberText());
        }

        [Then(@"I should see product loyalty points with '(.*)' font color")]
        public void ThenIShouldSeeProductLoyalyPoints(string fontColor)
        {
            Assert.Multiple(() =>
            {
                Assert.IsNotEmpty(installerRegistrationPage.ReturnProductAdddedLoytalPointsIsDisplayed());
                Assert.IsTrue(installerRegistrationPage.ReturnProductAdddedLoytalPointsFontColor().Contains(fontColor));
            });
        }

        [Then(@"I should see product add link with '(.*)' font color")]
        public void ThenIShouldSeeProductAddLink(string fontColor)
        {
            Assert.Multiple(() =>
            {
                Assert.IsTrue(installerRegistrationPage.ReturnProductAddLinkIsDisplayed());
                Assert.IsTrue(installerRegistrationPage.ReturnProductAddLinkFontColor().Contains(fontColor));
            });
        }

        [Then(@"I should see product remove link with '(.*)' font color")]
        public void ThenIShouldSeeProductRemoveLinkWithFontColor(string fontColor)
        {
            Assert.Multiple(() =>
            {
                Assert.IsTrue(installerRegistrationPage.ReturnProductRemoveLinkIsDisplayed());
                Assert.IsTrue(installerRegistrationPage.ReturnProductRemoveLinkFontColor().Contains(fontColor));
            });
        }


        [Then(@"I should see added products label")]
        public void ThenIShouldSeeAddedProductsLabel()
        {
            Assert.IsNotEmpty(installerRegistrationPage.ReturnAddedProductsLabelText());
        }

        [Then(@"I should see product ssrial number '(.*)' placeholder value")]
        public void ThenIShouldSeeProductSsrialNumberPlaceholderValue(string placeholderValue)
        {
            Assert.AreEqual(placeholderValue, installerRegistrationPage.ReturnProductSerialNumberPlaceholderValue());
        }

        [When(@"I select a product '(.*)' from the list")]
        public void WhenISelectAProductFromTheList(string product)
        {
            installerRegistrationPage.SelectNewProductFromTheList(product);
        }

        [Then(@"I should see unrecognized serial number error message")]
        public void ThenIShouldSeeUnrecognizedSerialNumberErrorMessage()
        {
            Assert.IsNotEmpty(installerRegistrationPage.ReturnNUnRecognizedSerialNumberErrorMessageText());
        }

        [When(@"I click on the x close button")]
        public void WhenIClickOnTheXCloseButton()
        {
            installerRegistrationPage.ClickOnCloseButtonProductResultPopUpWindow();
        }

        [Then(@"product result pop-up window closed out")]
        public void ThenProductResultPop_UpWindowClosedOut()
        {
            Assert.IsNull(installerRegistrationPage.ReturnProductResultPopUpWindowIsDisplayed());
        }

        [When(@"I re-type the '(.*)' serial number")]
        public void WhenIRe_TypeTheSerialNumber(string serialNum)
        {
            installerRegistrationPage.ReEnterProductSerialNumber(serialNum);
        }

        [When(@"I add regular product")]
        public void WhenIAddRegularProduct()
        {
            installerRegistrationPage.ClickOnRegularProductAddLink();
        }

        [Then(@"I should see '(.*)' product points")]
        public void ThenIShouldSeeProductPoints(string expectedProductPoints)
        {
            Assert.AreEqual(expectedProductPoints, installerRegistrationPage.ReturnProductPointsText());
        }
        #endregion


        [StepDefinition(@"I press Complete Registration")]
        public void WhenIPressCompleteRegistration()
        {
            installerRegistrationPage.ClickCompleteRegistrationButton();
        }

        [When(@"I click on ogp back button")]
        public void WhenIClickOnOgpBackButton()
        {
            installerRegistrationPage.ClickOgpBackButton();
        }

        [Then(@"I should see combi product image")]
        public void ThenIShouldSeeCombiProductImage()
        {
            Assert.IsTrue(installerRegistrationPage.ReturnCombiProductImage());
        }

        [Then(@"I should see combi product title")]
        public void ThenIShouldSeeCombiProductTitle()
        {
            Assert.IsNotEmpty(installerRegistrationPage.ReturnCombiProductTitleText());
        }

        [Then(@"I should see added combi product image")]
        public void ThenIShouldSeeAddedCombiProductImage()
        {
            Assert.IsTrue(installerRegistrationPage.ReturnCombiAddedProductImage());
        }

        [Then(@"I should see added combi product title")]
        public void ThenIShouldSeeAddedCombiProductTitle()
        {
            Assert.IsNotEmpty(installerRegistrationPage.ReturnCombiAddedProductTitleText());
        }

        [Then(@"I should see added secondary product image and product title is indented")]
        public void ThenIShouldSeeAddedSecondaryProductImageAndProductTitleIsIndented()
        {
            Assert.IsTrue(installerRegistrationPage.ReturnSecondarProductMarginLeftPxValue().Contains("96"));
        }

        #region Thank you page
        [Then(@"I should see a successful image")]
        public void ThenIShouldSeeASuccessfulImage()
        {
            Assert.IsTrue(installerRegistrationPage.ReturnSuccessRegistrationImage());
        }

        [Then(@"I should see a successful message")]
        public void ThenIShouldSeeASuccessfulMessage()
        {
            Assert.IsTrue(installerRegistrationPage.ReturnSuccessRegistrationMessage());
        }

        [Then(@"I should be navigated to '(.*)' page with total '(.*)' points earned")]
        public void ThenIShouldBeNavigatedToPageWithTotalPointsEarned(string thankYouPage, string pointsEarned)
        {
            Assert.IsTrue(installerRegistrationPage.ReturnWindowUrl().Contains(thankYouPage) && installerRegistrationPage.ReturnWindowUrl().Contains(pointsEarned));
        }

        [Then(@"I should see '(.*)' promo boxes")]
        public void ThenIShouldSeePromoBoxes(int promoBoxesCount)
        {
            Assert.AreEqual(promoBoxesCount, installerRegistrationPage.ReturnPromoComponentListCount());
        }

        [Then(@"I should see Parts warranty plan box section with header, content text, button and '(.*)' border color")]
        public void ThenIShouldSeePartsWarrantyPlanBoxSection(string borderColor)
        {
            Assert.Multiple(() =>
            {
                Assert.IsNotEmpty(installerRegistrationPage.ReturnPartsWarrantyPlanHeaderText());
                Assert.IsNotEmpty(installerRegistrationPage.ReturnPartsWarrantyPlanContentText());
                Assert.IsNotEmpty(installerRegistrationPage.ReturnPartsWarrantyPlanButtonText());
                Assert.IsTrue(installerRegistrationPage.ReturnPartsWarrantyPlanButtonBorderBottomColor().Contains(borderColor));
                Assert.IsTrue(installerRegistrationPage.ReturnPartsWarrantyPlanButtonBorderLeftColor().Contains(borderColor));
                Assert.IsTrue(installerRegistrationPage.ReturnPartsWarrantyPlanButtonBorderRightColor().Contains(borderColor));
                Assert.IsTrue(installerRegistrationPage.ReturnPartsWarrantyPlanButtonBorderTopColor().Contains(borderColor));
            });
        }


        [Then(@"I should see '(.*)' in updated points box section and with header, content text, button and with '(.*)' font color and '(.*)' background color")]
        public void ThenIShouldSeeInUpdatedPointsBoxSection(string points, string fontColor, string backgroundColor)
        {
            Assert.Multiple(() =>
            {
                Assert.IsNotEmpty(installerRegistrationPage.ReturnPointsUpdatedHeaderText());
                Assert.IsNotEmpty(installerRegistrationPage.ReturnPointsUpdatedContentText());
                Assert.AreEqual(points, installerRegistrationPage.ReturnPointsUpdatedButtonText());
                Assert.IsTrue(installerRegistrationPage.ReturnPointsUpdatedButtonFontColor().Contains(fontColor));
                Assert.IsTrue(installerRegistrationPage.ReturnPointsUpdatedButtonBackgroundColor().Contains(backgroundColor));
            });
        }

        [Then(@"I should see Resume box section with header, content text, button with '(.*)' box background color, '(.*)' header text font color, '(.*)' content font color, download button '(.*)' text color and download button background color '(.*)' background color")]
        public void ThenIShouldSeeResumeBoxSectionWithHeaderContentTextButtonWithBoxBackgroundColorHeaderTextFontColorContentFontColorDownloadButtonTextColorAndDownloadButtonBackgroundColorBackgroundColor(string boxItemColor, string headerTextFontColor, string contentTextFontColor, string downloadButtonTextFontColor, string downloadButtonTextBackgroundColor)
        {
            Assert.Multiple(() =>
            {
                Assert.IsNotEmpty(installerRegistrationPage.ReturnResumeHeaderText());
                Assert.IsNotEmpty(installerRegistrationPage.ReturnResumeContentText());
                Assert.IsNotEmpty(installerRegistrationPage.ReturnResumeButtonText());

                Assert.IsTrue(installerRegistrationPage.ReturnDownloadResumeBorderBoxBackgroundColor().Contains(boxItemColor));
                Assert.IsTrue(installerRegistrationPage.ReturnResumeHeaderTextFontColor().Contains(headerTextFontColor));
                Assert.IsTrue(installerRegistrationPage.ReturnResumeContentTextFontColor().Contains(contentTextFontColor));
                Assert.IsTrue(installerRegistrationPage.ReturnResumeButtonTextFontColor().Contains(downloadButtonTextFontColor));
                Assert.IsTrue(installerRegistrationPage.ReturnResumeButtonTextBackgroundColor().Contains(downloadButtonTextBackgroundColor));
            });
        }

        [Then(@"I should see New registration box section with header, content text, button with '(.*)' box background color, '(.*)' header text font color, '(.*)' content font color, download button '(.*)' text color and download button background color '(.*)' background color")]
        public void ThenIShouldSeeNewRegistrationBoxSectionWithHeaderContentTextButtonWithBoxBackgroundColorHeaderTextFontColorContentFontColorDownloadButtonTextColorAndDownloadButtonBackgroundColorBackgroundColor(string boxItemColor, string headerTextFontColor, string contentTextFontColor, string downloadButtonTextFontColor, string downloadButtonTextBackgroundColor)
        {
            Assert.IsNotEmpty(installerRegistrationPage.ReturnNeRegistrationHeaderText());
            Assert.IsNotEmpty(installerRegistrationPage.ReturnNeRegistrationContentText());
            Assert.IsNotEmpty(installerRegistrationPage.ReturnNeRegistrationButtonText());

            Assert.IsTrue(installerRegistrationPage.ReturnStartNowesumeBoxBackgroundColor().Contains(boxItemColor));
            Assert.IsTrue(installerRegistrationPage.ReturnNewRegistrationHeaderTextFontColor().Contains(headerTextFontColor));
            Assert.IsTrue(installerRegistrationPage.ReturnReturnNewRegistrationContentTextFontColor().Contains(contentTextFontColor));
            Assert.IsTrue(installerRegistrationPage.ReturnReturnNewRegistrationButtonTextFontColor().Contains(downloadButtonTextFontColor));
            Assert.IsTrue(installerRegistrationPage.ReturnReturnNewRegistrationTextBackgroundColor().Contains(downloadButtonTextBackgroundColor));
        }


        #endregion

        [StepDefinition(@"I press on Arrange And Finalize OGP")]
        public void WhenIPressOnArrangeAndFinalizeOGP()
        {
            installerRegistrationPage.ClickOnArrangeAndFinalizeOGPButton();
        }

        #region Instillation Date

        [When(@"I have entered '(.*)' instillation date")]
        public void WhenIHaveEnteredInstillationDate(string installationDate)
        {
            installerRegistrationPage.SelectInstallationDate(installationDate);
        }

        [Then(@"I should see the my '(.*)' cannot be selected or disabled")]
        public void ThenIShouldSeeTheMyCannotBeSelected(string installationDate)
        {
            Assert.IsTrue(installerRegistrationPage.ReturnInstillationSelectDayIsDisabled(installationDate).Contains("rdrDayDisabled"));
        }


        [Then(@"I should see the '(.*)' as my selected date")]
        public void ThenIShouldTheAsMySelectedDate(string expectedDate)
        {
            var expectedDateInDutch = installerRegistrationPage.ReturnConvertedDutchInstillationDate(expectedDate);
            var actualDate = installerRegistrationPage.ReturnSelectedInstillationDate().ToUpper();
            Assert.IsTrue(actualDate.Contains(expectedDateInDutch));
        }

        [Then(@"I should see that the default date is '(.*)'")]
        public void ThenIShouldSeeThatTheDefaultDateIs(string expectedDate)
        {
            var expectedDateInDutch = installerRegistrationPage.ReturnConvertedDutchInstillationDate(expectedDate);
            var actualDate = installerRegistrationPage.ReturnSelectedInstillationDate().ToUpper();
            Assert.IsTrue(actualDate.Contains(expectedDateInDutch));
        }

        #endregion

        #region Address
        [When(@"I have entered '(.*)' postal code and '(.*)' house number")]
        public void WhenIHaveEnteredPostalCodeAndHouseNumber(string postCode, string houseNumber)
        {
            installerRegistrationPage.EnterPostalCodeAndHouseNumber(postCode, houseNumber);
        }

        [Then(@"I should see '(.*)' border bottom color for postal code and house number")]
        public void ThenIShouldSeeBorderBottomColorForPostalCode(string expectedColor)
        {
            Assert.Multiple(() =>
            {
                Assert.IsTrue(installerRegistrationPage.ReturnPostalCodeBorderBottomColor().Contains(expectedColor));
                Assert.IsTrue(installerRegistrationPage.ReturnHouseNumberBorderBottomColor().Contains(expectedColor));
            });
        }

        [Then(@"I should see '(.*)' font family for success message")]
        public void ThenIShouldSeeFontFamilyForSuccessMessage(string expectedFontFamily)
        {
            Assert.IsTrue(installerRegistrationPage.ReturnAddressSuccessMessageVerifyFontFamily().Contains(expectedFontFamily));
        }


        [Then(@"I should see '(.*)' register address success message")]
        public void ThenIShouldSeeRegsiterAddressSuccessMessage(string expectedMessage)
        {
            Assert.AreEqual(expectedMessage, installerRegistrationPage.ReturnRegisterAddressSuccessMessage());
        }

        [Then(@"I should see '(.*)' error message")]
        public void ThenIShouldSeeErrorMessage(string expectedErrorMessage)
        {
            Assert.AreEqual(expectedErrorMessage, installerRegistrationPage.ReturnRegisterAddressErrorMessage());
        }

        [Then(@"I should see '(.*)' font family for error message")]
        public void ThenIShouldSeeFontFamilyForErrorMessage(string expectedErrorMessageFontFamily)
        {
            Assert.IsTrue(installerRegistrationPage.ReturnAddressErrorMessageVerifyFontFamily().Contains(expectedErrorMessageFontFamily));
        }

        [Then(@"I should see a '(.*)' placeholder value for  postal code input field")]
        public void ThenIShouldSeeAPlaceholderValueForPostalCodeInputField(string placeholderValue)
        {
            Assert.AreEqual(placeholderValue, installerRegistrationPage.ReturnPostCodeInputPlaceholderValue());
        }

        [Then(@"I should see a '(.*)' placeholder value for house number input field")]
        public void ThenIShouldSeeAPlaceholderValueForHouseNumberInputField(string placeholderValue)
        {
            Assert.AreEqual(placeholderValue, installerRegistrationPage.ReturnHouseNumberInputPlaceholderValue());
        }

        #endregion

        #region Project switch
        [Then(@"I should see that the '(.*)' is the default project with '(.*)' background color")]
        public void ThenIShouldSeeThatTheIsTheDefaultProjectWithBackgroundColor(string projectVal, string backgroundColor)
        {

            Assert.Multiple(() =>
            {
                Assert.AreEqual(projectVal, installerRegistrationPage.ReturnDefaultSelectedProjectSwitch());
                Assert.IsTrue(installerRegistrationPage.ReturnProjectSwitchBackgroundColor().Contains(backgroundColor));
            });
        }

        [Then(@"I should see the '(.*)' is displayed")]
        public void ThenIShouldSeeTheIsDisplayed(string textLink)
        {
            Assert.AreEqual(textLink, installerRegistrationPage.ReturnProjectSwitchWhatDoesThisMeanLink());
        }

        [When(@"I switch to project '(.*)'")]
        public void WhenISwitchToProject(string projectVal)
        {
            installerRegistrationPage.SelectProject(projectVal);
        }

        [Then(@"I should see a '(.*)' placeholder value for project Id input field")]
        public void ThenIShouldSeeAPlaceholderValue(string placeHolderValue)
        {
            Assert.AreEqual(placeHolderValue, installerRegistrationPage.ReturnProjectIdPlaceholderValue());
        }


        [StepDefinition(@"I select '(.*)' project name")]
        public void WhenISelectProjectName(string id)
        {
            installerRegistrationPage.EnterProjectId(id);
        }

        [Then(@"I should see '(.*)' border bottom color for project id field")]
        public void ThenIShouldSeeBorderBottomColorForProjectIdField(string expectedColor)
        {
            Assert.IsTrue(installerRegistrationPage.ReturnProjectIdInputBorderBottomColor().Contains(expectedColor));
        }

        [Then(@"I should see '(.*)' project id success message with '(.*)' font color")]
        public void ThenIShouldSeeProjectIdSuccessMessage(string message, string fontColor)
        {

            Assert.Multiple(() =>
            {
                Assert.AreEqual(message, installerRegistrationPage.ReturnProjectIdSuccessMessage());
                Assert.IsTrue(installerRegistrationPage.ReturnProjectIdSuccessMessageFontColor().Contains(fontColor));
            });
        }

        [Then(@"I should see select project button is displayed with '(.*)' background color")]
        public void ThenIShouldSeeSelectProjectButtonIsDisplayedWithBackgroundColor(string backroundColor)
        {
            Assert.Multiple(() =>
            {
                Assert.IsTrue(installerRegistrationPage.ReturnSelectProjectButtonIsDisplayed());
                Assert.IsTrue(installerRegistrationPage.ReturnSelectProjectButtonBackgroundColor().Contains(backroundColor));
            });
        }

        [Then(@"I should see '(.*)' project id error message with '(.*)' font color")]
        public void ThenIShouldSeeProjectIdErrorMessage(string message, string fontColor)
        {
            Assert.Multiple(() =>
            {
                Assert.AreEqual(message, installerRegistrationPage.ReturnProjectIdErrorMessage());
                Assert.IsTrue(installerRegistrationPage.ReturnProjectIdErrorMessageFontColor().Contains(fontColor));
            });
        }

        [Then(@"I should not see project Id Input and select project button")]
        public void ThenIShouldNotSeeProjectIdInputAndSelectProjectButton()
        {
            Assert.Multiple(() =>
            {
                Assert.IsNull(installerRegistrationPage.ReturnProjectIdInputIsDisplayed());
                Assert.IsNull(installerRegistrationPage.ReturnSelectProjectIdIsDisplayed());
            });
        }

        [Then(@"I should see product points of added product has been '(.*)'")]
        public void ThenIShouldSeeLoyaltyPointsOfAddedProductHasBeen(string val)
        {
            Assert.IsTrue(installerRegistrationPage.ReturnProductPointsLoyaltyClassValue().Contains(val));
        }

        [Then(@"I should see all product points has been '(.*)'")]
        public void ThenIShouldSeeAllProductPointsHasBeen(string val)
        {
            var productsPoints = installerRegistrationPage.ReturnAllProductPointsLoyaltyClassValue();

            Assert.Multiple(() =>
            {
                Assert.IsTrue(productsPoints[0].Contains(val));
                Assert.IsTrue(productsPoints[1].Contains(val));
                Assert.IsTrue(productsPoints[2].Contains(val));
            });
        }


        [Then(@"I should see '(.*)' product points has been added back again")]
        [Then(@"I should see '(.*)' product points has been added")]
        public void ThenIShouldSeeLoyaltyPointsHasBeenAdded(string val)
        {
            Assert.IsFalse(installerRegistrationPage.ReturnProductPointsLoyaltyClassValue().Contains(val));
        }
        [Then(@"I should see '(.*)', '(.*)' and '(.*)' product points respectively")]
        public void ThenIShouldSeeAndXproductPointsRespectively(string prod1, string prod2, string prod3)
        {
            var productsPoints = installerRegistrationPage.ReturnAllProductPointsLoyaltyText();

            Assert.Multiple(() =>
            {
                Assert.AreEqual(prod1, productsPoints[0]);
                Assert.AreEqual(prod2, productsPoints[1]);
                Assert.AreEqual(prod3, productsPoints[2]);
            });
        }
        #endregion

        #region Header
        [Then(@"I should see the main header background color is '(.*)'")]
        public void ThenIShouldSeeTheMainHeaderBackgroundColorIs(string backgroundColor)
        {
            Assert.IsTrue(installerRegistrationPage.ReturnMainHeaderBackgroundColor().Contains(backgroundColor));
        }

        [Then(@"I should see the back link is displayed in the header section")]
        public void ThenIShouldSeeTheBackLinkIsDisplayedInTheHeaderSection()
        {
            Assert.IsNotEmpty(installerRegistrationPage.ReturnHeaderBackLinkText());
        }

        [Then(@"I should see the profile messages link is displayed in the header section")]
        public void ThenIShouldSeeTheProfileMessagesLinkIsDisplayedInTheHeaderSection()
        {
            Assert.IsNotEmpty(installerRegistrationPage.ReturnProfileMessagesLinkText());
        }

        [Then(@"I should see the profile name link is displayed in the header section")]
        public void ThenIShouldSeeTheProfileNameLinkIsDisplayedInTheHeaderSection()
        {
            Assert.IsNotEmpty(installerRegistrationPage.ReturnProfileNameLinkText());
        }

        [Then(@"I should see the remeha logo is displayed in the header section")]
        public void ThenIShouldSeeTheRemehaLogoIsDisplayedInTheHeaderSection()
        {
            Assert.IsTrue(installerRegistrationPage.ReturnRemehaLogoIsDisplayed());
        }

        [Then(@"I should see the Product Registration menu is displayed in the header section with '(.*)' background color")]
        public void ThenIShouldSeeTheProductRegistrationMenuIsDisplayedInTheHeaderSection(string backgroundColor)
        {
            Assert.Multiple(() =>
            {
                Assert.IsNotEmpty(installerRegistrationPage.ReturnProductRegistrationMenuText());
                Assert.IsTrue(installerRegistrationPage.ReturnProductRegistrationMenuBackgroundColor().Contains(backgroundColor));
            });
        }

        [Then(@"I should see the OGP menu is displayed in the header section")]
        public void ThenIShouldSeeTheOGPMenuIsDisplayedInTheHeaderSection()
        {
            Assert.IsNotEmpty(installerRegistrationPage.ReturnOgpMenuText());
        }

        [Then(@"I should see the Customer menu is displayed in the header section")]
        public void ThenIShouldSeeTheCustomerMenuIsDisplayedInTheHeaderSection()
        {
            Assert.IsNotEmpty(installerRegistrationPage.ReturnCustomerSubMenuText());
        }

        [Then(@"I should see the Training menu is displayed in the header section")]
        public void ThenIShouldSeeTheTrainingMenuIsDisplayedInTheHeaderSection()
        {
            Assert.IsNotEmpty(installerRegistrationPage.ReturnTrainingSubMenuText());
        }

        [Then(@"I should see the Service menu is displayed in the header section")]
        public void ThenIShouldSeeTheServiceMenuIsDisplayedInTheHeaderSection()
        {
            Assert.IsNotEmpty(installerRegistrationPage.ReturnServiceSubMenuText());
        }

        [Then(@"I should see the Actions menu is displayed in the header section")]
        public void ThenIShouldSeeTheActionsMenuIsDisplayedInTheHeaderSection()
        {
            Assert.IsNotEmpty(installerRegistrationPage.ReturnActionsSubMenuText());
        }

        [Then(@"I should see the Help menu is displayed in the header section")]
        public void ThenIShouldSeeTheHelpMenuIsDisplayedInTheHeaderSection()
        {
            Assert.IsNotEmpty(installerRegistrationPage.ReturnHelpSubMenuText());
        }

        [Then(@"I should see the Shop link is displayed in the header section")]
        public void ThenIShouldSeeTheShopLinkIsDisplayedInTheHeaderSection()
        {
            Assert.IsNotEmpty(installerRegistrationPage.ReturnShopMenuLinkMenuText());
        }

        [Then(@"I should see the Shopping cart icon is displayed in the header section")]
        public void ThenIShouldSeeTheShoppingCartIconIsDisplayedInTheHeaderSection()
        {
            Assert.IsNotNull(installerRegistrationPage.ReturnShoppingCartIconIsDisplayed());
        }

        [Then(@"I should see the Account points is displayed in the header section")]
        public void ThenIShouldSeeTheAccountPointsIsDisplayedInTheHeaderSection()
        {
            Assert.IsNotEmpty(installerRegistrationPage.ReturnAccountPointsText());
        }

        [Then(@"I should see the footer is displayed with background color is '(.*)'")]
        public void ThenIShouldSeeTheFooterIsDisplayedWithBackgroundColorIs(string color)
        {
            Assert.Multiple(() =>
            {
                Assert.IsTrue(installerRegistrationPage.ReturnFooterIsDisplayed());
                Assert.IsTrue(installerRegistrationPage.ReturnFooterBackgroundColor().Contains(color));
            });
        }

        [Then(@"I should see the remeha logo is displayed in the footer section")]
        public void ThenIShouldSeeTheRemehaLogoIsDisplayedInTheFooterSection()
        {
            Assert.IsTrue(installerRegistrationPage.ReturnFooterRemehaLogoWhiteIsDisplayed());
        }

        [Then(@"I should see the Terms Of Use is displayed in the footer section")]
        public void ThenIShouldSeeTheTermsOfUseIsDisplayedInTheHeaderSection()
        {
            Assert.IsNotEmpty(installerRegistrationPage.ReturnTermsOfUseText());
        }

        [Then(@"I should see the CookiesAndPrivacyPolicy is displayed in the footer section")]
        public void ThenIShouldSeeTheCookiesAndPrivacyPolicyIsDisplayedInTheHeaderSection()
        {
            Assert.IsNotEmpty(installerRegistrationPage.ReturnCookiesAndPrivacyPolicyText());
        }

        [Then(@"I should see the Company Information is displayed in the footer section")]
        public void ThenIShouldSeeTheCompanyInformationIsDisplayedInTheHeaderSection()
        {
            Assert.IsNotEmpty(installerRegistrationPage.ReturnCompanyInformationText());
        }

        [Then(@"I should see the Company trade mark is displayed in the footer section")]
        public void ThenIShouldSeeTheCompanyTradeMarkIsDisplayedInTheFooterSection()
        {
            Assert.IsNotEmpty(installerRegistrationPage.ReturnTradeMarkText());
        }

        #endregion

        #region Customer Data
        [Then(@"I should see the Do you have additional information about your customer\? text message")]
        public void ThenIShouldSeeTheDoYouHaveAdditionalInformationAboutYourCustomerTextMessage()
        {
            Assert.IsNotEmpty(installerRegistrationPage.ReturnCustomerDateHeaderTitleText());
        }

        [Then(@"I should see that the '(.*)' is the customer data answer with '(.*)' background color")]
        public void ThenIShouldSeeThatTheIsTheCustomerDataAnswerWithBackgroundColor(string answer, string backgroundColor)
        {
            Assert.Multiple(() =>
            {
                Assert.AreEqual(answer, installerRegistrationPage.ReturnCustomerDateAdditionalInforAnswerText());
                Assert.IsTrue(installerRegistrationPage.ReturnCustomerDateAdditionalInforAnswerBackgroundColor().Contains(backgroundColor));
            });
        }

        [Then(@"I should see the Salutation label is displayed and has '(.*)' class value")]
        public void ThenIShouldSeeTheSalutationLabelIsDisplayedAndHasClassValue(string val)
        {
            Assert.AreEqual(val, installerRegistrationPage.ReturnCustomerDataSalutationClassValue());
        }

        [Then(@"I should see the Mr label is displayed")]
        public void ThenIShouldSeeTheMrLabelIsDisplayed()
        {
            Assert.IsNotEmpty(installerRegistrationPage.ReturnCustomerDataMrLabelText());
        }

        [Then(@"I should see the Mrs label is displayed")]
        public void ThenIShouldSeeTheMrsLabelIsDisplayed()
        {
            Assert.IsNotEmpty(installerRegistrationPage.ReturnCustomerDataMrsLabelText());
        }

        [Then(@"I should see the First Name label is displayed")]
        public void ThenIShouldSeeTheFirstNameLabelIsDisplayed()
        {
            Assert.IsNotEmpty(installerRegistrationPage.ReturnCustomerDataFirstNameLabelText());
        }

        [Then(@"I should see the Last Name label is displayed")]
        public void ThenIShouldSeeTheLastNameLabelIsDisplayed()
        {
            Assert.IsNotEmpty(installerRegistrationPage.ReturnCustomerDataLastNameLabelText());
        }

        [Then(@"I should see a placeholder value for First Name input")]
        public void ThenIShouldSeeAPlaceholderValueForFirstNameInput()
        {
            Assert.IsNotEmpty(installerRegistrationPage.ReturnCustomerDataFirstNameInputPlacholderValue());
        }

        [Then(@"I should see a placeholder value for Last Name input")]
        public void ThenIShouldSeeAPlaceholderValueForLastNameInput()
        {
            Assert.IsNotEmpty(installerRegistrationPage.ReturnCustomerDataLastNameInputPlacholderValue());
        }

        [Then(@"I should see the Telephone number label is displayed")]
        public void ThenIShouldSeeTheTelephoneNumberLabelIsDisplayed()
        {
            Assert.IsNotEmpty(installerRegistrationPage.ReturnCustomerDataTelephoneNumberLabelText());
        }

        [Then(@"I should see a '(.*)' value for phonenumber input")]
        public void ThenIShouldSeeAValueForPhonenumberInput(string val)
        {
            Assert.AreEqual(val, installerRegistrationPage.RetrunCustomerDataTelephoneNumberInputPlacholderValue());
        }

        [Then(@"I should see the Email Address label is displayed")]
        public void ThenIShouldSeeTheEmailAddressLabelIsDisplayed()
        {
            Assert.IsNotEmpty(installerRegistrationPage.ReturnCustomerDataEmailAddressLabelText());
        }

        [Then(@"I should see that the '(.*)' is the default email address answer with '(.*)' background color")]
        public void ThenIShouldSeeThatTheIsTheDefaultAnswerWithBackgroundColor(string answer, string backgroundColor)
        {
            Assert.Multiple(() =>
            {
                Assert.AreEqual(answer, installerRegistrationPage.ReturnCustomerDataEmailAddressAnswersText());
                Assert.IsTrue(installerRegistrationPage.ReturnCustomerDataEmailAddressAnswersBackgroundColor().Contains(backgroundColor));
            });
        }

        [When(@"I answer '(.*)' to email address field")]
        public void WhenIAnswerToEmailAddressField(string answerVal)
        {
            installerRegistrationPage.SelecToAnswerEmailAddressInformation(answerVal);
        }

        [Then(@"I should see a '(.*)' placeholder value for email address input")]
        public void ThenIShouldSeeAPlaceholderValueForEmailAddressInput(string val)
        {
            Assert.AreEqual(val, installerRegistrationPage.RetrunCustomerDataEmailAddressInputPlacholderValue());
        }

        [Then(@"I should see disclaimer E-mail information how it will be used")]
        public void ThenIShouldSeeE_MailInformationHowItWillBeUsed()
        {
            Assert.IsNotEmpty(installerRegistrationPage.ReturnCustomerDataEmailAddressSubNoteText());
        }

        [When(@"I answer back again to '(.*)' to the customer data additional question")]
        [When(@"I answer '(.*)' to the customer data additional question")]
        public void WhenIAnswerToTheCustomerDataAdditionalQuestion(string anwser)
        {
            installerRegistrationPage.SelectAdditionalCustomerDataInformation(anwser);
        }

        [When(@"I enter '(.*)' salutation, '(.*)' first name, '(.*)' last name, '(.*)' telephone number and '(.*)' email address")]
        public void WhenIEnterSalutationFirstNameLastNameTelephoneNumberAndEmailAddress(string salutationValue, string firstName, string lastName, string telephoneNumber, string emailAddress)
        {
            // select salutation
            installerRegistrationPage.SelectSalutation(salutationValue);

            // enter first name and last name
            installerRegistrationPage.EnterCustomerDataFirstName(firstName);
            installerRegistrationPage.EnterCustomerDataLastName(lastName);

            // enter telephone number
            installerRegistrationPage.EnterTelephoneNumber(telephoneNumber);

            // enter email address
            installerRegistrationPage.SelecToAnswerEmailAddressInformation("Ja");
            installerRegistrationPage.EnterEmailAddress(emailAddress);
        }


        [Then(@"I should not see the customer data form")]
        public void ThenIShouldNotSeeTheCustomerDataForm()
        {
            Assert.IsNull(installerRegistrationPage.ReturnCustomerDateContainerInputSelectorIsDisplayed());
        }

        [Then(@"I should see the customer data form")]
        public void ThenIShouldSeeTheCustomerDataForm()
        {
            Assert.IsNotNull(installerRegistrationPage.ReturnCustomerDateContainerInputSelectorIsDisplayed());
        }

        [When(@"I have entered '(.*)' telephone number")]
        public void WhenIHaveEnteredTelephoneNumber(string number)
        {
            installerRegistrationPage.EnterTelephoneNumber(number);
        }

        [Then(@"I should see '(.*)' border bottom color for telephone number input field")]
        public void ThenIShouldSeeBorderBottomColorForTelephoneNumberInputField(string color)
        {
            Assert.IsTrue(installerRegistrationPage.ReturnCustomerDataTelephoneNumberBorderBottomColor().Contains(color));
        }

        [Then(@"I should see invalid telephone format error message with '(.*)' font color")]
        public void ThenIShouldSeeInvalidTelephoneFormatErrorMessageWithFontColor(string fontColor)
        {
            Assert.Multiple(() =>
            {
                Assert.IsNotEmpty(installerRegistrationPage.ReturnCustomerDataTelephoneNumberErrorMessageErrorMessageText());
                Assert.IsTrue(installerRegistrationPage.ReturnCustomerDataTelephoneNumberErrorMessageErrorMessageTextFontColor().Contains(fontColor));
            });
        }

        [Then(@"I should I should see success styling")]
        public void ThenIShouldIShouldSeeSuccessStyling()
        {
            Assert.Multiple(() =>
            {
                Assert.IsTrue(installerRegistrationPage.ReturnCustomerDataEmailAddressInputClassValue().Contains("has-default success"));
                Assert.IsNull(installerRegistrationPage.ReturnCustomerDataEmailAddressErrorMessageIsDisplayed());
            });
        }

        [When(@"I have entered '(.*)' email address")]
        public void WhenIHaveEnteredEmailAddress(string emailAdd)
        {
            installerRegistrationPage.SelecToAnswerEmailAddressInformation("Ja");
            installerRegistrationPage.EnterEmailAddress(emailAdd);
        }

        [Then(@"I should I should see error styling")]
        public void ThenIShouldIShouldSeeErrorStyling()
        {
            Assert.Multiple(() =>
            {
                Assert.IsTrue(installerRegistrationPage.ReturnCustomerDataEmailAddressInputClassValue().Contains("has-default error"));
                Assert.IsNotNull(installerRegistrationPage.ReturnCustomerDataEmailAddressErrorMessageIsDisplayed());
            });
        }

        [Then(@"I should see that this is an invalid email address error message")]
        public void ThenIShouldSeeThatThisIsAnInvalidEmailAddressErrorMessage()
        {
            Assert.IsNotEmpty(installerRegistrationPage.ReturnCustomerDataEmailAddressErrorMessageText());
        }

        [Then(@"I should see that all of the customer data additional form fields are empty")]
        public void ThenIShouldSeeThatAllOfTheCustomerDataAdditionalFormFieldsAreEmpty()
        {
            installerRegistrationPage.SelecToAnswerEmailAddressInformation("Ja");

            Assert.Multiple(() =>
            {
                Assert.IsEmpty(installerRegistrationPage.ReturnCustomerDataFirstNameInputText());
                Assert.IsEmpty(installerRegistrationPage.ReturnCustomerDataLastNameInputText());
                Assert.IsEmpty(installerRegistrationPage.ReturnCustomerDataTelephoneNumberInputText());
                Assert.IsEmpty(installerRegistrationPage.ReturnCustomerDataEmailAddressInputText());
            });
        }

        #endregion

        #region OGP

        [Then(@"I should be on Arrange your Parts Warranty Plan immediately section")]
        public void ThenIShouldBeOnArrangeYourPartsWarrantyPlanImmediatelySection()
        {
            Assert.IsTrue(installerRegistrationPage.ReturnSelectOGPElement());
        }

        [When(@"I select '(.*)' OGP")]
        public void WhenISelectOGP(string ogpValue)
        {
            installerRegistrationPage.SelecOGP(ogpValue);
        }

        [When(@"I select multiple OGP")]
        public void WhenISelectMultipleOGP(Table table)
        {
            //var PartsWarrantyPlanList = table.CreateSet<InstallerProduct>();
            //foreach (InstallerProduct warrantPlan in PartsWarrantyPlanList)
            //{
            //    installerRegistrationPage.SelecMultipleOGP(warrantPlan.ProductItemNumber, warrantPlan.PartsWarrantyPlan);
            //}
        }

        [Then(@"I should not see the Arrange & complete OGP button")]
        public void ThenIShouldNotSeeTheArrangeCompleteOGPButton()
        {
            Assert.IsFalse(installerRegistrationPage.ReturnArrangeAndFinalizeOGPButtonIsDisplayed());
        }

        [Then(@"I should see the Arrange your Parts Warranty Plan immediately header text")]
        public void ThenIShouldSeeTheArrangeYourPartsWarrantyPlanImmediatelyHeaderText()
        {
            Assert.IsNotEmpty(installerRegistrationPage.ReturnArrangeYourPartsWarrantyPlanImmediatelyHeaderText());
        }

        [Then(@"I should see product title in OGP section")]
        public void ThenIShouldSeeProductTitleInOGPSection()
        {
            Assert.IsNotEmpty(installerRegistrationPage.ReturnOgpSectionProductAddedTitleText());
        }

        [Then(@"I should see product image in OGP section")]
        public void ThenIShouldSeeProductImageInOGPSection()
        {
            Assert.IsTrue(installerRegistrationPage.ReturnOgpSectionProductAddedImageIsDisplayed());
        }

        [Then(@"I should see product '(.*)' serial number in OGP section")]
        public void ThenIShouldSeeProductSerialNumberInOGPSection(string serialNumber)
        {
            Assert.AreEqual(serialNumber, installerRegistrationPage.ReturnOgpSectionProductSerialNumberText());
        }

        [Then(@"I should see product loyalty points in OGP section with '(.*)' font color")]
        public void ThenIShouldSeeProductLoyaltyPointsInOGPSectionWithFontColor(string color)
        {
            Assert.Multiple(() =>
            {
                Assert.IsNotEmpty(installerRegistrationPage.ReturnOgpSectionProductAdddedLoytalPointsText());
                Assert.IsTrue(installerRegistrationPage.ReturnOgpSectionProductAdddedLoytalPointsFontColor().Contains(color));
            });
        }

        [Then(@"I should see parts warranty plan label in OGP section")]
        public void ThenIShouldSeePartsWarrantyPlanLabelInOGPSection()
        {
            Assert.IsNotEmpty(installerRegistrationPage.ReturnOgpSectionPartsWarrantyPlanLabelText());
        }

        [Then(@"I should see no OGP selected yet label in OGP section")]
        public void ThenIShouldSeeNoOGPSelectedYetLabelInOGPSection()
        {
            Assert.IsNotEmpty(installerRegistrationPage.ReturnNoOgpSelectedYetLabelText());
        }

        [Then(@"I should see back button in OGP section")]
        public void ThenIShouldSeeBackButtonInOGPSection()
        {
            Assert.IsNotEmpty(installerRegistrationPage.ReturnOgpBackButtonText());
        }

        [Then(@"I should not see product loyalty points in OGP section")]
        public void ThenIShouldNotSeeProductLoyaltyPointsInOGPSection()
        {
            Assert.IsNull(installerRegistrationPage.ReturnOgpSectionProductAddedLoytalPointsSelectorIsDisplayed());
        }

        [Then(@"I should see thank you header with '(.*)' border top color")]
        public void ThenIShouldSeeThankYouHeaderWithBorderTopColor(string color)
        {
            Assert.IsTrue(installerRegistrationPage.ReturnThankYouHeaderBorderTopColor().Contains(color));
        }

        #endregion
    }
}
