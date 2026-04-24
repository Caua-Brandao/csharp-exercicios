using System;


namespace BankExercice.Entities
{
    internal class Account
    {
        public int Number { get; set; }
        public string Holder { get; set; }
        public double Balance { get; set; }
        public double WithDrawLimit { get; set; }

        public Account(int number, string holder, double balance, double withdrawlimit)
        {
            this.Number = number;
            this.Holder = holder;
            this.Balance = balance;
            this.WithDrawLimit = withdrawlimit;
        }

        public void Deposit(double amount)
        {

            if (amount<=0)
            {
                throw new BankException("Deposit amount must be positive");
            }
            Balance += amount;

        }
        public void WithDraw(double amount)
        {
            if (amount<=0)
            {
                throw new BankException("WithDraw amout must be positive");
            }
            else if (amount > WithDrawLimit)
            {
                throw new BankException("Amount must not exceed the WithDraw Limit.");
            }
            else if (amount > Balance)
            {
                throw new BankException("Amount must not exceed the balance.");
            }
            Balance -= amount;
        }
    }
}
