using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XeroProjectNew.PageObjects
{
    public static class AnswerSecurityQuestions
    {
        public static string question1Text = "label[data-automationid = 'auth-firstanswer--label']";
        public static string question2Text = "label[data-automationid = 'auth-secondanswer--label']";
        public static string answer1 = "input[data-automationid = 'auth-firstanswer--input']";
        public static string answer2 = "input[data-automationid = 'auth-secondanswer--input']";
        public static string clickButton = "button[data-automationid = 'auth-submitanswersbutton']";
    }
}
