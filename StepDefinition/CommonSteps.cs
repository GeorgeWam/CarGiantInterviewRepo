using System;
using System.IO;
using TechTalk.SpecFlow;
using CarGiantProject.Hooks;
using AventStack.ExtentReports.Reporter;
using AventStack.ExtentReports;
using AventStack.ExtentReports.Gherkin.Model;
using OpenQA.Selenium;

namespace CarGiantProject.StepDefinition
{
    [Binding]
    public class CommonSteps
    {
        Context context;
        static ExtentTest feature;
        static ExtentTest scenario;
        static ExtentReports report;

        public CommonSteps(Context _context)
        {
            context = _context;
        }

        [Given(@"that the Car Giant web Application is launched")]
        public void GivenThatTheCarGiantWebApplicationIsLaunched()
        {
            context.LaunchAnAUT();
            scenario = feature.CreateNode<Scenario>(ScenarioContext.Current.ScenarioInfo.Title);
        }

        [BeforeTestRun]
        public static void ReportGenerator()
        {
            var testResultReport = new ExtentV3HtmlReporter(Directory.GetCurrentDirectory() + @"\TestResult.html");
            testResultReport.Config.Theme = AventStack.ExtentReports.Reporter.Configuration.Theme.Dark;
            report = new ExtentReports();
            report.AttachReporter(testResultReport);
        }

        [AfterTestRun]
        public static void ReportCleaner()
        {
            report.Flush();
        }

        [BeforeFeature]
        public static void BeforeFeature()
        {
            feature = report.CreateTest<Feature>(FeatureContext.Current.FeatureInfo.Title);
        }

        [AfterStep]
        public void StepsInTheReport()
        {
            var typeOfStep = ScenarioStepContext.Current.StepInfo.StepDefinitionType.ToString();
            //Cater for a step that passed
            if (ScenarioContext.Current.TestError == null)
            {
                if (typeOfStep.Equals("Given"))
                {
                    scenario.CreateNode<Given>(ScenarioStepContext.Current.StepInfo.Text);
                }
                else if (typeOfStep.Equals("When"))
                {
                    scenario.CreateNode<When>(ScenarioStepContext.Current.StepInfo.Text);
                }
                else if (typeOfStep.Equals("Then"))
                {
                    scenario.CreateNode<Then>(ScenarioStepContext.Current.StepInfo.Text);
                }
            }
            //Cater for a step that failed
            if (ScenarioContext.Current.TestError != null)
            {
                if (typeOfStep.Equals("Given"))
                {
                    scenario.CreateNode<Given>(ScenarioStepContext.Current.StepInfo.Text).Fail(ScenarioContext.Current.TestError.Message);
                }
                else if (typeOfStep.Equals("When"))
                {
                    scenario.CreateNode<When>(ScenarioStepContext.Current.StepInfo.Text).Fail(ScenarioContext.Current.TestError.Message);
                }
                else if (typeOfStep.Equals("Then"))
                {
                    scenario.CreateNode<Then>(ScenarioStepContext.Current.StepInfo.Text).Fail(ScenarioContext.Current.TestError.Message);
                }
            }
            //Cater for a step that has not been implemented
            if (ScenarioContext.Current.ScenarioExecutionStatus.ToString().Equals("StepDefinitionPending"))
            {
                if (typeOfStep.Equals("Given"))
                {
                    scenario.CreateNode<Given>(ScenarioStepContext.Current.StepInfo.Text).Skip("Step Definition Pending");
                }
                else if (typeOfStep.Equals("When"))
                {
                    scenario.CreateNode<When>(ScenarioStepContext.Current.StepInfo.Text).Skip("Step Definition Pending");
                }
                else if (typeOfStep.Equals("Then"))
                {
                    scenario.CreateNode<Then>(ScenarioStepContext.Current.StepInfo.Text).Skip("Step Definition Pending");
                }
            }
        }

        [AfterScenario]

        public void CloseApplication()
        {
            try
            {
                if (ScenarioContext.Current.TestError != null)  //this condition will always be true when a test fails
                {
                    string scenarioName = ScenarioContext.Current.ScenarioInfo.Title;
                    string directory = Directory.GetCurrentDirectory() + @"\Screenshots\";
                    TakeScreenshot(directory, scenarioName);
                }
            }
            catch (Exception)
            {

            }

            context.CloseAnAUT();
        }

        public void TakeScreenshot(string directory, string scenarioName)
        {
            Screenshot screenshot = ((ITakesScreenshot)context.driver).GetScreenshot();
            string path = directory + scenarioName + DateTime.Now.ToString("yyyy-MM-dd") + ".png";
            string Screenshot = screenshot.AsBase64EncodedString;
            byte[] screenshotAsByteArray = screenshot.AsByteArray;
            screenshot.SaveAsFile(path, ScreenshotImageFormat.Png);
        }

    }
}
