using System;

namespace BankingExercise.Library.Accounts.Investment
{
    public class IndividualInvestment : Investment
    {
        public IndividualInvestment(string owner, decimal balance) : base(owner, balance)
        {
        }
        // Withdrawals (and Transfers-From) on Individual Investment Accounts are the only methods I override because these accounts are the only 
        // accounts explicitly defined as Individual (i.e. requiring a withdrawal limit).
        public override void Withdrawal(decimal amount)
        {
            NegativeAmountHelper(amount);
            WithdrawalLimitHelper(amount);
            Balance -= amount;
        }
        // I made the assumption that a transfer-from an Individual account would be treated as a withdrawal with respect to limits.
        public override void SendTransfer(Account receivingAccount, decimal amount)
        {
            NegativeAmountHelper(amount);
            WithdrawalLimitHelper(amount);
            base.SendTransfer(receivingAccount, amount);
        }

        // I assumed negative signed numbers for transaction amounts would be invalid, and created this handler method to catch these.
        private static void NegativeAmountHelper(decimal amount)
        {
            if (amount <= 0)
            {
                throw new Exception("Amount invalid");
            }
        }
        // Helper method for withdrawal and transfer-from amounts exceeding limit.
        private static void WithdrawalLimitHelper(decimal amount)
        {
            if (amount > 500M)
            {
                throw new Exception("Amount cannot exceed $500.");
            }
        }

    }
}
