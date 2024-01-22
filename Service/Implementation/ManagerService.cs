using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AdoProject.DTO;
using AdoProject.Model;
using AdoProject.Repository.Implementation;
using AdoProject.Repository.Interface;
using AdoProject.Service.Interface;

namespace AdoProject.Service.Implementation
{
    public class ManagerService : IManagerService
    {
        IUserRepository userRepository = new UserRepository();
        IProfileRepository profileRepository = new ProfileRepository();
        IManagerRepository managerRepository = new ManagerRepository();
        public ManagerDto Get(int Id)
        {
            var getManager = managerRepository.Get(Id);
            if (getManager != null)
            {
                var managerProfile = profileRepository.Get(getManager.ProfileId);
                var user = userRepository.Get(getManager.UserId);
                return new ManagerDto
                {
                    Address = managerProfile.Address,
                    Age = managerProfile.Age,
                    Email = user.Email,
                    FirstName = managerProfile.FirstName,
                    LastName = managerProfile.LastName,
                    PhoneNumber = managerProfile.PhoneNumber,
                    Id = getManager.Id,
                };
            }
            return null;
        }
    }
}