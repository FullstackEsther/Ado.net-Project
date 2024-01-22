using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdoProject.DTO
{
   public class UserDto
    {
        public int Id { get; set; }
        public string Email { get; set; } 
        public string Role { get; set; }
    }

    public class LoginRequestModel
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }

    public class CreateUserRequestModel
    {
        public string Email {get; set;}
        public string Password {get; set;}
        public string Role {get; set;}
    }
    //  public class UpdateUserRequestModel
    // {
    //     public string Email {get; set;}
    //     public string Password {get; set;}
    // }
    

    
}