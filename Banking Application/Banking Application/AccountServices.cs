using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banking_Application
{

    //staic class to provide support functionalities to the Account class.
    static class AccountServices
    {
        /// <summary>
        /// This method gives account number to user's account.
        /// </summary>
        /// <returns>string</returns>
        public static string AccountNumber()
        {
            Random rand = new Random();
            int suffix = rand.Next(1000);
            string accountNumber = "0001112223333" + suffix.ToString("D3");
            return accountNumber;
        }



        /// <summary>
        /// This method helps check whether there is sufficient balance in the account.
        /// </summary>
        /// <param name="accountBalance"></param>
        /// <param name="amountToWithdraw"></param>
        /// <returns>boolean</returns>
        public static bool BalanceStatus(double accountBalance, double amountToWithdraw)
        {
            if (accountBalance < 0)
            {
                return false;
            }
            else if ((accountBalance - amountToWithdraw) >= 0)
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        /// <summary>
        /// This is a extension method that verifies whether Cheque number is valid to deposit or not
        /// </summary>
        /// <param name="chequeNumber"></param>
        /// <returns>boolean</returns>
        public static bool CheckValidation(this string chequeNumber)
        {
            if(chequeNumber.Length >= 8)
            {
                return true;
            } else
            {
                return false;
            }
        }

        /// <summary>
        /// This method check if given input is string or not
        /// </summary>
        /// <param name="IsAlphaNumString"></param>
        /// <returns></returns>
        public static bool IsAlphaNum(string IsAlphaNumString)
        {
            bool isAlphaNum = true;

            foreach(char c in IsAlphaNumString)
            {
                if(char.IsLetter(c) || char.IsDigit(c))
                {
                    isAlphaNum = true;
              
                }
                else
                {
                    isAlphaNum = false;
                    break;
                }
            }

            return isAlphaNum;
        }


        /// <summary>
        /// This method check if given input is string or not
        /// </summary>
        /// <param name="testString"></param>
        /// <returns></returns>
        public static bool IsString(string testString)
        {
            bool isString = true;

            foreach (char c in testString)
            {
              
                if (!char.IsLetter(c))
                {
                    isString = false;
                    break;
                }
            }

            return isString;
        }

        /// <summary>
        /// This method check if given input is number or not
        /// </summary>
        /// <param name="testNumber"></param>
        /// <returns></returns>
        public static bool IsNumber(int testNumber)
        {
            bool isNum = true;
            string numString = testNumber.ToString();   

            foreach (char c in numString)
            {

                if (!char.IsDigit(c))
                {
                    isNum = false;
                    break;
                }
            }

            return isNum;
        }


    }
}
