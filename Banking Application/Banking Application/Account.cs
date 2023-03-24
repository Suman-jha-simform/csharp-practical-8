using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banking_Application
{
    //interface for Account class
    interface IAccount
    {
        void Deposit(double balanceToDeposit);
        void Withdraw(double amountToWithdraw);
        void CheckBalance();
    }
    internal class Account:IAccount
    {
        readonly string _accountHolder;
        readonly string _accountNumber;
        public static double _accountBalance = 0;
        readonly string _accountType;


        //public constructor to intialize the non-static variables
        public Account(string accountHolder, string accounttype)
        {
            _accountHolder = accountHolder;
            _accountNumber = AccountServices.AccountNumber();
            _accountType = accounttype;
        }


        /// <summary>
        /// This method deposits the balance in the account .
        /// </summary>
        /// <param name="balanceToDeposit"></param>
        /// <returns>void</returns>
        public void Deposit(double balanceToDeposit)
        {
            _accountBalance += balanceToDeposit;
        }



        /// <summary>
        /// This method helps withdraw balance from the account.
        /// </summary>
        /// <param name="amountToWithdraw"></param>
        /// <returns>void</returns>
        public virtual void Withdraw(double amountToWithdraw)
        {
            if(AccountServices.BalanceStatus(_accountBalance, amountToWithdraw))
            {
                _accountBalance -= amountToWithdraw;
                Console.WriteLine($"\n\t\t\t\t\tYou have successfully withdrawed : {amountToWithdraw} ");
            } else
            {
                Console.WriteLine("\n\t\t\t\t\tInsufficent Balance, cannot withdraw.");
            }
        }



        /// <summary>
        /// This method helps check balance of the account.
        /// </summary>
        /// <returns>void</returns>
        public void CheckBalance()
        {
            Console.WriteLine($"\n\t\t\t\t\tYour current balance is : {_accountBalance}");
        }

        /// <summary>
        /// This method displays the user account details.
        /// </summary>
        /// <returns>void</returns>
        public void AccountDetails()
        {
            Console.WriteLine($"\n\t\t\t\t\tAccount Holder Name : {this._accountHolder}");
            Console.WriteLine($"\t\t\t\t\tAccount Number      : {this._accountNumber}");
            Console.WriteLine($"\t\t\t\t\tAccount Balance     : {_accountBalance}");
            Console.WriteLine($"\t\t\t\t\tAccount Type        : {this._accountType}");
        }
    }


}
