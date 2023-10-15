// Program.cs
using Bank_Account;
using System;

class Program
{
    static void Main(string[] args)
    {
        // Create a ChequingAccount object
        BankAccount chequingAccount = new ChequingAccount("Bethany Anderson", 2345);

        // Print the initial object at the start of the month
        Console.WriteLine("Initial Chequing Account:");
        Console.WriteLine(chequingAccount);
        Console.WriteLine();

        // Apply transactions to the ChequingAccount object
        chequingAccount.Deposit(25.98);
        chequingAccount.Withdrawal(1300);
        chequingAccount.Withdrawal(1700);
        chequingAccount.Deposit(1050);
        chequingAccount.Withdrawal(1700);
        chequingAccount.Deposit(25.98);
        chequingAccount.Withdrawal(400);
        chequingAccount.Withdrawal(27);
        chequingAccount.Withdrawal(7.5);

        // Print the transaction record
        Console.WriteLine("Chequing Account Transactions:");
        chequingAccount.PrintTransactions();
        Console.WriteLine();

        // Print the object at the end of the month
        Console.WriteLine("Final Chequing Account:");
        Console.WriteLine(chequingAccount);
        Console.WriteLine();

        // Create a SavingsAccount object
        BankAccount savingsAccount = new SavingsAccount("Bethany Anderson", 6100);

        // Print the initial object at the start of the month
        Console.WriteLine("Initial Savings Account:");
        Console.WriteLine(savingsAccount);
        Console.WriteLine();

        // Apply transactions to the SavingsAccount object
        savingsAccount.Deposit(500.5);
        savingsAccount.Withdrawal(1000);
        savingsAccount.Deposit(250);
        savingsAccount.Withdrawal(3000.5);
        savingsAccount.Withdrawal(825.75);
        savingsAccount.Deposit(250);

        // Print the transaction record
        Console.WriteLine("Savings Account Transactions:");
        savingsAccount.PrintTransactions();
        Console.WriteLine();

        // Print the object at the end of the month
        Console.WriteLine("Final Savings Account:");
        Console.WriteLine(savingsAccount);
    }
}
