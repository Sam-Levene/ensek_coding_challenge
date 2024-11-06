using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using AventStack.ExtentReports.Reporter.Config;
using ensek_coding_challenge.Utilities;

public class ExtentReportManager
{
    private static ExtentReports _extent;
    private static ExtentSparkReporter _htmlReporter;

    // Initialize the ExtentReports instance and configure the HTML reporter
    public static ExtentReports GetExtentReport()
    {
        if (_extent == null)
        {
            // Start from the current directory (bin/Debug/net8.0 or equivalent)
            string currentDirectory = Directory.GetCurrentDirectory();

            // Navigate up three levels to reach the project root (bin/Debug/net8.0 -> bin/Debug -> project root)
            DirectoryInfo directoryInfo = new DirectoryInfo(currentDirectory);
            
            // Move up three levels
            directoryInfo = directoryInfo.Parent.Parent.Parent; // 3 levels up to the project root

            String projectRoot = directoryInfo.ToString();

            // Set the file path for the HTML report
            string reportDir = Path.Combine(projectRoot, "Reports");
            Directory.CreateDirectory(reportDir);

            string reportPath = Path.Combine(projectRoot, "Reports", "TestReport_" + HelperFunctions.GetUnixTimeStamp() + ".html");
            _htmlReporter = new ExtentSparkReporter(reportPath);
            
             // Set the reporter properties
            _htmlReporter.Config.Theme = Theme.Standard;    // Use Standard or Dark theme
            _htmlReporter.Config.DocumentTitle = "Selenium Test Report for ENSEK coding challenge";  // Document title for the HTML page
            _htmlReporter.Config.ReportName = "Test Report for ENSEK coding challenge";    // Report name displayed in the HTML header

            // Create the ExtentReports instance and attach the reporter
            _extent = new ExtentReports();
            _extent.AttachReporter(_htmlReporter);
        }
        return _extent;
    }

    // Optionally, you can add other configurations for the report here
    public static void FlushReport()
    {
        _extent.Flush();
    }
}
