using System;

namespace DriverConfiguration
{ 
    public class DriverConfiguration
    {
        public static IWebDriver driver;

        private static IWebDriver InitializeDriver()
        {
            //SeleniumPOC.Configuration
            //var chromeOptions = new ChromeOptions();
            //chromeOptions.AddArguments("headless", "window-size=1920,1080");

            if (driver == null)
                driver = new ChromeDriver(@"c:\Chromedriver");
            return driver;
        }

        public static void CleanupDriver()
        {
            driver.Quit();
        }
    }
}

