using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AdoProject.Model;

namespace AdoProject.Repository.Interface
{
    public interface ICategoryRepository
    {
        public void Create(Category obj);
        public Category Get(string name);
        public List<Category> GetAll();
    }
}