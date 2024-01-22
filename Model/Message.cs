using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdoProject.Model
{
    public class Message : BaseClass
    {
        public string MessageChat { get; set; }
        public int ChatId { get; set; }
        public string SenderEmail { get; set; }
        public DateTime TimeSent {get; set;} = DateTime.Now;

    }
}