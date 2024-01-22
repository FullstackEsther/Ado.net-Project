using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AdoProject.Model;

namespace AdoProject.Repository.Interface
{
    public interface IMenteeRepository
    {
         public void Create(Mentee obj);
        public Mentee Get(int id);
        public Mentee GetByUserId(int id);
         public int GetMenteeId();
        public List<Mentee> GetMenteesByMentorId(int mentorId);
        public List<Mentee> GetAll();
        public bool Update(int mentorId, int id);
        public bool Delete(int id);
    }
}