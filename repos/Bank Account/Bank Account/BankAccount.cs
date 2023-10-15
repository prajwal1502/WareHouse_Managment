using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank_Account
{
    abstract class BankAccount
    {
        public string accountNumber;
        public string customerName;
        public double balance;

        public BankAccount(string customerName, double balance)
        {
            this.customerName = customerName;
            this.balance = balance;
            accountNumber = GenerateAccountNumber();
        }

        private string GenerateAccountNumber()
        {
            Random random = new Random();
            string accountTypeNumber = (this is ChequingAccount) ? "550" : "790";
            return $"002-623490-{random.Next(100000, 999999)}-{accountTypeNumber}";
        }

        public abstract void Withdrawal(double amount);
        public abstract void Deposit(double amount);

        public override string ToString()
        {
            return $"Customer Name: {customerName}\nAccount Type: {this.GetType().Name}\nCurrent Month: {DateTime.Now.ToString("MMMM")}\nAccount Number: {accountNumber}\nBalance: {balance:C2}";
        }
    }
}
