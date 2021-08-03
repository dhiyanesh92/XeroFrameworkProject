
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;
using XeroProjectNew.GlobalVariables;

namespace XeroProjectNew.Hooks
{
    [Binding]
    public sealed class Hooks1
    {


        [BeforeTestRun]
        public static void BeforeTestRun()
        {
            GlobalVariable.driver.Manage().Window.Maximize();
        }


        [AfterTestRun]
        public static void AfterTestRun()
        {
            GlobalVariable.driver.Close();
            GlobalVariable.driver.Quit();


        }

    }
}















