using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank_Account_Project
{
    public class Account
    {
        //Fields
        private int userID;
        private decimal accountBalance;
        public decimal amount;
        public string userName;
        //   private decimal interestRate;



        //Constructors

        public Account()
        {

        }

        public Account(int UserID, decimal AccountBalance, string UserName)

        {
            userID = UserID;
            accountBalance = AccountBalance;
            userName = UserName;

        }

        //PROPERTIES

        public int UserID
        {
            get { return this.userID; }
            set { this.userID = value; }
        }

        public decimal AccountBalance
        {
            get { return this.accountBalance; }
            set { this.accountBalance = value; }
        }

        public decimal Amount
        {
            get { return this.amount; }
            set { this.amount = value; }
        }

       
        // METHODS

        public virtual void Deposit(decimal amount)     
        {
            AccountBalance = AccountBalance += amount;
            DateTime transactionTime = DateTime.Now;
            Console.WriteLine("Your account balance is " + AccountBalance);
            System.Threading.Thread.Sleep(1000);
        }

        public virtual void Withdrawal(decimal amount)
        {
            AccountBalance = AccountBalance -= amount;
            DateTime transactionTime = DateTime.Now;
            Console.WriteLine("Your new balance for this account is $" + AccountBalance);
            System.Threading.Thread.Sleep(1000);
        }

        public void Quit()
        {
            Console.WriteLine("\n \n Thanks for visiting WCCI Bank!");
            System.Threading.Thread.Sleep(1000);
        }
    }
}

        
    



    