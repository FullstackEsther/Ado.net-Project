using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AdoProject.Model;
using AdoProject.Repository.Implementation;
using AdoProject.Repository.Interface;
using AdoProject.Service.Interface;

namespace AdoProject.Service.Implementation
{
    public class MessageService : IMessageService
    {
        IMessageRepository messageRepository = new MessageRepository();
        public void Create(Message obj)
        {
            // var getMessage = messageRepository.GetChat(obj.ChatId);
            // if (getMessage == null)
           // {
                Message message = new Message
                {
                    ChatId = obj.ChatId,
                    IsDeleted = false,
                    MessageChat = obj.MessageChat,
                    SenderEmail = obj.SenderEmail,

                };
                messageRepository.Create(obj);
           // }
        }

        public void Delete(int messageId)
        {
            var getMessage = messageRepository.Get(messageId);
            if (getMessage != null)
            {
                messageRepository.Delete(messageId);
            }
            else
            {
                System.Console.WriteLine("There's no message to delete");
            }
        }

        public Message Get(int Id)
        {
            var getMessage = messageRepository.Get(Id);
            if (getMessage != null)
            {
                return getMessage;
            }
            return null;
        }

        // public List<Message> GetAll()
        // {
        //     var getAllMessages = messageRepository.GetAll().Where(x => x.IsDeleted == false).ToList();
        //     if (getAllMessages.Count != 0)
        //     {
        //         return getAllMessages;
        //     }
        //     return null;
        // }

        public List<Message> GetChat(int ChatId)
        {
           var getChat = messageRepository.GetChat(ChatId).Where(a => a.IsDeleted == false).ToList();
           if (getChat.Count != 0)
           {
                foreach (var item in getChat)
                {
                   System.Console.WriteLine($"Sender-Email : {item.SenderEmail} : {item.MessageChat}\t {item.TimeSent}"); 
                }
                return getChat;
           }
           return null;
        }
    }
}