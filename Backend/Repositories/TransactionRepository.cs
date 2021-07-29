using Backend.Models;
using Backend.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Backend.Repositories
{
    public class TransactionRepository : ITransactionRepository
    {
        private readonly AppDbContext _appDbContext;

        public TransactionRepository()
        {

        }

        public TransactionRepository(AppDbContext appDbContext)
        {
            this._appDbContext = appDbContext;
        }

        public bool Add(Transaction entity)
        {
            _appDbContext.Transactions.Add(entity);
            return _appDbContext.SaveChanges() > 0;
        }

        public TransactionResult Deposit(User user, decimal amount)
        {
            decimal newBalance = user.Balance;

            var transactionResult = Deposit(user, amount, out newBalance);

            if (transactionResult.result == false)
                return transactionResult;

            Transaction transaction = new Transaction();
            transaction.UserId = user.Id;
            transaction.TransactionType = TransactionType.Deposit;
            transaction.Amount = amount;

            user.Balance = newBalance;
            _appDbContext.Transactions.Add(transaction);
            _appDbContext.Users.Update(user);

            return new TransactionResult()
            {
                result = _appDbContext.SaveChanges() > 0,
                exceptionMessage = string.Empty
            };
        }

        public TransactionResult Deposit(User user, decimal amount, out decimal finalBalance)
        {
            finalBalance = user.Balance;
            if (user.Country.Min_Deposit >= amount)
            {
                return new TransactionResult()
                {
                    result = false,
                    exceptionMessage = $"You need to deposit minimum ${user.Country.Min_Deposit}"
                };
            }

            if (user.Country.Deposit_Deduction >= amount)
            {
                return new TransactionResult()
                {
                    result = false,
                    exceptionMessage = $"You need to deposit minimum ${user.Country.Deposit_Deduction + 1}"
                };
            }

            finalBalance = user.Balance + amount - user.Country.Deposit_Deduction;
            return new TransactionResult()
            {
                result = true
            };
        }

        public List<Transaction> GetAll()
        {
            return _appDbContext.Transactions.ToList();
        }

        public List<Transaction> Query(Func<Transaction, bool> predicate)
        {
            return _appDbContext.Transactions.Where(predicate).ToList();
        }

        public bool Remove(Transaction entity)
        {
            throw new NotSupportedException("Deleting a transaction is not supported!");
        }

        public bool Update(Transaction entity)
        {
            throw new NotSupportedException("Updating a transaction is not supported!");
        }

        public TransactionResult Withdraw(User user, decimal amount)
        {

            decimal newBalance = 0;
            var withdrawResult = Withdraw(user, amount, out newBalance);

            if (withdrawResult.result == false)
                return withdrawResult;


            Transaction transaction = new Transaction();
            transaction.UserId = user.Id;
            transaction.TransactionType = TransactionType.Withdraw;
            transaction.Amount = amount;

            user.Balance = newBalance;
            _appDbContext.Transactions.Add(transaction);
            _appDbContext.Users.Update(user);

            return new TransactionResult()
            {
                result = _appDbContext.SaveChanges() > 0,
                exceptionMessage = string.Empty
            };
        }

        public TransactionResult Withdraw(User user, decimal amount, out decimal finalBalance)
        {
            finalBalance = user.Balance;
            if (user.Country.Name == "Germany")
                return new TransactionResult()
                {
                    result = false,
                    exceptionMessage = "German citizens aren't allowed to withdraw!"
                };

            if (user.Country.Min_Withdraw > amount)
            {
                return new TransactionResult()
                {
                    result = false,
                    exceptionMessage = $"You need to withdraw minimum ${user.Country.Min_Withdraw}"
                };
            }

            if (user.Balance < amount)
                return new TransactionResult()
                {
                    result = false,
                    exceptionMessage = "You don't have enough balance to do this transaction!"
                };

            finalBalance = user.Balance - amount;
            return new TransactionResult()
            {
                result = true,exceptionMessage=$"{user.Balance} - {amount}"
            };
        }
    }
}
