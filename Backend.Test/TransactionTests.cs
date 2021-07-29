using Backend.Models;
using Backend.Repositories;
using System;
using Xunit;

namespace Backend.Test
{
    public class TransactionTests
    {
        private TransactionRepository transactionRepository = new TransactionRepository();



        [Fact]
        public void GermanUser_Withdraw()
        {
            var germanUser = FakeData.GermanUser(10);

            decimal finalBalance = 0;
            var transactionResult = transactionRepository.Withdraw(germanUser, 5, out finalBalance);

            // Result should be false because german citizen are not allowed to withdraw at all
            Assert.True(transactionResult.result == false);
        }

        [Fact]
        public void GermanUser_ValidDeposit()
        {
            var germanUser = FakeData.GermanUser(10);
            decimal finalBalance = 0;
            decimal firstBalance = 10;

            var transactionResult = transactionRepository.Deposit(germanUser, 11, out finalBalance);

            // Result should be true and also, $10 deduction had to be applied
            Assert.True(transactionResult.result == true && finalBalance - firstBalance == 1);
        }

        [Fact]
        public void UKUser_ValidWithdraw()
        {
            decimal finalBalance = 0;
            var ukUser = FakeData.UKUser(10);
            var transactionResult = transactionRepository.Withdraw(ukUser, 10, out finalBalance);

            // Result should be true and also final balance have to be $0
            Assert.True(transactionResult.result == true && finalBalance == 0, transactionResult.exceptionMessage);
        }

        [Fact]
        public void UKUser_Deposit()
        {
            var ukUser = FakeData.UKUser(0);
            decimal finalBalance = 0;

            var transactionResult = transactionRepository.Deposit(ukUser, 10, out finalBalance);

            // Result should be true and also, no deduction had to be applied
            Assert.True(transactionResult.result == true && finalBalance == 10);
        }

        [Fact]
        public void UKUser_NotEnoughBalanceToWithdraw()
        {
            var ukUser = FakeData.UKUser(0);
            decimal finalBalance = 0;

            var transactionResult = transactionRepository.Withdraw(ukUser, 10, out finalBalance);

            // Result should be false because this user doesn't have enough balance
            Assert.True(transactionResult.result == false);
        }

        [Fact]
        public void UKUser_Withdraw_MinimumAmountReqNotMet()
        {
            var ukUser = FakeData.UKUser(50);
            decimal finalBalance = 0;

            var transactionResult = transactionRepository.Withdraw(ukUser, 5, out finalBalance);

            // Result should be false because for an UKUser minimum Withdraw amount is $10
            Assert.True(transactionResult.result == false && finalBalance==50);
        }

    }
}