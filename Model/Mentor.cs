using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdoProject.Model
{
    public class Mentor : BaseClass
    {
        public int UserId { get; set; }
        public int CategoryId { get; set; }
        public int YearsOfExperience { get; set; }
        public int ProfileId { get; set; }
        public string RefNum { get; set; }
        public  List<Mentee> Mentees { get; set; } = new List<Mentee>();
        public MentorStatus MentorStatus { get; set; }
        

    }
}