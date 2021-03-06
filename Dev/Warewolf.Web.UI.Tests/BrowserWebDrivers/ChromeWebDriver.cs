﻿using OpenQA.Selenium.Chrome;
using System;
using System.IO;

namespace Warewolf.Web.UI.Tests.BrowserWebDrivers
{
    public class ChromeWebDriver : BaseWebDriver
    {
        static ChromeOptions chromeOptions = new ChromeOptions();
        public ChromeWebDriver() : base(new ChromeDriver(Environment.CurrentDirectory, chromeOptions, TimeSpan.FromMinutes(3)))
        {
            chromeOptions.AddArguments(new[] { "user-data-dir=" + Path.Combine(Environment.CurrentDirectory, "WebDriverProfiles", "Chrome"), "start-maximized" });
        }
    }
}
