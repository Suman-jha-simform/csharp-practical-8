using System;

namespace Banking_Application
{
    class Program
    {
        /// <summary>
        /// This function displays the banner of the bank.
        /// </summary>
        /// <returns>void</returns>
        public static void Banner()
        {
            Console.WriteLine($"\t\t\t\t\t -----------------------------");
            Console.WriteLine($"\t\t\t\t\t| Welcome to Apna Bank Portal |");
            Console.WriteLine($"\t\t\t\t\t -----------------------------\n\n\n\n");
        }

        /// <summary>
        /// This function displays the options to user of savings account.
        /// </summary>
        /// <returns>void</returns>
        public static void UserOptionsSavings()
        {
            Console.WriteLine($"\n\n\t\t\t\t\t What do you want to do ?");
            Console.WriteLine($"\t\t\t\t\t 1.Deposit ");
            Console.WriteLine($"\t\t\t\t\t 2.Withdraw ");
            Console.WriteLine($"\t\t\t\t\t 3.Check Balance ");
            Console.WriteLine($"\t\t\t\t\t 4.See Account Details ");
            Console.WriteLine($"\t\t\t\t\t 5.See Interest Details ");
            Console.WriteLine($"\t\t\t\t\t 6.See Transaction Limit");
            Console.WriteLine($"\t\t\t\t\t 7.Reset Transaction Limit");
            Console.WriteLine($"\t\t\t\t\t 8.Exit ");
        }

        /// <summary>
        /// This function displays the options to user of current account.
        /// </summary>
        /// <returns>void</returns>
        public static void UserOptionsCurrent()
        {
            Console.WriteLine($"\n\n\t\t\t\t\t What do you want to do ?");
            Console.WriteLine($"\t\t\t\t\t 1.Deposit ");
            Console.WriteLine($"\t\t\t\t\t 2.Withdraw ");
            Console.WriteLine($"\t\t\t\t\t 3.Check Balance ");
            Console.WriteLine($"\t\t\t\t\t 4.See Account Details ");
            Console.WriteLine($"\t\t\t\t\t 5.Exit ");
            Console.WriteLine($"\n\t\t\t\t\t Note : We provide overdraft facility amount of 20000. ");
        }

