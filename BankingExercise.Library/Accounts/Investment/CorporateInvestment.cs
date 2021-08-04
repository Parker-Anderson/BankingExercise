namespace BankingExercise.Library.Accounts.Investment
{
    public class CorporateInvestment : Investment
    {
        // I abstracted the Investment account type and had Corporate/Individual inherit from it. As there were no additional specifications for
        // Corporate, I just kept the base members as-is.

        public CorporateInvestment(string owner, decimal balance) : base(owner, balance) { }
    }
}
