using Backend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using Backend.Repositories.Interfaces;



namespace Backend.Repositories
{
    public class CountryRepository : ICountryRepository
    {
        private readonly AppDbContext _appDbContext;
        public CountryRepository(AppDbContext appDbContext)
        {
            this._appDbContext = appDbContext;
        }
        public bool Add(Country entity)
        {
            _appDbContext.Countrys.Add(entity); ;
            return _appDbContext.SaveChanges() > 0;
        }

        public List<Country> GetAll()
        {
            return _appDbContext.Countrys.ToList();
        }

        public List<Country> Query(Func<Country, bool> predicate)
        {
            return _appDbContext.Countrys.Where(predicate).ToList();
        }

        public bool Remove(Country entity)
        {
            var countryToRemove = _appDbContext.Countrys.Where(x => x.Id == entity.Id).SingleOrDefault();
            if (countryToRemove == null)
                return false;

            _appDbContext.Countrys.Remove(entity);

            return _appDbContext.SaveChanges() > 0;
        }

        public bool Update(Country entity)
        {
            var countryToUpdate = _appDbContext.Countrys.Where(x=>x.Id==entity.Id).SingleOrDefault();
            if(countryToUpdate == null)
                return false;

            countryToUpdate.Deposit_Deduction = entity.Deposit_Deduction;
            countryToUpdate.Min_Deposit= entity.Min_Deposit;
            countryToUpdate.Min_Withdraw= entity.Min_Withdraw;
            countryToUpdate.Name= entity.Name;
            countryToUpdate.Withdraw_Deduction = entity.Withdraw_Deduction;

            return _appDbContext.SaveChanges() > 0;
        }
    }
}