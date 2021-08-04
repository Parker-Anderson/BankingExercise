namespace BankingExercise.Library.Accounts
{
    public abstract class Account
    {
        // Private fields to protect Account owner and balance information. 
        private string _owner;
        private decimal _balance;
        public string Owner
        {
            get { return _owner; }
            private set { _owner = value; }
        }
        public decimal Balance
        {
            get { return _balance; }
            set { _balance = value; }
        }
        public Account() { }
        public Account(string owner, decimal balance)
        {
            Owner = owner;
            Balance = balance;
        }
    }
}
