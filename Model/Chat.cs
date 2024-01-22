using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdoProject.Model
{
    public class Chat : BaseClass
    {
        public int MentorId { get; set; }
       public int MenteeId { get; set; }
        public List<Message> Messages{get; set;}

    }
}