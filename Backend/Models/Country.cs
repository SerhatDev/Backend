using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Backend.Models
{
    public class Country
    {
        public int Id { get; set; }
        public string Name { get; set; }   

        public bool IsAllowedToWithdraw { get; set; }
        public decimal Min_Deposit { get; set; }
        public decimal Min_Withdraw { get; set; }
        public decimal Deposit_Deduction { get; set; }
        public decimal Withdraw_Deduction { get; set; }
        
        [JsonIgnore]
        public virtual IList<User> Users { get; set; }
    }
}