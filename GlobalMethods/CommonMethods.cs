using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using ExpectedConditions = SeleniumExtras.WaitHelpers.ExpectedConditions;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Interactions;
using System.IO;
using XeroProjectNew.GlobalVariables;

namespace XeroProjectNew.GlobalMethods
{
   
        public static class CommonMethods
        {
            public static string pathString;
            public static string foldername;
            public static string LogFile;
            public static string Fullpath;
            public static void ValidateElementIsPresent(int seconds, string waitType, string searchBy, string clickAt)
            {
                var Wait = new WebDriverWait(GlobalVariable.driver, TimeSpan.FromSeconds(seconds));

                if (waitType.Equals("ElementIsVisible"))
                {
                    switch (searchBy.ToLower())
                    {
                        case "xpath":
                            Wait.Until(ExpectedConditions.ElementIsVisible(By.XPath(clickAt)));
                            break;

                        case "name":
                            Wait.Until(ExpectedConditions.ElementIsVisible(By.Name(clickAt)));
                            break;

                        case "tagname":
                            Wait.Until(ExpectedConditions.ElementIsVisible(By.TagName(clickAt)));
                            break;

                        case "classname":
                            Wait.Until(ExpectedConditions.ElementIsVisible(By.ClassName(clickAt)));
                            break;

                        case "id":
                            Wait.Until(ExpectedConditions.ElementIsVisible(By.Id(clickAt)));
                            break;

                        case "cssselector":
                            Wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector(clickAt)));
                            break;

                        case "linktext":
                            Wait.Until(ExpectedConditions.ElementIsVisible(By.LinkText(clickAt)));
                            break;

                        case "partiallinktext":
                            Wait.Until(ExpectedConditions.ElementIsVisible(By.PartialLinkText(clickAt))).Click();
                            break;
                    }

                }
                else if (waitType.Equals("ElementToBeSelected"))
                {
                    switch (searchBy.ToLower())
                    {
                        case "xpath":
                            Wait.Until(ExpectedConditions.ElementToBeSelected(By.XPath(clickAt)));
                            break;
                        case "name":
                            Wait.Until(ExpectedConditions.ElementToBeSelected(By.Name(clickAt)));
                            break;

                        case "tagname":
                            Wait.Until(ExpectedConditions.ElementToBeSelected(By.TagName(clickAt)));
                            break;

                        case "classname":
                            Wait.Until(ExpectedConditions.ElementToBeSelected(By.ClassName(clickAt)));
                            break;

                        case "id":
                            Wait.Until(ExpectedConditions.ElementToBeSelected(By.Id(clickAt)));
                            break;

                        case "cssselector":
                            Wait.Until(ExpectedConditions.ElementToBeSelected(By.CssSelector(clickAt)));
                            break;

                        case "linktext":
                            Wait.Until(ExpectedConditions.ElementToBeSelected(By.LinkText(clickAt)));
                            break;

                        case "partiallinktext":
                            Wait.Until(ExpectedConditions.ElementToBeSelected(By.PartialLinkText(clickAt)));
                            break;
                    }

                }

                else if (waitType.Equals("EElementToBeClickable"))
                {
                    switch (searchBy.ToLower())
                    {
                        case "xpath":
                            Wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath(clickAt))).Click();
                            break;
                        case "name":
                            Wait.Until(ExpectedConditions.ElementToBeClickable(By.Name(clickAt))).Click();
                            break;

                        case "tagname":
                            Wait.Until(ExpectedConditions.ElementToBeClickable(By.TagName(clickAt))).Click();
                            break;

                        case "classname":
                            Wait.Until(ExpectedConditions.ElementToBeClickable(By.ClassName(clickAt))).Click();
                            break;

                        case "id":
                            Wait.Until(ExpectedConditions.ElementToBeClickable(By.Id(clickAt))).Click();
                            break;

                        case "cssselector":
                            Wait.Until(ExpectedConditions.ElementToBeClickable(By.CssSelector(clickAt))).Click();
                            break;

                        case "linktext":
                            Wait.Until(ExpectedConditions.ElementToBeClickable(By.LinkText(clickAt))).Click();
                            break;

                        case "partiallinktext":
                            Wait.Until(ExpectedConditions.ElementToBeClickable(By.PartialLinkText(clickAt))).Click();
                            break;
                    }

                }

                else if (waitType.Equals("IsElementLoaded"))
                {
                    switch (searchBy.ToLower())
                    {
                        case "xpath":
                            Wait.Until(ExpectedConditions.ElementIsVisible(By.XPath(clickAt)));
                            break;

                        case "name":
                            Wait.Until(ExpectedConditions.ElementIsVisible(By.Name(clickAt)));
                            break;

                        case "tagname":
                            Wait.Until(ExpectedConditions.ElementIsVisible(By.TagName(clickAt)));
                            break;

                        case "classname":
                            Wait.Until(ExpectedConditions.ElementIsVisible(By.ClassName(clickAt)));
                            break;

                        case "id":
                            Wait.Until(ExpectedConditions.ElementIsVisible(By.Id(clickAt)));
                            break;

                        case "cssselector":
                            Wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector(clickAt)));
                            break;

                        case "linktext":
                            Wait.Until(ExpectedConditions.ElementIsVisible(By.LinkText(clickAt)));
                            break;

                        case "partiallinktext":
                            Wait.Until(ExpectedConditions.ElementIsVisible(By.PartialLinkText(clickAt)));
                            break;
                    }

                }
            }

            public static void TakeScreenshot(string filename)
            {
                try
                {

                    string filepath = createTempDirectory(filename);
                    //createFilename();
                    var screenshot = ((ITakesScreenshot)GlobalVariable.driver).GetScreenshot();
                    screenshot.SaveAsFile(filepath, ScreenshotImageFormat.Png);
                }
                catch (Exception) { }
            }
            public static string createTempDirectory(string filename)
            {
                // need to be replaced with a relative directory
                foldername = @"C:\Temp\";
                try
                {
                    //pathString = System.IO.Path.Combine(foldername);

                    //pathString = Path.Combine(Environment.CurrentDirectory, "TestScreenshots");
                    pathString = Path.Combine(foldername, "TestScreenshots");
                    bool dirExists = System.IO.Directory.Exists(pathString);
                    if (!dirExists)
                    {
                        System.IO.Directory.CreateDirectory(pathString);
                    }
                    pathString = System.IO.Path.Combine(pathString, filename);
                }
                catch (Exception) { }
                return pathString;
            }

        public static void waits(string url)
        {
            var Wait = new WebDriverWait(GlobalVariable.driver, TimeSpan.FromSeconds(10));
            Wait.Until(ExpectedConditions.UrlToBe(url));
        }

       
    }
    }



