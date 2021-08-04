using System;

namespace BankingExercise.Library.Accounts.Checking
{
    public class Checking : Account
    {
        public Checking(string owner, decimal balance) : base(owner, balance) { }

        public void Deposit(decimal amount)
        {
            NegativeAmountHelper(amount);
            Balance += amount;
        }
        // I did not set a withdrawal limit for Checking accounts as I assumed there can be Business as well as Individual Checking types.  
        public void Withdrawal(decimal amount)
        {
            NegativeAmountHelper(amount);
            Balance -= amount;
        }

        public void SendTransfer(decimal amount, Account receivingAccount)
        {
            NegativeAmountHelper(amount);
            receivingAccount.Balance += amount;
            Balance -= amount;
        }

        public void ReceiveTransfer(decimal amount, Account sendingAccount)
        {
            NegativeAmountHelper(amount);
            sendingAccount.Balance -= amount;
            Balance += amount;
        }
        // I created this handler method to catch negative and zero values for transaction amounts, because I assumed these are invalid.
        private static void NegativeAmountHelper(decimal amount)
        {
            if (amount <= 0)
            {
                throw new Exception("Amount invalid");
            }
        }

    }
}