        /// <summary>
        /// This function displays message to the user after sucessfull account creation.
        /// </summary>
        /// <returns>void</returns>
        public static void BannerForAccountCreation()
        {
            Console.WriteLine($"\n\t\t\t\t\tYour account has been created successfully.");
            Console.WriteLine($"\n\t\t\t\t\tPress enter to proceed further.");
            Console.ReadKey();
            Console.Clear();
        }

        
        public static void Main()
        {
            try
            {
                string? _accountHolder = "";
                int userInput;
                Banner();
                do
                {
                    try
                    {
                        Console.Write($"\n\t\t\t\t\tEnter User Name : ");
                        _accountHolder = Console.ReadLine();

                        _accountHolder = _accountHolder.Trim();

                        if (!AccountServices.IsString(_accountHolder))
                        {
                            throw new NotSupportedException("User name can contain letters only.");
                        }
                        else if (string.IsNullOrEmpty(_accountHolder))
                        {
                            throw new NotSupportedException("Cannot be null and spaces are not allowed.");
                        }
                    } catch(NotSupportedException ne)
                    {
                        Console.Clear();
                        Banner();
                        Console.WriteLine($"\n\t\t\t\t\t{ne.Message}");
                    }

                } while (!AccountServices.IsString(_accountHolder) || string.IsNullOrEmpty(_accountHolder));
                

                Console.Clear();
                Banner();
                bool userChoice = false;
                do
                {
                    //displaying and taking user input for the type of account to create
                    Console.WriteLine($"\n\t\t\t\t\t What do you want to do : \n");
                    Console.WriteLine($"\t\t\t\t\t 1. Create a Saving Account \n");
                    Console.WriteLine($"\t\t\t\t\t 2. Create a Current Account\n");
                    Console.Write($"\t\t\t\t\t");
                    userChoice = int.TryParse(Console.ReadLine(), out userInput);

                    if(!userChoice || userInput != 1 || userInput !=2 || !AccountServices.IsNumber(userInput) )
                    {
                        Console.Clear();
                        Banner();
                        Console.Write($"\t\t\t\t\tPlease enter a valid choice\n");
                    }
                } while(userInput != 1 && userInput !=2 || !userChoice );



                //using if else for type of account to create
                //for savings account
                if(userInput == 1)
                {
                    Console.Clear();
                    Banner();

                    SavingsAccount savingsAccount = new SavingsAccount(_accountHolder);
                    BannerForAccountCreation();

                    Banner();
                    bool operation = true;

                    do
                    {
                        UserOptionsSavings();
                        double amount;
                        int userInputSaving;
                        Console.Write($"\n\t\t\t\t\tChoice: ");
                        bool isUserInputSaving = int.TryParse(Console.ReadLine(), out userInputSaving);

                        if(isUserInputSaving)
                        {
                            //using switch case for choice options for savings account
                            switch (userInputSaving)
                            {
                                case 1:
                                    Console.Clear();
                                    Banner();

                                    Console.Write($"\n\t\t\t\t\tOptions to Choose from :  ");
                                    Console.Write($"\n\t\t\t\t\t1. Deposit Cash  ");
                                    Console.Write($"\n\t\t\t\t\t2. Deposit Cheque ");
                                    Console.Write($"\n\t\t\t\t\t");
                                    int depositChoice;
                                    bool isdepositChoice = int.TryParse(Console.ReadLine(), out depositChoice);

                                    if(isdepositChoice && depositChoice == 1)
                                    {
                                        Console.Write($"\n\t\t\t\t\tEnter amount to Deposit: ");
                                        bool isCorrectAmountD = Double.TryParse(Console.ReadLine(), out amount);
                                        if (isCorrectAmountD && amount > 0)
                                        {
                                            savingsAccount.Deposit(amount);
                                            Console.Write($"\n\t\t\t\t\tAmount deposited successfully :) ");
                                        }
                                        else
                                        {
                                            Console.Write($"\n\t\t\t\t\tInvalid amount cannot Deposit !!!");
                                        }
                                    } else if(isdepositChoice && depositChoice == 2)
                                    {
                                        Console.Write($"\n\t\t\t\t\tEnter the amount on Cheque : ");
                                        bool isCorrectAmountD = Double.TryParse(Console.ReadLine(), out amount);
                                        Console.Write($"\n\t\t\t\t\tEnter the Cheque Number : ");
                                        string? CheckNumber = Console.ReadLine();
                                        if (isCorrectAmountD && amount > 0 && AccountServices.IsAlphaNum(CheckNumber))
                                        {
                                            //using extension method to if cheque is valid or not
                                            if(CheckNumber.CheckValidation())
                                            {
                                                savingsAccount.Deposit(amount, CheckNumber);
                                                Console.Write($"\n\t\t\t\t\tCheck Deposit Successfull :)");
                                            } else
                                            {
                                                Console.Write($"\n\t\t\t\t\tInvalid Cheque Number , please retry again !!!");

                                            }

                                        }
                                        else
                                        {
                                            Console.Write($"\n\t\t\t\t\tInvalid Amount cannot Deposit !!!");
                                        }
                                    }
                                    else
                                    {
                                        Console.Write($"\n\t\t\t\t\tInvalid Option please Select a valid option ...");

                                    }
                                    break;

                                case 2:
                                    Console.Clear();
                                    Banner();
                                    Console.Write($"\n\t\t\t\t\tEnter amount to Withdraw: ");
                                    bool isCorrectAmount = Double.TryParse(Console.ReadLine(), out amount);
                                    if (isCorrectAmount && amount > 0)
                                    {
                                        savingsAccount.Withdraw(amount);
                                    }
                                    else
                                    {
                                        Console.Write($"\n\t\t\t\t\tInvalid amount cannot Withdraw !!!");
                                    }
                                    break;

                                case 3:
                                    Console.Clear();
                                    Banner();
                                    savingsAccount.CheckBalance();
                                    break;

                                case 4:
                                    Console.Clear();
                                    Banner();
                                    savingsAccount.AccountDetails();
                                    break;

                                case 5:
                                    Console.Clear();
                                    Banner();
                                    savingsAccount.InterestAmount();
                                    break;

                                case 6:
                                    Console.Clear();
                                    Banner();
                                    savingsAccount.GetTransactionLimit();
                                    break;

                                case 7:
                                    Console.Clear();
                                    Banner();
                                    savingsAccount.ResetTransactionLimit();
                                    break;

                                case 8:
                                    operation = false;
                                    break;

                                default:
                                    Console.Clear();
                                    Banner();
                                    Console.Write($"\n\t\t\t\t\tPlease enter a valid choice");
                                    break;
                            }
                        }
                        else
                        {
                            Console.Clear();
                            Banner();
                            Console.Write($"\n\t\t\t\t\tPlease enter a valid choice");
                        }

                    }
                    while (operation);
                       
                } 
                // for current account
                else if(userInput == 2)
                {

                    Console.Clear();
                    Banner();

                    CurrentAccount currentAccount = new CurrentAccount(_accountHolder);
                    BannerForAccountCreation();

                    Banner();
                    bool operation = true;

                    do
                    {
                        UserOptionsCurrent();
                        double amount;
                        int userInputSaving;
                        Console.Write($"\n\t\t\t\t\tChoice: ");
                        bool isUserInputSaving = int.TryParse(Console.ReadLine(), out userInputSaving);

                        if (isUserInputSaving)
                        {
                            //using switch case for choice options for current account

                            switch (userInputSaving)
                            {
                                case 1:
                                    Console.Clear();
                                    Banner();
                                    Console.Write($"\n\t\t\t\t\tEnter amount to Deposit: ");
                                    bool isCorrectAmountD = Double.TryParse(Console.ReadLine(), out amount);
                                    if (isCorrectAmountD && amount > 0)
                                    {
                                        currentAccount.Deposit(amount, true);

                                    }
                                    else
                                    {
                                        Console.Write($"\n\t\t\t\t\tInvalid amount cannot Deposit !!!");
                                    }

                                    break;

                                case 2:
                                    Console.Clear();
                                    Banner();
                                    Console.Write($"\n\t\t\t\t\tEnter amount to Withdraw: ");
                                    bool isCorrectAmount = Double.TryParse(Console.ReadLine(), out amount);
                                    if (isCorrectAmount && amount > 0)
                                    {
                                        currentAccount.Withdraw(amount);

                                    }
                                    else
                                    {
                                        Console.Write($"\n\t\t\t\t\tInvalid amount cannot withdraw !!!");
                                    }

                                    break;

                                case 3:
                                    Console.Clear();
                                    Banner();
                                    currentAccount.CheckBalance();
                                    break;

                                case 4:
                                    Console.Clear();
                                    Banner();
                                    currentAccount.AccountDetails();
                                    break;

                                case 5:
                                    operation = false;
                                    break;

                                default:
                                    Console.Clear();
                                    Banner();
                                    Console.Write($"\n\t\t\t\t\tPlease enter a valid choice");
                                    break;
                            }
                        }
                        else
                        {
                            Console.Clear();
                            Banner();
                            Console.Write($"\n\t\t\t\t\tPlease enter a valid choice");
                        }

                    }
                    while (operation);
                }


            } 
            // catch block to handle any exception
            catch(Exception ex)
            {
                Console.WriteLine($"\n\t\t\t\t\t{ex.Message}");
            }
        }
    }
}