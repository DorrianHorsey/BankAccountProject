using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace Bank_Account_Project
{
    public class Savings : Account

    {
        //FIELDS

        List<string> listS = new List<string>();
        private static string accountType = "Savings";
        private static int accountNumber = 092507;
        DateTime transactionTime = DateTime.Now;

        //CONSTRUCTORS

        public Savings(int userID, decimal accountBalance, string userName) : base(userID, accountBalance, userName)
        {

        }

        //PROPERTIES

        public int AccountNumber
        {
            get { return this.AccountNumber; }
            set { this.AccountNumber = value; }
        }

        public string AccountType
        {
            get { return this.AccountType; }
            set { this.AccountType = value; }
        }

        //METHODS
        public override void Deposit(decimal amount) //this method allows user to deposit money to savings account and writes the details of the transaction to a list that is then used when the Streamwriter method is called.
        {
            AccountBalance = AccountBalance += amount;
            
            Console.WriteLine("Thanks for your deposit! \n Your new balance for your saving account is " + AccountBalance);
            listS.Add("Client Name: " + userName + " " + accountType + " deposit " + " Account Number: " + accountNumber + " + " + amount + " Current Balance: $" + AccountBalance + "Time: " + transactionTime);
            SavingsToStream();
            System.Threading.Thread.Sleep(1000);
        }

        public override void Withdrawal(decimal amount) //this method allows user to deposit money to savings account and writes the details of the transaction to a list that is then used when the Streamwriter method is called.
        {

            if (amount <= AccountBalance)
            {
                AccountBalance -= amount;
                Console.WriteLine("Thanks for your withdrawal. \n Your new savings account balance is " + AccountBalance);
                listS.Add("Client Name: " + userName + " " + accountType + " withdrawal " + " Account Number: " + accountNumber + " - " + amount + " Current Balance: $" + AccountBalance + "Time: " + transactionTime);
                System.Threading.Thread.Sleep(1000);
            }
            else
            {
                AccountBalance -= amount;
                listS.Add("Client Name: " + userName + " " + accountType + " withdrawal " + " Account Number: " + accountNumber + " - " + amount + " Current Balance: $" + AccountBalance + "Time: " + transactionTime);
                Console.WriteLine("WARNING: Your savings account is now overdrafted. Please make a savings deposit.");
            }
        }

            public void SavingsToStream()
        {
            StreamWriter savings = new StreamWriter("SavingsTransactions.txt", true);
            using (savings)
            {
                
                foreach (string line in listS)
                {
                    savings.WriteLine(line);
                }
            }
        }
        public void ShowBalanceSavings()
        {
            Console.WriteLine(AccountBalance);
            System.Threading.Thread.Sleep(2000);
            Console.ReadLine();
        }
    }

    }

