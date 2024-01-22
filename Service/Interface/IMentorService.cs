using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AdoProject.DTO;
using AdoProject.Model;

namespace AdoProject.Service.Interface
{
    public interface IMentorService
    {
        public void Create (MentorRequestModel obj);

         public List<MentorDto> GetbyCategoryId(int categoryId);
        public MentorDto Get(int id);
        public MentorDto GetByUserId(int userId);
       public List<MentorDto> GetAllMentors();
        public List<MenteeDto> GetMenteeDtos(int id);
        public void ToStrings(MentorDto obj);
        public void ToStrings(List<MenteeDto> listOfMentees );
        public void UpdateMentor(UpdateMentorRequestModel obj);
        public void Delete(int id);
    }
}