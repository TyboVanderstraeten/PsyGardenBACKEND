using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PsyGardenBackEnd.Models.Domain
{
    public interface IUserRepository
    {
        User GetByEmail(string email);
        void Add(User user);
        void Delete(User user);
        void SaveChanges();
    }
}
