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
    public class ChatService : IChatService
    {
        IChatRepository chatRepository = new ChatRepository();
        public void Create(Chat obj)
        {
    
            chatRepository.Create(obj);

        }

        public Chat Get(int id)
        {
            var getChat = chatRepository.Get(id);
            if(getChat == null)
            {
                System.Console.WriteLine("Chat does not exist");
                return null;
            }
            return getChat;
        }

        public List<Chat> GetAll()
        {
            var getAll = chatRepository.GetAll();
           if (getAll == null)
           {
                System.Console.WriteLine("No chat exists");
                return null;
           }
           return getAll.ToList();
        }

        public Chat GetbyId(int menteeId, int mentorId)
        {
            var getChat = chatRepository.GetbyId(menteeId, mentorId);
            if(getChat == null)
            {
                return null;
            }
            return getChat;
        }
    }
}