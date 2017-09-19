﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT license.

using Microsoft.Dynamics365.UIAutomation.Browser;
using OpenQA.Selenium;
using System;

namespace Microsoft.Dynamics365.UIAutomation.Api
{

    /// <summary>
    /// Xrm Report Page
    /// </summary>
    public class XrmMobilePage
        : XrmPage
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="XrmMobilePage"/> class.
        /// </summary>
        /// <param name="browser">The browser.</param>
        public XrmMobilePage(InteractiveBrowser browser)
            : base(browser)
        {
            SwitchToDefaultContent();
        }

        public BrowserCommandResult<bool> Open(int thinkTime = Constants.DefaultThinkTime)
        {
            Browser.ThinkTime(thinkTime);

            return this.Execute(GetOptions("Open Mobile Page"), driver =>
            {
                Uri baseUri = new Uri(driver.Url);

                driver.Navigate().GoToUrl(baseUri.GetLeftPart(System.UriPartial.Authority) + "/m");

                driver.WaitUntilVisible(By.XPath(Elements.Xpath[Reference.Mobile.Page])
                    , new TimeSpan(0, 0, 60),
                    e => { e.WaitForPageToLoad(); },
                    f => { throw new Exception("Mobile page failed to load."); });

                return true;
            });
        }
    }
}