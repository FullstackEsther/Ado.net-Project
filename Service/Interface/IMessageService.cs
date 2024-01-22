using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AdoProject.Model;

namespace AdoProject.Service.Interface
{
    public interface IMessageService
    {
         public void Create(Message obj);
        public Message Get(int Id);
         public void Delete(int messageId);
        public List<Message> GetChat(int ChatId);
       // public List<Message> GetAll();
    }
}