using System.Text.Json.Serialization;

namespace Backend.Models
{
    public class Transaction
    {
        public int Id { get; set; }
        public int UserId { get;set;  }
        public decimal Amount { get; set;}

        [JsonIgnore]
        public virtual User User { get; set; }
        public TransactionType TransactionType { get; set; }
    }

    public enum TransactionType : int
    {
        Deposit = 0,
        Withdraw = 1
    }
}
