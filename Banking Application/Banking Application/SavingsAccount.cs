using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banking_Application
{
    sealed class SavingsAccount : Account
    {
        readonly static string _accountType = "Savings";
        readonly static double _interestRate = 3.5;
        static double _transactionLimit = 50000;


        //constructor to set the account holder name, account number and accountype
        public SavingsAccount(string accountHolder):base(accountHolder, _accountType) 
        { }


        /// <summary>
        /// This method gives the current interest rate and amount.
        /// </summary>
        /// <returns>void</returns>
        public void InterestAmount()
        {
            double interestAmount = (_interestRate * _accountBalance) / 100;
            Console.WriteLine($"\n\t\t\t\t\tYour interest rate is {_interestRate} and interest amount is : {interestAmount}");
        }


        /// <summary>
        /// This is a overloaded method that allows user to deposit cheque. 
        /// </summary>
        /// <returns>void</returns>
        public void Deposit(double balanceToDeposit, string chequeNumber)
        {
            if(AccountServices.CheckValidation(chequeNumber))
            {
                _accountBalance += balanceToDeposit;
            } else
            {
                Console.WriteLine("\n\t\t\t\t\tInvalid Cheque Number");
            }

        }

        /// <summary>
        /// This method limits the withdraw to specified transaction limit. 
        /// </summary>
        /// <returns>void</returns>
        public override void Withdraw(double amountToWithdraw)
        {
           
            if (AccountServices.BalanceStatus(_accountBalance, amountToWithdraw))
            {
                if (amountToWithdraw > _transactionLimit)
                {
                    Console.WriteLine($"\n\t\t\t\t\tYour transaction limit is 50000.");
                    Console.WriteLine($"\n\t\t\t\t\tYou cannot withdraw.");
                }
                else if(_transactionLimit >= amountToWithdraw)
                {
                    _accountBalance -= amountToWithdraw;
                    _transactionLimit -= amountToWithdraw;
                    Console.WriteLine($"\n\t\t\t\t\tYou have successfully withdrawed : {amountToWithdraw} ");
                }
            }
            else
            {
                Console.WriteLine("\n\t\t\t\t\tInsufficent Balance, cannot withdraw.");
            }

        }

        /// <summary>
        /// This function resets the transaction limit 
        /// </summary>
        /// <returns>void</returns>
        public void ResetTransactionLimit()
        {
            _transactionLimit = 50000;
            Console.WriteLine("\n\t\t\t\t\tTransaction limit has been reseted.");
        }

        /// <summary>
        /// This function displays the transaction limit 
        /// </summary>
        /// <returns>void</returns>
        public void GetTransactionLimit()
        {
            Console.WriteLine($"\n\t\t\t\t\tRemaining transaction limit is {_transactionLimit}");
        }
    }
}
