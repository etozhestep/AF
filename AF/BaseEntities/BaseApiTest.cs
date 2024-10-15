using System.Reflection;
using AF.Steps.Api;
using Allure.Net.Commons;
using Allure.NUnit;
using Allure.NUnit.Attributes;
using NLog;
using TestStatus = NUnit.Framework.Interfaces.TestStatus;

namespace AF.BaseEntities;

[Parallelizable(ParallelScope.All)]
[FixtureLifeCycle(LifeCycle.InstancePerTestCase)]
[AllureNUnit]
public class BaseApiTest
{
    protected readonly Logger Logger = LogManager.GetCurrentClassLogger();
    protected ApiLoginSteps LoginSteps;

    [SetUp]
    [AllureBefore("Setting up API services")]
    public void Setup()
    {
        Logger.Info("Setting up API test...");
        LoginSteps = new ApiLoginSteps();
    }

    [TearDown]
    [AllureAfter("Tearing down logs")]
    public void TearDown()
    {
        try
        {
            // Get the path to the log files
            var infoLogFile = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)!,
                "InfoLogFile.txt");
            var errorLogFile = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)!,
                "ErrorLogFile.txt");

            if (File.Exists(infoLogFile))
                AllureApi.AddAttachment("InfoLogFile", "text/plain", infoLogFile);
            // Verify if the test failed
            if (TestContext.CurrentContext.Result.Outcome.Status is not TestStatus.Failed) return;
            Logger.Info("Test failed. Making a screenshot...");
            if (File.Exists(errorLogFile))
                AllureApi.AddAttachment("ErrorLogFile", "text/plain", errorLogFile);
        }
        catch (Exception e)
        {
            Logger.Error(e, "Failed to tear down the test.");
        }
    }
}