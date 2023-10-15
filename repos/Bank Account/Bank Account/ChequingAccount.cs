using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank_Account
{
    class ChequingAccount : BankAccount
    {
        private int withdrawals;
        private int deposits;
        private List<Transaction> record;

        public ChequingAccount(string customerName, double balance) : base(customerName, balance)
        {
            withdrawals = 0;
            deposits = 0;
            record = new List<Transaction>();
        }

        public override void Withdrawal(double amount)
        {
            string transaction = "Withdrawal";
            if (balance - amount >= 0)
            {
                balance -= amount;
                withdrawals++;
            }
            else
            {
                transaction = "Transaction cancelled. Insufficient funds.";
            }

            recordTransaction(transaction, amount);
        }

        public override void Deposit(double amount)
        {
            balance += amount;
            deposits++;
            recordTransaction("Deposit", amount);
        }

        private void recordTransaction(string transaction, double amount)
        {
            record.Add(new Transaction(DateTime.Now.Month, DateTime.Now.Day, transaction, amount, balance));
        }

        public void PrintTransactions()
        {
            Console.WriteLine("Transactions:");
            foreach (Transaction transaction in record)
            {
                Console.WriteLine(transaction);
            }

            Console.WriteLine($"Number of Withdrawals: {withdrawals}");
            Console.WriteLine($"Number of Deposits: {deposits}");
            Console.WriteLine($"Balance: {balance:C2}");
        }
    }
}
