using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AdoProject.Model;

namespace AdoProject.Repository.Interface
{
    public interface IChatRepository
    {
        public void Create(Chat obj);
        public Chat Get(int id);
       // public Chat GetbyRefNo(string menteeRef);
        public Chat GetbyId(int menteeId, int mentorId);
        public List<Chat> GetAll();

       
    }
}