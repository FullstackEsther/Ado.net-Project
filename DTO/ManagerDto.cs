using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdoProject.DTO
{
    public class ManagerDto
    {
        public int Id {get; set;}
        public string Email { get; set; }
        public int Age { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }

    }
}