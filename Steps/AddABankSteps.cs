using System;
using System.Configuration;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using TechTalk.SpecFlow;
using XeroProjectNew.GlobalVariables;
using XeroProjectNew.PageObjects;
using XeroProjectNew.GlobalMethods;
using XeroProjectNew.Logging;
using XeroProjectNew.Hooks;

namespace XeroProjectNew.Steps
{
    [Binding]
    public class AddABankSteps
    {
        
        
        [Given(@"Browse the XeroLogin page")]
        public void GivenBrowseTheXeroLoginPage()
        {

            Logings.Logdetails("---------------------Add ANZ(Nz) Bank Account---------------------", 0, 1, null, null, null);
            Logings.Logdetails("Customer Able to Add ANZ(Nz) Bank Account", 0, 2, null, null, null);

            try
            {
                //Fetching the website details from App.config and navigating to it.
                GlobalVariable.driver.Navigate().GoToUrl(ConfigurationManager.AppSettings.Get("Website"));
                Logings.Logdetails("XeroLogin Page is SuccessFully Loaded", 0, 3, null, null, null);

            }
            catch(Exception ex)
            {
                Logings.Logdetails("Xero Page is not loaded Loaded" + ex.ToString(), 1, 3, null, null, null);
                CommonMethods.TakeScreenshot("XeroLoginPageNotLoaded.png");

            }

            
        }
         
        [Given(@"Enter user name and Password")]
        public void GivenEnterUserNameAndPassword()
        {
            try
            {
                //using assertions to validate the login page url
                string url = GlobalVariable.driver.Url;
                Assert.AreEqual(url, GlobalVariable.LoginPageUrl);
                Logings.Logdetails("Xero Login Page Url is SuccessFully Validated", 0, 3, null, null, null);

            }
            catch (Exception ex)
            {
                Logings.Logdetails("Xero Login Page Url Is Not Valid" + ex.ToString(), 1, 3, null, null, null);
                CommonMethods.TakeScreenshot("XeroLoginPageUrlFailiure.png");

            }


            try
            {
                //Expicit wait to wait for the username/password field to be loaded
                CommonMethods.ValidateElementIsPresent(5, "IsElementLoaded", "Id", LogInPage.objUserName);

                //Enter the username and password 
                GlobalVariable.driver.FindElement(By.Id(LogInPage.objUserName)).SendKeys(GlobalVariable.userNameValue);
                GlobalVariable.driver.FindElement(By.Id(LogInPage.objPwd)).SendKeys(GlobalVariable.passwordValue);
                Logings.Logdetails("UserName and Password Successfully entered", 0, 3, null, null, null);

            }
            catch(Exception ex)
            {
                Logings.Logdetails("UserName and password Not Entered" + ex.ToString(), 1, 3, null, null, null);
                CommonMethods.TakeScreenshot("WrongusernameandPassword.png");

            }
                 

        }
        
        [Given(@"Click Login button")]
        public void GivenClickLoginButton()
        {
            try
            {
                //to click on login button
                GlobalVariable.driver.FindElement(By.Id(LogInPage.objbtnSubmit)).Click();
                Logings.Logdetails("SuccessFully Clicked the login Button ", 0, 3, null, null, null);

            }
            catch (Exception ex)
            {
                Logings.Logdetails("Failed to click Login Button" + ex.ToString(), 1, 3, null, null, null);
                CommonMethods.TakeScreenshot("ClickLoginButtonFailiure.png");

            }

        }
        
