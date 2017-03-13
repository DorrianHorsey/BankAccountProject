using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank_Account_Project
{
    class Program
    {
        static void Main(string[] args)
        {
            int userInput; //declare variable to store user menu selection
 
            decimal userWithdrawalAmount;
            decimal userDepositAmount;

            Console.WriteLine("Hello, welcome to WCCI Bank. Please enter your first name.");
            string firstName = (Console.ReadLine());
            Console.WriteLine("Please enter your last name");
            string lastName = (Console.ReadLine());
            string userName = (firstName + " " + lastName);
            Console.Clear();
            Console.WriteLine("Welcome back " + userName);


            Checking accountc = new Checking(120875, 5000, userName);
            Savings accounts = new Savings(120875, 10000, userName);
            Reserve accountr = new Reserve(120875, 1500, userName);

            do
            {
                Console.WriteLine("Here is your current account information:\n");
                Console.WriteLine("User ID: {0}", accountc.UserID);
                Console.WriteLine("Checking Account Balance: {0:C}", accountc.AccountBalance);
                Console.WriteLine("Reserve Account Balance: {0:C}", accountr.AccountBalance);
                Console.WriteLine("Savings Account Balance: {0:C}\n\n\n", accounts.AccountBalance);

                Console.WriteLine("How can we help you today?");
                Console.WriteLine("Please enter a number from the menu below. \n");
                Console.WriteLine("CHECKING ACCOUNT \n 1: Deposit Funds " + "2: Withdraw Funds " +  "3: Show Balance");
                Console.WriteLine("RESERVE ACCOUNT  \n 4: Deposit Funds " + "5: Withdraw Funds " + "6: Show Balance");
                Console.WriteLine("SAVINGS ACCOUNT  \n 7: Deposit Funds " + "8: Withdraw Funds " + "9: Show Balance");
                Console.WriteLine("VIEW CLIENT INFORMATION: 10 \n \nEXIT: \n 11");

                userInput = int.Parse(Console.ReadLine());

                if (userInput == 1) //conditional statement that addresses checking deposit.
                {
                    Console.WriteLine("How much do you want deposit to your checking account?");
                    userDepositAmount = decimal.Parse(Console.ReadLine());
                    accountc.Deposit(userDepositAmount); //call method that corresponds with checking deposit
                    Console.WriteLine("Thank you for your deposit!");
                    Console.WriteLine("Please press any key to return to main menu");
                    Console.ReadLine();

                }
                else if (userInput == 2)
                {
                    // conditional statement that addresses checking withdrawal
                    Console.WriteLine("How much do you want to withdraw from your checking account?");
                    userWithdrawalAmount = decimal.Parse(Console.ReadLine());

                    accountc.Withdrawal(userWithdrawalAmount); //call method that corresponds with checking withdrawal
                    Console.WriteLine("Please press enter to return to main menu");
                    Console.ReadLine();
                }

                else if (userInput == 3) //shows checking account balance
                {
                    accountc.ShowBalanceChecking();
                    System.Threading.Thread.Sleep(1000);
                }
                     

                else if (userInput == 4)
                {
                    //conditional statement that addresses reserve account deposit

                    Console.WriteLine("How much do you want deposit to your reserve account?");
                    userDepositAmount = decimal.Parse(Console.ReadLine());
                    accountr.Deposit(userDepositAmount); //call method that corresponds to reserve deposit
                    Console.WriteLine("Thank you for your deposit!");
                    Console.WriteLine("Please press enter to return to main menu");
                    Console.ReadLine();
                }
                else if (userInput == 5)
                {
                    //conditional statement that addresses reserve account withdrawal
                    Console.WriteLine("How much do you want to withdraw from your reserve account?");
                    userWithdrawalAmount = decimal.Parse(Console.ReadLine());

                    accountr.Withdrawal(userWithdrawalAmount); //call method that corresponds to reserve withdrawal
                    Console.WriteLine("Please press enter to return to main menu");
                    Console.ReadLine();
                }
                
                else if (userInput ==6) //shows reserve account balance
                {
                    accountr.ShowBalanceReserve();
                    Console.ReadLine();
                }        
                
                
                
                else if (userInput == 7)
                {
                    //conditional statement that addresses savings account deposit
                    Console.WriteLine("How much do you want deposit to your savings account?");
                    userDepositAmount = decimal.Parse(Console.ReadLine());
                    accounts.Deposit(userDepositAmount); //call method that corresponds to savings deposit
                    Console.WriteLine("Thank you for your deposit!");
                    Console.WriteLine("Please press enter to return to main menu");
                    Console.ReadLine();
                }
                else if (userInput == 8)
                {
                    //conditional statement that addresses savings account withdrawal 
                    Console.WriteLine("How much do you want to withdraw?");
                    userWithdrawalAmount = decimal.Parse(Console.ReadLine());

                    accounts.Withdrawal(userWithdrawalAmount); //call method that corresponds to savings withdrawal
                    Console.WriteLine("Please press enter to return to main menu");
                    Console.ReadLine();
                }

                else if (userInput == 9)
                {
                    accounts.ShowBalanceSavings();
                    Console.ReadLine();
                }

                else if (userInput == 10)
                {
                    //conditional statement that displays client information
                    Console.Clear();
                    Console.WriteLine("\n\n\nCLIENT NAME: " + userName + "\nUSER ID:" + accountc.UserID + "\nADDRESS: 120875 Happy Lane, Cleveland, OH 44120 \nACCOUNTHOLDER SINCE: 2010");
                    System.Threading.Thread.Sleep(4000);
                    Console.WriteLine("Please press enter to return to main menu");
                    Console.ReadLine();
                }
                else if (userInput == 11)
                {
                    //conditional statement that calls method to quit the program
                    accountc.Quit();
                }
                else
                { //conditional statement that addresses answers that don't fall between numbers 1-11
                    Console.WriteLine("Sorry, I don't understand this selection. ");
                    Console.WriteLine("Please press enter to return to the main menu");
                    Console.ReadLine();
                }
            } while (userInput != 11);

        }
    }
}
