using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AdoProject.Model;
using AdoProject.Repository.Implementation;
using AdoProject.Repository.Interface;
using AdoProject.Service.Interface;

namespace AdoProject.Service.Implementation
{
    public class CategoryService : ICategoryService
    {
        ICategoryRepository categoryRepository = new CategoryRepository();
        public void Create(Category obj)
        {
            var getCategory = categoryRepository.Get(obj.Name);
            if (getCategory == null)
            {
                Category category = new Category()
                {
                    IsDeleted = false,
                    Name = obj.Name
                };
                categoryRepository.Create(category);
                System.Console.WriteLine("Created Successfully");
                
            }
            else
            {
                System.Console.WriteLine("Category already exists");
            }
        }

        public Category Get(string name)
        {
          return  categoryRepository.Get(name);
        }

        public List<Category> GetAll()
        {
           var getAll = categoryRepository.GetAll();
           foreach (var item in getAll)
           {
                System.Console.WriteLine($"Id: {item.Id} \t Name:{item.Name}");
           }
           return getAll;
        }
    }
}