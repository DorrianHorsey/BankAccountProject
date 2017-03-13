using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;


namespace Bank_Account_Project
{
    public class Checking : Account
       
    {
        //FIELDS

        static List<string> listC = new List<string>();
        private static string accountType = "Checking";
        private static int accountNumber = 022705;
        static DateTime transactionTime = DateTime.Now;
         
        //CONSTRUCTORS

        public Checking (int userID, decimal accountBalance, string userName) : base(userID, accountBalance, userName)
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

         
        

        // METHODS

        public override void Deposit(decimal amount) //this method allows user to deposit money to checking account and writes the details of the transaction to a list that is then used when the Streamwriter method is called.
        {
            AccountBalance = AccountBalance += amount;
            
            Console.WriteLine("Thanks for your deposit! \n Your new balance for your checking account is " + AccountBalance);
            listC.Add("Client Name: " + userName + " " + accountType + " deposit " + " Account Number: " + accountNumber + " + " + amount + " Current Balance: $" + AccountBalance + "Time: " + transactionTime);
            CheckingToStream();
            System.Threading.Thread.Sleep(1000);
        }

        public override void Withdrawal (decimal amount) //this method allows user to withdraw money from checking account and writes the details of the transaction to a list that is then used when the Streamwriter method is called.
        {
            
            if (amount <= AccountBalance)
            {
                AccountBalance -= amount;
                Console.WriteLine("Thanks for your withdrawal. \n Your new checking account balance is " + AccountBalance);
                listC.Add("Client Name: " + userName + " " + accountType + " withdrawal " + " Account Number: " + accountNumber + " - " + amount + " Current Balance: $" + AccountBalance + "Time: " + transactionTime);
                CheckingToStream();
                System.Threading.Thread.Sleep(1000);
            }
            else  
            {
                AccountBalance -= amount;
                listC.Add("Client Name: " + userName + " " + accountType + " withdrawal " + " Account Number: " + accountNumber + " - " + amount + " Current Balance: $" + AccountBalance + "Time: " + transactionTime);
                CheckingToStream();
                Console.WriteLine("WARNING: Your checking account is now overdrafted. Please make a checking deposit." );
                System.Threading.Thread.Sleep(1000);
            }

            
        }

        public void ShowBalanceChecking() //method to show checking balance
        {
            Console.WriteLine(AccountBalance);
            System.Threading.Thread.Sleep(2000);
            Console.ReadLine();
        }

        static public void CheckingToStream() //method to write list of items in each transaction to text file
        {
            StreamWriter checking = new StreamWriter("CheckingTransactions.txt", true);
            using (checking)
            {
                foreach (string line in listC)
                {
                    checking.WriteLine(line);
                }
            }
        }
    }
}
