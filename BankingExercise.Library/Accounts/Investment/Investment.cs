using System;
namespace BankingExercise.Library.Accounts.Investment
{
    public abstract class Investment : Account
    {
        public Investment(string owner, decimal balance) : base(owner, balance) { }
        public void Deposit(decimal amount)
        {
            NegativeAmountHelper(amount);
            Balance += amount;
        }
        // virtual for the following two methods because Withdrawals on Individual accounts need to override these.
        public virtual void Withdrawal(decimal amount)
        {
            NegativeAmountHelper(amount);
            Balance -= amount;
        }
        public virtual void SendTransfer(Account receivingAccount, decimal amount)
        {
            NegativeAmountHelper(amount);
            receivingAccount.Balance += amount;
            Balance -= amount;
        }
        public void ReceiveTransfer(Account sendingAccount, decimal amount)
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
