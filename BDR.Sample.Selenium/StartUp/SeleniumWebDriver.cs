using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Remote;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace BDR.Sample.Selenium.StartUp
{
    [Binding]
    public class SeleniumWebDriver
    {
        private static RemoteWebDriver webDriver;
        private static Boolean flagDriverIsUsed = false;

        ////Global Variable for Extend report
        //public static ExtentTest featureName;
        //public static ExtentTest scenario;
        //public static ExtentReports extent;

        [BeforeTestRun]
        public static void Setup()
        {
            ////Initialize Extent report before test starts
            //extent = new ExtentReports();

            //var dir = AppDomain.CurrentDomain.BaseDirectory.Replace("\\bin\\Debug", "");
            //DirectoryInfo di = Directory.CreateDirectory(dir + "\\Test_Execution_Reports");
            //var htmlReporter = new ExtentHtmlReporter(dir + "\\Test_Execution_Reports" + "\\Automation_Report" + "InstallaerPortalStatus.html");
            //htmlReporter.Config.Theme = AventStack.ExtentReports.Reporter.Configuration.Theme.Standard;
            //extent.AddSystemInfo("Environment", "Journey of Quality");
            //extent.AddSystemInfo("User Name", "Vincent Soriyao");

            ////Attach report to reporter
            //extent.AttachReporter(htmlReporter);

            var remoteWebDriverUrl = string.Format(ConfigurationManager.AppSettings["RemoteWebDriverUrl"]);

            if (!flagDriverIsUsed)
            {
                var browserSettings = "Chrome";
                //var remoteWebDriverUrl = "http://127.0.0.1:4444/wd/hub";
                //zalenium not working
                //var remoteWebDriverUrl = "http://172.17.0.2:4445/wd/hub";
                //var remoteWebDriverUrl = "http://localhost:4444/wd/hub";
                //var remoteWebDriverUrl = "http://10.0.75.1:8080/wd/hub";
                //var remoteWebDriverUrl = "http://127.0.0.1:4445/wd/hub";
                //http://10.0.75.1:8080
                switch (@browserSettings)
                {
                    case "Chrome":
                        //webDriver = new ChromeDriver(@"C:\Selenium\Selenium\demoDrivers\2.45");

                        var chromeOptions = new ChromeOptions();
                        chromeOptions.AddArgument("--start-maximized"); // Maximize browser window when opened.
                        chromeOptions.AddArgument("--disable-infobars");
                        chromeOptions.AddArgument("--no-sandbox"); // Deal with binary.
                        //options.AddArgument("--headless");
                        //chromeOptions.AddArgument("--fullscreen"); // F11.

                        //chromeOptions.AddArgument("--window-size=1920,1080");
                        //driver = Chrome(chrome_options = chrome_options)

                        //DesiredCapabilities descap = options.ToCapabilities() as DesiredCapabilities;
                        //descap.SetCapability("maxSession", 5);
                        //descap.SetCapability("maxInstances", 5);
                        //descap.SetCapability("idleTimeout", 150);
                        webDriver = new RemoteWebDriver(new Uri(remoteWebDriverUrl), chromeOptions.ToCapabilities(), TimeSpan.FromSeconds(150));

                        //TODO: will this work
                        //webDriver.Manage().Window.Size = new System.Drawing.Size(400, 600);

                        break;
                    case "Firefox":
                        Thread.Sleep(2000);
                        FirefoxDriverService firefoxDriverService = FirefoxDriverService.CreateDefaultService(@"C:\Selenium\Driver\geckodriver");
                        firefoxDriverService.FirefoxBinaryPath = @"C:\Program Files (x86)\Mozilla Firefox\firefox.exe";
                        webDriver = new FirefoxDriver(firefoxDriverService);
                        // add to environment variables - add to path variables the location of your gecko driver
                        break;
                    case "IE":
                        //webDriver = new InternetExplorerDriver();
                        InternetExplorerOptions ieOptions = new InternetExplorerOptions();
                        ieOptions.AddAdditionalCapability("ignoreProtectedModeSettings", true);
                        ieOptions.AddAdditionalCapability("EnsureCleanSession", true);
                        webDriver = new RemoteWebDriver(new Uri("http://localhost:5555/"), ieOptions.ToCapabilities(), TimeSpan.FromSeconds(300));
                        break;
                    default:
                        webDriver = new ChromeDriver(@"C:\Selenium\Selenium\demoDrivers\2.45");
                        break;
                }

                webDriver.Manage().Cookies.DeleteAllCookies();
                webDriver.Manage().Window.Maximize();
                flagDriverIsUsed = true;
            }
        }

        //[AfterStep]
        //public static void InsertReportingSteps()
        //{

        //    var stepType = ScenarioStepContext.Current.StepInfo.StepDefinitionType.ToString();

        //PropertyInfo pInfo = typeof(ScenarioContext).GetProperty(“ScenarioExecutionStatus”, BindingFlags.Instance | BindingFlags.Public);
        //MethodInfo getter = pInfo.GetGetMethod(nonPublic: true);
        //object TestResult = getter.Invoke(ScenarioContext.Current, null);

        //    if (ScenarioContext.Current.TestError == null)
        //    {
        //        if (stepType == "Given")
        //            scenario.CreateNode<Given>(ScenarioStepContext.Current.StepInfo.Text);
        //        else if (stepType == "When")
        //            scenario.CreateNode<When>(ScenarioStepContext.Current.StepInfo.Text);
        //        else if (stepType == "Then")
        //            scenario.CreateNode<Then>(ScenarioStepContext.Current.StepInfo.Text);
        //        else if (stepType == "And")
        //            scenario.CreateNode<And>(ScenarioStepContext.Current.StepInfo.Text);
        //    }
        //    var exception = ScenarioContext.Current.TestError;
        //    if (exception is OpenQA.Selenium.WebDriverException
        //        || exception.Message.Contains("The HTTP request to the remote WebDriver server for URL "))
        //    {
        //        Assert.Inconclusive(exception.Message);
        //    }

        //    else if (ScenarioContext.Current.TestError != null)
        //    {
        //        if (stepType == "Given")
        //            scenario.CreateNode<Given>(ScenarioStepContext.Current.StepInfo.Text).Fail(ScenarioContext.Current.TestError.InnerException);
        //        else if (stepType == "When")
        //            scenario.CreateNode<When>(ScenarioStepContext.Current.StepInfo.Text).Fail(ScenarioContext.Current.TestError.InnerException);
        //        else if (stepType == "When")
        //            scenario.CreateNode<When>(ScenarioStepContext.Current.StepInfo.Text).Fail(ScenarioContext.Current.TestError.Source);
        //        else if(stepType == "When")
        //            scenario.CreateNode<When>(ScenarioStepContext.Current.StepInfo.Text).Fail(ScenarioContext.Current.TestError.Message);
        //        else if (stepType == "When")
        //            scenario.CreateNode<When>(ScenarioStepContext.Current.StepInfo.Text).Fail(ScenarioContext.Current.TestError.StackTrace);
        //        else if (stepType == "Then")
        //            scenario.CreateNode<Then>(ScenarioStepContext.Current.StepInfo.Text).Fail(ScenarioContext.Current.TestError.Message);
        //    }



        //    ////Pending Status
        //    //if (TestResult.ToString() == "StepDefinitionPending")
        //    //{
        //    //    if (stepType == "Given")
        //    //        scenario.CreateNode<Given>(ScenarioStepContext.Current.StepInfo.Text).Skip("Step Definition Pending");
        //    //    else if (stepType == "When")
        //    //        scenario.CreateNode<When>(ScenarioStepContext.Current.StepInfo.Text).Skip("Step Definition Pending");
        //    //    //else if (stepType == "And")
        //    //    //    scenario.CreateNode<When>(ScenarioStepContext.Current.StepInfo.Text).Skip("Step Definition Pending");
        //    //    else if (stepType == "Then")
        //    //        scenario.CreateNode<Then>(ScenarioStepContext.Current.StepInfo.Text).Skip("Step Definition Pending");

        //    //}
        //}

        //[AfterStep]
        //public static void AfterEveryStep(ScenarioContext scenarioContext)
        //{
        //    var stepInfo = scenarioContext.StepContext.StepInfo;
        //    var stepType = stepInfo.StepInstance.StepDefinitionType.ToString();

        //    ExtentTest stepNode = null;
        //    switch (stepType)
        //    {
        //        case "Given":
        //            //stepNode = scenario.CreateNode(stepInfo.Text);
        //            stepNode = scenario.CreateNode<When>(ScenarioStepContext.Current.StepInfo.Text);
        //            break;
        //        case "When":
        //            //stepNode = scenario.CreateNode(stepInfo.Text);
        //            stepNode = scenario.CreateNode<When>(ScenarioStepContext.Current.StepInfo.Text);
        //            break;
        //        case "Then":
        //            //stepNode = scenario.CreateNode(stepInfo.Text);
        //            stepNode = scenario.CreateNode<When>(ScenarioStepContext.Current.StepInfo.Text);
        //            break;
        //    }

        //    if (scenarioContext.ScenarioExecutionStatus != ScenarioExecutionStatus.OK)
        //    {
        //        Screenshot ss = ((ITakesScreenshot)webDriver).GetScreenshot();
        //        string screenshot = ss.AsBase64EncodedString;

        //        var failTypes = new List<ScenarioExecutionStatus> {
        //            ScenarioExecutionStatus.BindingError,
        //            ScenarioExecutionStatus.TestError,
        //            ScenarioExecutionStatus.UndefinedStep
        //        };

        //        if (scenarioContext.ScenarioExecutionStatus == ScenarioExecutionStatus.StepDefinitionPending)
        //        {
        //            //stepNode.Skip("This step has been skipped and not executed.", MediaEntityBuilder.CreateScreenCaptureFromBase64String(screenshot).Build());
        //            stepNode.Skip("This step has been skipped and not executed.");
        //        }

        //        else if (failTypes.Contains(scenarioContext.ScenarioExecutionStatus))
        //        {
        //            //stepNode.Fail(scenarioContext.TestError.Message, MediaEntityBuilder.CreateScreenCaptureFromBase64String(screenshot).Build());
        //            stepNode.Fail(scenarioContext.TestError.Message);
        //        }
        //    }
        //}

        //[BeforeScenario]
        //public static void Initialize()
        //{
        //    //Create dynamic scenario name
        //    scenario = featureName.CreateNode<Scenario>(ScenarioContext.Current.ScenarioInfo.Title);
        //}

        //[BeforeFeature]
        //public static void BeforeFeature()
        //{
        //    //Create dynamic feature name
        //    featureName = extent.CreateTest<Feature>(FeatureContext.Current.FeatureInfo.Title);
        //}

        [AfterTestRun]
        public static void TearDown()
        {
            webDriver.Quit();

            ////Flush report once test completes
            //extent.Flush();
        }

        public RemoteWebDriver GetWebDriver()
        {
            if (!flagDriverIsUsed)
            {
                Setup();
            }

            return webDriver;
        }
    }
}
