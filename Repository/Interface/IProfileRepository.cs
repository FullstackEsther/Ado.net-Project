using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AdoProject.Model;

namespace AdoProject.Repository.Interface
{
    public interface IProfileRepository
    {
         public void Create(Profile obj);
         public int GetProfileId();
        public Profile Get(int Id); 
        public List<Profile> GetAll();
        public bool Update(Profile obj);
        public bool Delete(int id);

    }
}