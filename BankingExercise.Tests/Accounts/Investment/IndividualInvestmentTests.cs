using Microsoft.VisualStudio.TestTools.UnitTesting;
using BankingExercise.Library.Accounts.Investment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingExercise.Library.Accounts.Investment.Tests
{
    [TestClass()]
    public class IndividualInvestmentTests
    {
        [TestMethod()]
        public void DepositTest()
        {
            //Arrange
            var initialBalance = 750;
            var amount = 500;
            var expected = initialBalance + amount;

            var account = new IndividualInvestment("owner", 750);

            //Act
            account.Deposit(amount);

            //Assert
            Assert.AreEqual(account.Balance, expected);
        }

        [TestMethod()]
        public void WithdrawalTest()
        {
            //Arrange
            var initialBalance = 750;
            var amount = 500;
            var expected = initialBalance - amount;

            var account = new IndividualInvestment("owner", 750);

            //Act
            account.Withdrawal(amount);

            //Assert
            Assert.AreEqual(account.Balance, expected);
        }
        [TestMethod()]
        [ExpectedException(typeof(Exception))]
        public void WithdrawalLimitTest()
        {
            //Arrange
            var amount = 500.01M;
            var account = new IndividualInvestment("owner", 750);

            //Act
            account.Withdrawal(amount);

            //Assert occurs with [ExpectedException] attribute.
        }

        [TestMethod()]
        public void SendTransferTest()
        {
            //Arrange
            var initialSendingBalance = 750;
            var initialReceivingBalance = 750;
            var amount = 500;
            var expectedSendingBalance = initialSendingBalance - amount;
            var expectedReceivingBalance = initialReceivingBalance + amount;

            var sendingAccount = new IndividualInvestment("owner", 750);
            var receivingAccount = new IndividualInvestment("owner", 750);

            //Act
            sendingAccount.SendTransfer(receivingAccount, amount);

            //Assert
            Assert.AreEqual(sendingAccount.Balance, expectedSendingBalance);
            Assert.AreEqual(receivingAccount.Balance, expectedReceivingBalance);
        }
        //I assumed a Send-Transfer can be treated as a withdrawal. Test for Transfer amount over $500.
        [TestMethod()]
        [ExpectedException(typeof(Exception))]
        public void ExpectExceptionForTransferLimit()
        {
            //Arrange
            var amount = 500.01M;
            var sendingAccount = new IndividualInvestment("owner", 750);
            var receivingAccount = new IndividualInvestment("owner", 750);

            //Act
            sendingAccount.SendTransfer(receivingAccount, amount);

            //Assert occurs with [ExpectedException] attribute.
        }


        [TestMethod()]
        public void ReceiveTransferTest()
        {
            //Arrange
            var initialSendingBalance = 750;
            var initialReceivingBalance = 750;
            var amount = 500;
            var expectedSendingBalance = initialSendingBalance - amount;
            var expectedReceivingBalance = initialReceivingBalance + amount;

            var sendingAccount = new IndividualInvestment("owner", 750);
            var receivingAccount = new IndividualInvestment("owner", 750);

            //Act
            receivingAccount.ReceiveTransfer(sendingAccount, amount);

            //Assert
            Assert.AreEqual(sendingAccount.Balance, expectedSendingBalance);
            Assert.AreEqual(receivingAccount.Balance, expectedReceivingBalance);
        }
    }
}