using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdoProject.Model
{
    public class Mentee : BaseClass
    {
        public int MentorId{get;set;}
        public int ProfileId{get;set;}
        public string ReferenceNo { get; set; }
        public int UserId {get;set;}
       
    }
}