        [Given(@"Click on Use Another authentication method link")]
        public void GivenClickOnUseAnotherAuthenticationMethodLink()
        {

            try
            {

                //Asserstion to validate click another authentication button is present and loaded
                string anotherAuthtication = GlobalVariable.driver.FindElement(By.CssSelector(AnotherAuthenticationMethod.clickUseAnotherAuthentication)).Text;
                Assert.AreEqual(anotherAuthtication, GlobalVariable.anotherAuthentication);

                //waits for click another method to be loaded and clicks on it
                CommonMethods.ValidateElementIsPresent(5, "IsElementLoaded", "CssSelector", AnotherAuthenticationMethod.clickUseAnotherAuthentication);
                GlobalVariable.driver.FindElement(By.CssSelector(AnotherAuthenticationMethod.clickUseAnotherAuthentication)).Click();
                Logings.Logdetails("Click another authenthetication method is present and clicked  ", 0, 3, null, null, null);
            }
            catch (Exception ex)
            {
                Logings.Logdetails("Failed in clicking another authentication method" + ex.ToString(), 1, 3, null, null, null);
                CommonMethods.TakeScreenshot("Failedinselectinganotherauthentication.png");

            }


        }
        
        [Given(@"Select security questions")]
        public void GivenSelectSecurityQuestions()
        {
            try
            {

                //waits for the page to be loaded and asserts it is in the right page
                CommonMethods.waits(GlobalVariable.authenticationMethodPageUrl);
                string authenticationmethodUrl = GlobalVariable.driver.Url;
                Assert.AreEqual(authenticationmethodUrl, GlobalVariable.authenticationMethodPageUrl);

                //waits for the Authentication Method Click sequrity questions to be loaded and clicks on it 
                CommonMethods.ValidateElementIsPresent(5, "IsElementLoaded", "CssSelector", HowWouldYouAuthenticate.clickSecurityQuestions);
                GlobalVariable.driver.FindElement(By.CssSelector(HowWouldYouAuthenticate.clickSecurityQuestions)).Click();
                Logings.Logdetails("how would you authenticate page is loaded and successfully clicked on security questions ", 0, 3, null, null, null);
            }
            catch (Exception ex)
            {
                Logings.Logdetails("Failed in selecting security questions" + ex.ToString(), 1, 3, null, null, null);
                CommonMethods.TakeScreenshot("FailedinselectingSecurityQuestions.png");

            }

        }
        
