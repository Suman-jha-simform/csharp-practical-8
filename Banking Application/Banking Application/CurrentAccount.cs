using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banking_Application
{
    sealed class CurrentAccount : Account
    {
        readonly static string _accountType = "Current";
        static double _overDraftLimit = 20000;


        //constructor to set the account holder name, account number and accountype
        public CurrentAccount(string accountHolder) : base(accountHolder, _accountType)
        { }



        /// <summary>
        /// This overloaded method helps deposit balance in account and resolve the overdraft amount.
        /// </summary>
        /// <param name="amountToDeposit"></param>
        /// <param name="overDraftResolve"></param>
        /// <returns>void</returns>
        public void Deposit(double amountToDeposit, bool overDraftResolve)
        {
            double tempOverDraftAmount = 0;
            if(_overDraftLimit < 20000 && overDraftResolve)
            {
                double tempDraftLimit = 20000 - _overDraftLimit;
      
                if(tempDraftLimit > amountToDeposit)
                {
                    _overDraftLimit += amountToDeposit;
                    tempOverDraftAmount = amountToDeposit;

                } else if(tempDraftLimit <= amountToDeposit)
                {
                    _overDraftLimit += tempDraftLimit;
                    _accountBalance += (amountToDeposit - tempDraftLimit);
                    tempOverDraftAmount = tempDraftLimit;
                }
                Console.WriteLine($"\n\t\t\t\t\tYour paid overdraft amount of : {tempOverDraftAmount} ");
                Console.WriteLine($"\n\t\t\t\t\tRemaining overdraft to be paid : {20000 - _overDraftLimit} ");

            }
            else 
            {
                _accountBalance += amountToDeposit;
                Console.Write($"\n\t\t\t\t\tAmount deposited successfully :) ");
            }
        }




        /// <summary>
        /// This method helps withdraw amount from current account .
        /// </summary>
        /// <param name="amountToWithdraw"></param>
        /// <returns>void</returns>
        public override void Withdraw(double amountToWithdraw)
        {
            if (AccountServices.BalanceStatus((_accountBalance), amountToWithdraw))
            {
                _accountBalance -= amountToWithdraw;
                Console.WriteLine($"\n\t\t\t\t\tYou have successfully withdrawed : {amountToWithdraw} ");
            }
            else if (AccountServices.BalanceStatus(_overDraftLimit, amountToWithdraw) && _accountBalance <= 0)
            {

                string userChoice = "";
                Console.Write($"\n\t\t\t\t\tYou do not have enough balance to withdraw.");
                Console.Write($"\n\t\t\t\t\tDo you want to make a overdraft withdrawl : ");
                userChoice= Console.ReadLine();

                if(userChoice.ToLower() == "yes")
                {
                    _overDraftLimit -= amountToWithdraw;
                    Console.WriteLine($"\n\t\t\t\t\tYou have withdrawed a overdraft amount of {amountToWithdraw}.");
                    Console.WriteLine($"\n\t\t\t\t\tRemaining overdraft amount is : {_overDraftLimit}");
                }
                else if(userChoice.ToLower() == "no")
                {
                    Console.WriteLine($"\n\t\t\t\t\tInsufficient amount in account cannot withdraw.");
                }
                else
                {
                    Console.Write($"\n\t\t\t\t\tInvalid Choice !!!");
                }

            }
            else if (AccountServices.BalanceStatus((_overDraftLimit + _accountBalance), (amountToWithdraw)))
            {
                Console.WriteLine($"\n\t\t\t\t\tYou need to make complete withdrawl from your account");
                Console.WriteLine($"\n\t\t\t\t\tto withdraw the overdraft amount.");
            }
            else
            {
                Console.WriteLine("\n\t\t\t\t\tInsufficent Balance, cannot withdraw. ");
                Console.WriteLine("\n\t\t\t\t\tThe transaction also exceeds the limit of your overdraft amount.");
                Console.WriteLine("\n\t\t\t\t\tPLease depsoit soon :)");
            }
        }


    }
}
