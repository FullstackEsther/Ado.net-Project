using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AdoProject.DTO;
using AdoProject.Model;

namespace AdoProject.Service.Interface
{
    public interface IUserService
    {
         
       public UserDto Get(string email);  
       public List<UserDto> GetAll();  
       public UserDto Login(LoginRequestModel model) ;
       public void UpdateUser(string email , string password); 
       public void Delete(int id);
        public UserDto Get(int id);
    }
}