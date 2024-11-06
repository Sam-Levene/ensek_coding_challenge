
using System;
using System.IO;
using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;

namespace ensek_coding_challenge;
public class ExtentReportManager
{
    private static ExtentReports extent;
    private static ExtentTest test;

    public static ExtentReports GetExtentReport()
    {
        if (extent == null)
        {
            string reportPath = Path.Combine(Directory.GetCurrentDirectory(), "Reports", "TestReport.html");
            var htmlReporter = new ExtentSparkReporter(reportPath);
            extent = new ExtentReports();
            extent.AttachReporter(htmlReporter);
        }
        return extent;
    }

    public static void CreateTest(string testName)
    {
        test = extent.CreateTest(testName);
    }

    public static void EndTest()
    {
        extent.Flush();
    }

    public static void LogInfo(string message) => test.Info(message);
    public static void LogPass(string message) => test.Pass(message);
    public static void LogFail(string message) => test.Fail(message);
}