        [Given(@"Answer Security Questions")]
        public void GivenAnswerSecurityQuestions()
        {
            try
            {
                //waits for the security questions page to load and then asserts it with the page url
                CommonMethods.waits(GlobalVariable.securityQuestionsPageUrl);
                string securityPageUrl = GlobalVariable.driver.Url;
                Assert.AreEqual(securityPageUrl, GlobalVariable.securityQuestionsPageUrl);

                //waits for questions to get loaded
                CommonMethods.ValidateElementIsPresent(5, "IsElementLoaded", "CssSelector", AnswerSecurityQuestions.question1Text);

                //logic for answering the security questions
                var question1 = GlobalVariable.driver.FindElement(By.CssSelector(AnswerSecurityQuestions.question1Text)).Text;
                var question2 = GlobalVariable.driver.FindElement(By.CssSelector(AnswerSecurityQuestions.question2Text)).Text;

                if (question1 == "What is the name of your favourite cartoon?" && question2.Equals("As a child, what did you want to be when you grew up?"))
                {

                    GlobalVariable.driver.FindElement(By.CssSelector(AnswerSecurityQuestions.answer1)).SendKeys(GlobalVariable.tomAndJerry);
                    GlobalVariable.driver.FindElement(By.CssSelector(AnswerSecurityQuestions.answer2)).SendKeys(GlobalVariable.cricketPlayer);


                }
                else if (question1 == "What is the name of your favourite cartoon?" && question2.Equals("What is your dream job?"))
                {
                    GlobalVariable.driver.FindElement(By.CssSelector(AnswerSecurityQuestions.answer1)).SendKeys(GlobalVariable.tomAndJerry);
                    GlobalVariable.driver.FindElement(By.CssSelector(AnswerSecurityQuestions.answer2)).SendKeys(GlobalVariable.softwareTester);
                }

                else if (question2 == "What is the name of your favourite cartoon?" && question1.Equals("As a child, what did you want to be when you grew up?"))
                {
                    GlobalVariable.driver.FindElement(By.CssSelector(AnswerSecurityQuestions.answer1)).SendKeys(GlobalVariable.cricketPlayer);
                    GlobalVariable.driver.FindElement(By.CssSelector(AnswerSecurityQuestions.answer2)).SendKeys(GlobalVariable.tomAndJerry);


                }
                else if (question2 == "What is your dream job?" && question1.Equals("As a child, what did you want to be when you grew up?"))
                {



                    GlobalVariable.driver.FindElement(By.CssSelector(AnswerSecurityQuestions.answer1)).SendKeys(GlobalVariable.cricketPlayer);
                    GlobalVariable.driver.FindElement(By.CssSelector(AnswerSecurityQuestions.answer2)).SendKeys(GlobalVariable.softwareTester);
                }

                else if (question1 == "What is your dream job?" && question2.Equals("As a child, what did you want to be when you grew up?"))
                {


                    GlobalVariable.driver.FindElement(By.CssSelector(AnswerSecurityQuestions.answer1)).SendKeys(GlobalVariable.softwareTester);
                    GlobalVariable.driver.FindElement(By.CssSelector(AnswerSecurityQuestions.answer2)).SendKeys(GlobalVariable.cricketPlayer);
                }
                else if (question1 == "What is your dream job?" && question2.Equals("What is the name of your favourite cartoon?"))
                {

                    GlobalVariable.driver.FindElement(By.CssSelector(AnswerSecurityQuestions.answer1)).SendKeys(GlobalVariable.softwareTester);
                    GlobalVariable.driver.FindElement(By.CssSelector(AnswerSecurityQuestions.answer2)).SendKeys(GlobalVariable.tomAndJerry);
                }

                // clicks on the submit button 
                GlobalVariable.driver.FindElement(By.CssSelector(AnswerSecurityQuestions.clickButton)).Click();
                Logings.Logdetails("Sucessfully validated the security questions page and entered the answers ", 0, 3, null, null, null);



            }
            catch (Exception ex)
            {
                Logings.Logdetails("Failed in entering the answers" + ex.ToString(), 1, 3, null, null, null);
                CommonMethods.TakeScreenshot("Failedinenteringtheanswers.png");

            }







        }
        
        [Given(@"Select Bank accounts from Accounting to add bank")]
        public void GivenSelectBankAccountsFromAccountingToAddBank()
        {
            try
            {
                //waits for the page to be loaded and asserts it is in the dashboard page
                CommonMethods.waits(GlobalVariable.dashboradPageUrl);
                string dashboardUrl = GlobalVariable.driver.Url;
                Assert.AreEqual(dashboardUrl, GlobalVariable.dashboradPageUrl);

                //explicitly waits for the accounting to be loaded in the dashboard page
                CommonMethods.ValidateElementIsPresent(5, "IsElementLoaded", "CssSelector", UserDashboardPage.accounting);

                //clicks on accounting and clicks bank accounts.
                GlobalVariable.driver.FindElement(By.CssSelector(UserDashboardPage.accounting)).Click();
                GlobalVariable.driver.FindElement(By.LinkText(UserDashboardPage.bankAccounts)).Click();
                Logings.Logdetails("Sucessfully validated the dashboard page and bank accounts is selected from accounting ", 0, 3, null, null, null);

            }
            catch (Exception ex)
            {
                Logings.Logdetails("Failed validated the dashboard page and bank accounts is selected from accounting" + ex.ToString(), 1, 3, null, null, null);
                CommonMethods.TakeScreenshot("FailedinDashboardPage.png");

            }



        }
        
