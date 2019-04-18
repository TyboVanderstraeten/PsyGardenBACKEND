﻿using Microsoft.EntityFrameworkCore;
using PsyGardenBackEnd.Models.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PsyGardenBackEnd.Data.Repositories
{
    public class UserRepository : IUserRepository
    {
        private PsyGardenDBContext _dbContext;
        private DbSet<User> _users;

        public UserRepository(PsyGardenDBContext dbContext)
        {
            _dbContext = dbContext;
            _users = dbContext.Users;
        }
        public User GetByEmail(string email)
        {
            return _users.SingleOrDefault(u => u.Email.Equals(email));
        }

        public void Add(User user)
        {
            _users.Add(user);
        }

        public void Update(User user)
        {
            _users.Update(user);
        }

        public void Delete(User user)
        {
            _users.Remove(user);
        }

        public void SaveChanges()
        {
            _dbContext.SaveChanges();
        }
    }
}
