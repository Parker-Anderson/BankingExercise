using BankingExercise.Library.Accounts;
using System.Collections.Generic;

namespace BankingExercise.Library.Bank
{
    public class Bank
    {
        // public get for bank name as I assumed this information is not sensitive.
        public string Name { get; private set; }
        private IEnumerable<Account> _accounts;
        public IEnumerable<Account> Accounts
        {
            private get { return _accounts; }
            set { _accounts = value; }
        }

    }
}
