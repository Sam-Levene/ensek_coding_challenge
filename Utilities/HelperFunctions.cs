using OpenQA.Selenium;

namespace ensek_coding_challenge.Utilities
{ 
    public class HelperFunctions
    {
        public static long GetUnixTimeStamp() {
            return DateTimeOffset.UtcNow.ToUnixTimeSeconds();
        }

        public static string CaptureScreenshot(string screenshotName, IWebDriver driver)
        {
           // Start from the current directory (bin/Debug/net8.0 or equivalent)
            string currentDirectory = Directory.GetCurrentDirectory();

            // Navigate up three levels to reach the project root (bin/Debug/net8.0 -> bin/Debug -> project root)
            DirectoryInfo directoryInfo = new DirectoryInfo(currentDirectory);
            
            // Move up three levels
            directoryInfo = directoryInfo.Parent.Parent.Parent; // 3 levels up to the project root

            String projectRoot = directoryInfo.ToString();
            
            // Get the path for the Screenshots folder in the project root
            string screenshotsDir = Path.Combine(projectRoot, "Screenshots");

            // Ensure the Screenshots directory exists
            Directory.CreateDirectory(screenshotsDir);

            // Define the screenshot file path (in the project directory)
            string filePath = Path.Combine(screenshotsDir, $"{screenshotName}.png");

            // Capture the screenshot using Selenium's ITakesScreenshot interface
            var screenshot = ((ITakesScreenshot)driver).GetScreenshot();
            
            // Save the screenshot to the file (default format is PNG)
            screenshot.SaveAsFile(filePath);

            return filePath;
        }
    }
}