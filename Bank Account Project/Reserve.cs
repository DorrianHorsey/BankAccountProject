using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank_Account_Project
{
    public class Reserve : Account
    {
        //FIELDS

        List<string> listR = new List<string>();
        private static string accountType = "Reserve";
        private static int accountNumber = 090413;
        DateTime transactionTime = DateTime.Now;

        //CONSTRUCTORS

        public Reserve(int userID, decimal accountBalance, string userName) : base(userID, accountBalance, userName)
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

        public override void Deposit(decimal amount) //this method allows user to deposit money to reserve account and writes the details of the transaction to a list that is then used when the Streamwriter method is called.
        {
            AccountBalance = AccountBalance += amount;
            Console.WriteLine("Thanks for your deposit! \n Your new balance for your reserve account is " + AccountBalance);
            listR.Add("Client Name: " + userName + " "+ accountType + " deposit " + " Account Number: " + accountNumber + " + " + amount + " Current Balance: $" + AccountBalance + "Time: " + transactionTime);
            ReserveToStream();
            System.Threading.Thread.Sleep(1000);
        }

        public override void Withdrawal(decimal amount) //this method allows user to withdraw money from reserve account and writes the details of the transaction to a list that is then used when the Streamwriter method is called.
        {

            if (amount <= AccountBalance)
            {
                AccountBalance -= amount;
                Console.WriteLine("Thanks for your withdrawal. \n Your new reserve account balance is $" + AccountBalance);
                listR.Add("Client Name: " + userName + " " + accountType + " withdrawal " + " Account Number: " + accountNumber + " - " + amount + " Current Balance: $" + AccountBalance + "Time: " + transactionTime);
                ReserveToStream();
                System.Threading.Thread.Sleep(1000);
            }
            else
            {
                AccountBalance -= amount;
                Console.WriteLine("WARNING: Your reserve account is now overdrafted. Please make a reserve deposit.");
            }
        }

            public void ReserveToStream()
        {
            StreamWriter reserve = new StreamWriter("ReserveTransactions.txt", true);
            using (reserve)
            {
                foreach (string line in listR)
                {
                    reserve.WriteLine(line);
                }
            }
        }
        public void ShowBalanceReserve()
        {
            Console.WriteLine(AccountBalance);
            Console.ReadLine();
        }
    }
    }

