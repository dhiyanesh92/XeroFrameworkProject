using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XeroProjectNew.GlobalVariables
{
    public class GlobalVariable
    {
        //Driver Initialisation
        public static IWebDriver driver = new ChromeDriver();


        //login values
        public static string LoginPageUrl = "https://login.xero.com/identity/user/login";
        public static string userNameValue = "dhiyanesh2992@gmail.com";
        public static string passwordValue = "DhiyaAbi1*";
        public static string anotherAuthentication = "Use another authentication method";
        public static string authenticationMethodPageUrl = "https://login.xero.com/identity/user/login/two-factor/authenticate?returnUrl=https%3A%2F%2Fgo.xero.com%2Fdashboard%2F";
        public static string securityQuestionsPageUrl = "https://login.xero.com/identity/user/login/two-factor/authenticate?returnUrl=https%3A%2F%2Fgo.xero.com%2Fdashboard%2F";
        public static string dashboradPageUrl = "https://go.xero.com/dashboard/default.aspx";
        public static string bankAccountsPageUrl = "https://go.xero.com/Bank/BankAccounts.aspx";
        public static string findYourBankPageUrl = "https://go.xero.com/app/!sfTgD/bank-search";




        public static string tomAndJerry = "tom and jerry";
        public static string cricketPlayer = "cricket player";
        public static string softwareTester = "software tester";

        public static string bankName = "ANZ";
        public static string enterBankAccountDetailsPageTitle = "Enter your ANZ (NZ) account details";
        public static string accountName = "126";
        public static string accountNumber = "12678";




    }
}
