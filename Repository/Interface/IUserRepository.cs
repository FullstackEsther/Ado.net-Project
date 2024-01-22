using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AdoProject.Model;

namespace AdoProject.Repository.Interface
{
    public interface IUserRepository
    {
        public void Create(User obj);
        public User Get(string email);
        public User Get(int id);
        public List<User> GetAll();
         public int GetUserId();
        public User GetbyEmailAndPin(string email, string password);
        public bool Update(string email, string password);
         public bool Check (string email);
         public bool Delete(int id);
    }
}