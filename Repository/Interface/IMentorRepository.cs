using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AdoProject.Model;

namespace AdoProject.Repository.Interface
{
    public interface IMentorRepository
    {
        public void Create(Mentor obj);
        public Mentor Get(int id);
          public List<Mentor> GetbyCategoryId(int categoryId);
        public Mentor GetByUserId(int userId);
        public List<Mentor> GetAll();
        public bool Update(Mentor obj);
        public Mentor GetbyRefNum(string refNum);
         public bool Delete(int id); 
    }
}