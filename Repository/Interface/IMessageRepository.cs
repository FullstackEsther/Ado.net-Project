using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AdoProject.Model;

namespace AdoProject.Repository.Interface
{
    public interface IMessageRepository
    {
        public void Create(Message obj);
        public bool Delete(int messageId);
        public Message Get(int Id);
        public List<Message> GetChat(int ChatId);
        //public List<Message> GetAll();
    }
}