using Microsoft.VisualStudio.TestTools.UnitTesting;
using BankingExercise.Library.Accounts.Checking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingExercise.Library.Accounts.Checking.Tests
{
    [TestClass()]
    public class CheckingTests
    {
        // TODO: try/catch block and effective exception handling for deposit/withdrawal amount edge cases and build out sad path testing approach.
        [TestMethod()]
        public void DepositTest()
        {
            //Arrange
            var initialBalance = 750;
            var amount = 500;
            var expected = initialBalance + amount;

            var account = new Checking("owner", 750);

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

            var account = new Checking("owner", 750);
            
            //Act
            account.Withdrawal(amount);

            //Assert
            Assert.AreEqual(account.Balance, expected);
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

            var sendingAccount = new Checking("owner", 750);
            var receivingAccount = new Checking("owner", 750);

            //Act
            sendingAccount.SendTransfer(amount, receivingAccount);

            //Assert
            Assert.AreEqual(sendingAccount.Balance, expectedSendingBalance);
            Assert.AreEqual(receivingAccount.Balance, expectedReceivingBalance);
            

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

            var sendingAccount = new Checking("owner", 750);
            var receivingAccount = new Checking("owner", 750);

            //Act
            receivingAccount.ReceiveTransfer(amount, sendingAccount);

            //Assert
            Assert.AreEqual(sendingAccount.Balance, expectedSendingBalance);
            Assert.AreEqual(receivingAccount.Balance, expectedReceivingBalance);

        }
        // Note: I chose to test my invalid amount errors from within CheckingTests.  The handling methods for these are the same on other accounts.
        [TestMethod()]
        [ExpectedException(typeof(Exception))]
        public void VerifyExceptionForNegativeAmount()
        {
            //Arrange
            var amount = -500;
            var account = new Checking("owner", 750);

            //Act
            account.Deposit(amount);

            //Assert occurs with [ExpectedException] attribute.
            
        }
        [TestMethod()]
        [ExpectedException(typeof(Exception))]
        public void VerifyExceptionForZeroAmount()
        {
            //Arrange
            var amount = 0;
            var account = new Checking("owner", 750);

            //Act
            account.Deposit(amount);

            //Assert occurs with [ExpectedException] attribute.

        }
    }
}