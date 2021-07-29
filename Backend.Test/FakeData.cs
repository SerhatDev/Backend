using Backend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Test
{
    public static class FakeData
    {
        public static User GermanUser(decimal balance)
        {
            return new User()
            {
                Balance = balance,
                Name = "German User",
                Id = 1,
                Country = new Country()
                {
                    Id = 1,
                    Name = "Germany",
                    Deposit_Deduction = 10,
                    IsAllowedToWithdraw = false
                }
            };
        }
        public static User UKUser(decimal balance)
        {
            return new User()
            {
                Balance = balance,
                Name = "UK User",
                Id = 1,
                Country = new Country()
                {
                    Id = 2,
                    Name = "United Kingdom",
                    Deposit_Deduction = 0,
                    IsAllowedToWithdraw = true,
                    Min_Withdraw = 10
                }
            };
        }
    }
}
