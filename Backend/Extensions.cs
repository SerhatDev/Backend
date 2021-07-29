using Microsoft.Extensions.DependencyInjection;
using Backend.Repositories;
using Backend.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using Backend.Models;

namespace Backend
{
   public static class Extensions
    {
        /// <summary>
        /// Add Repositories used for Database operations to DI
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        public static IServiceCollection AddBackendServices(this IServiceCollection services)
        {
            return services.AddScoped<IUserRepository, UserRepository>()
                           .AddScoped<ICountryRepository, CountryRepository>()
                           .AddScoped<ITransactionRepository, TransactionRepository>();
        }

        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Country>().HasData(
                new Country
                {
                    Id= 1, 
                    Name ="Germany",
                    Deposit_Deduction=10,
                    IsAllowedToWithdraw=false
                },
                new Country
                {
                    Id = 2,
                    Name = "United Kingdom",
                    Deposit_Deduction = 0,
                    IsAllowedToWithdraw = true,
                    Min_Withdraw=10
                }
            );
            modelBuilder.Entity<User>().HasData(
                new User { Id = 1, Name="German User",CountryId=1,Balance=0 },
                new User { Id = 2, Name = "UK User", CountryId = 2, Balance = 0 }
            );
        }
    }
}
