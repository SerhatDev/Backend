using Backend.Models;

namespace Backend.Repositories.Interfaces
{
    public interface ITransactionRepository : IRepository<Transaction>
    {
        public TransactionResult Deposit(User user, decimal amount);
        public TransactionResult Withdraw(User user, decimal amount);
    }
}
