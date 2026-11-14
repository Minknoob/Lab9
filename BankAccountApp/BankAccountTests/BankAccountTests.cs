using Xunit;
using BankAccountApp;
using System;

namespace BankAccountTests
{
    public class BankAccountTests
    {
        [Theory]
        [InlineData("John Doe", 1000, 200, 800)]
        [InlineData("Jane Smith", 500, 100, 400)]
        [InlineData("Alice Johnson", 300, 50, 250)]
        public void Debit_ValidAmount_UpdatesBalance(string customerName, decimal initialBalance, decimal debitAmount, decimal expectedBalance)
        {
            var account = new BankAccount(customerName, initialBalance);

            account.Debit(debitAmount);

            Xunit.Assert.Equal(expectedBalance, account.Balance);
        }

        [Theory]
        [InlineData("Bob Brown", 100, 150)]
        public void Debit_InsufficientFunds_ThrowsException(string customerName, decimal initialBalance, decimal debitAmount)
        {
            var account = new BankAccount(customerName, initialBalance);

            Xunit.Assert.Throws<InvalidOperationException>(() => account.Debit(debitAmount));
        }

        [Theory]
        [InlineData("John Doe", 1000, 200, 1200)]
        [InlineData("Jane Smith", 500, 100, 600)]
        [InlineData("Alice Johnson", 300, 50, 350)]
        public void Credit_ValidAmount_UpdatesBalance(string customerName, decimal initialBalance, decimal creditAmount, decimal expectedBalance)
        {
            var account = new BankAccount(customerName, initialBalance);

            account.Credit(creditAmount);

            Xunit.Assert.Equal(expectedBalance, account.Balance);
        }

        [Theory]
        [InlineData("John Doe", 1000, 200, 800)]
        [InlineData("Jane Smith", 500, 100, 400)]
        [InlineData("Alice Johnson", 300, 50, 250)]
        public void Withdraw_ValidAmount_UpdatesBalance(string customerName, decimal initialBalance, decimal withdrawAmount, decimal expectedBalance)
        {
            var account = new BankAccount(customerName, initialBalance);

            account.Withdraw(withdrawAmount);

            Xunit.Assert.Equal(expectedBalance, account.Balance);
        }
    }
}