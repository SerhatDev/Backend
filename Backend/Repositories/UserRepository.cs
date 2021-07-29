using Backend.Models;
using Backend.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Backend.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _appDbContext;
        public UserRepository(AppDbContext appDbContext)
        {
            this._appDbContext = appDbContext;
        }
        public bool Add(User entity)
        {
            _appDbContext.Users.Add(entity);
            return _appDbContext.SaveChanges() > 0;
        }

        public List<User> GetAll()
        {
            return _appDbContext.Users.ToList();
        }

        public List<User> Query(Func<User, bool> predicate)
        {
            return _appDbContext.Users.Where(predicate).ToList();
        }

        public bool Remove(User entity)
        {
            var userToRemove = _appDbContext.Users.Where(x => x.Id == entity.Id).SingleOrDefault();
            if (userToRemove == null)
                return false;
            _appDbContext.Users.Remove(userToRemove);
            return _appDbContext.SaveChanges() > 0;
        }

        public bool Update(User entity)
        {
            _appDbContext.Users.Update(entity);
            return _appDbContext.SaveChanges() > 0;
        }
    }
}
