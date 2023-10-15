using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank_Account
{
    class Transaction
    {
        public int month;
        public int day;
        public string transaction;
        public double amount;
        public double balance;

        public Transaction(int month, int day, string transaction, double amount, double balance)
        {
            this.month = month;
            this.day = day;
            this.transaction = transaction;
            this.amount = amount;
            this.balance = balance;
        }

        public override string ToString()
        {
            return $"{month} {day} {transaction}: {amount:C2} Balance: {balance:C2}";
        }
    }
}
