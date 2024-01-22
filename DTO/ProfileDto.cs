using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdoProject.DTO
{
    public class ProfileDto
    {
        public int Age {get; set;}
        public string FirstName {get; set;}
        public string LastName {get; set;}
        public string Address{get; set;}
        public string PhoneNumber{get; set;}
        
    }
      public class UpdateProfileRequestModel
    {
        public int Id {get; set;}
        public int Age { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
    }
}