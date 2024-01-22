using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdoProject.DTO
{
    public class MentorDto
    {
        public string Email { get; set; }
        public int Age { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public int mentorId { get; set; }
        public int CategoryId { get; set; }
        public int YearsOfExperience { get; set; }
        public string RefNum { get; set; }
        public List<MenteeDto>? Mentees { get; set; }
        public MentorStatus MentorStatus { get; set; }
        public int ProfileId{get;set;}
        public int UserId {get;set;}
    }
    public class MentorRequestModel
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public int Age { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public int CategoryId { get; set; }
        public int YearsOfExperience { get; set; }

    }

  
    public class UpdateMentorRequestModel
    {
        public MentorStatus MentorStatus { get; set; }
        public int YearsOfExperience { get; set; }
        public int Id {get; set;}

    }
   
}