        [When(@"Add Bank Account and select ANZ")]
        public void WhenAddBankAccountAndSelectANZ()
        {
            try
            {

            //waits for add bank accounts page to be loaded and asserts the page url and selects add bank account
            CommonMethods.waits(GlobalVariable.bankAccountsPageUrl);
            string bankAccountsUrl = GlobalVariable.driver.Url;
            Assert.AreEqual(bankAccountsUrl, GlobalVariable.bankAccountsPageUrl);

           
            CommonMethods.ValidateElementIsPresent(5, "IsElementLoaded", "CssSelector", BankAccountsPage.addBankAccount);

            GlobalVariable.driver.FindElement(By.CssSelector(BankAccountsPage.addBankAccount)).Click();


            //waits for find your bank page to be loaded and filters and selects ANZ(Nz)
            CommonMethods.waits(GlobalVariable.findYourBankPageUrl);
            CommonMethods.ValidateElementIsPresent(5, "IsElementLoaded", "Id", FindYourBank.SearchForYourBank);
            GlobalVariable.driver.FindElement(By.Id(FindYourBank.SearchForYourBank)).SendKeys(GlobalVariable.bankName);

      
            CommonMethods.ValidateElementIsPresent(5, "IsElementLoaded", "cssSelector", FindYourBank.selectBank);
            GlobalVariable.driver.FindElement(By.CssSelector(FindYourBank.selectBank)).Click();
            Logings.Logdetails("Sucessfully validated the Add Bank accounts Page and filtered and selected ANZ(Nz)  ", 0, 3, null, null, null);
            }
            catch (Exception ex)
            {
                Logings.Logdetails("Failed in validating the Add Bank accounts Page and filtered and selected ANZ(Nz)" + ex.ToString(), 1, 3, null, null, null);
                CommonMethods.TakeScreenshot("FailedinAddBank.png");

            }




        }
        
        [Then(@"ANZ Bank should be added")]
        public void ThenANZBankShouldBeAdded()
        {
            try
            {


                //waits for the page title to be loaded and enters the user account details 
                CommonMethods.ValidateElementIsPresent(5, "IsElementLoaded", "cssSelector", EnterAccountDetailsPage.pageTitle);
                string pageTitle = GlobalVariable.driver.FindElement(By.CssSelector(EnterAccountDetailsPage.pageTitle)).Text;
                Assert.AreEqual(pageTitle, GlobalVariable.enterBankAccountDetailsPageTitle);


                CommonMethods.ValidateElementIsPresent(5, "IsElementLoaded", "Id", EnterAccountDetailsPage.accountName);
                GlobalVariable.driver.FindElement(By.Id(EnterAccountDetailsPage.accountName)).SendKeys(GlobalVariable.accountName);



                CommonMethods.ValidateElementIsPresent(5, "IsElementLoaded", "Id", EnterAccountDetailsPage.accountType);
                GlobalVariable.driver.FindElement(By.Id(EnterAccountDetailsPage.accountType)).Click();

                CommonMethods.ValidateElementIsPresent(5, "IsElementLoaded", "Id", EnterAccountDetailsPage.accountType);
                GlobalVariable.driver.FindElement(By.Id(EnterAccountDetailsPage.accountType)).SendKeys(Keys.Enter);



                CommonMethods.ValidateElementIsPresent(5, "IsElementLoaded", "Id", EnterAccountDetailsPage.accountNumber);
                GlobalVariable.driver.FindElement(By.Id(EnterAccountDetailsPage.accountNumber)).SendKeys(GlobalVariable.accountNumber);


                GlobalVariable.driver.FindElement(By.Id(EnterAccountDetailsPage.clickContinue)).Click();
                Logings.Logdetails("Sucessfully validated the ANZ add account details page is loaded and the details are entered   ", 0, 3, null, null, null);

            }
            catch (Exception ex)
            {
                Logings.Logdetails("Failed in validating the ANZ account details page " + ex.ToString(), 1, 3, null, null, null);
                CommonMethods.TakeScreenshot("FailedinAdddingANZbankdetails.png");

            }




        }
    }
}
