using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AdoProject.DTO;

namespace AdoProject.Service.Interface
{
    public interface IMenteeService
    {
        public void Create(MenteeRequestModel obj, int categoryId);
        public MenteeDto Get(int id);
     //   public List<MenteeDto> GetMenteesByMentorId(int mentorId);
      public MenteeDto GetByUserId(int userId);
        public List<MenteeDto> GetAll();
        public void Update(UpdateMenteeRequestModel obj);
        public void Delete(int id);
        public void ToStrings(MenteeDto dto);
        // public int Assign(int categoryId);
    }
}