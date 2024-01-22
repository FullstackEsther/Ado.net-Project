using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AdoProject.DTO;
using AdoProject.Model;

namespace AdoProject.Service.Interface
{
    public interface IProfileService
    {
         public void UpdateProfile(UpdateProfileRequestModel obj);
        public ProfileDto Get(int id );
        public List<ProfileDto> GetAll();
        public void Delete(int id);

    }
}