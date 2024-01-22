using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Threading.Tasks;
using AdoProject.DTO;
using AdoProject.Menu;
using AdoProject.Model;
using AdoProject.Repository.Implementation;
using AdoProject.Repository.Interface;
using AdoProject.Service.Interface;

namespace AdoProject.Service.Implementation
{
    public class ProfileService : IProfileService
    {
        IProfileRepository profileRepository = new ProfileRepository();
        public void Delete(int id)
        {
            var delete = profileRepository.Delete(id);
            if (delete)
            {
                System.Console.WriteLine("deleted successfully");
            }
        }

        public ProfileDto Get(int id)
        {
            var get = profileRepository.Get(id);
            if (get == null)
            {
                System.Console.WriteLine("Profile doesn't exist");
                return null;
            }
            return new ProfileDto
            {
                Age = get.Age,
                FirstName = get.FirstName,
                LastName = get.LastName,
                Address = get.Address,
                PhoneNumber = get.PhoneNumber,
            };
        }

        public List<ProfileDto> GetAll()
        {
            var listOfprofiles = profileRepository.GetAll().Where(x => x.IsDeleted == false);
            var profiles = listOfprofiles.Select(profile => new ProfileDto
            {
                Age = profile.Age,
                FirstName = profile.FirstName,
                LastName = profile.LastName,
                Address = profile.Address,
                PhoneNumber = profile.PhoneNumber,

            }).ToList();

            return profiles;
        }

        public void UpdateProfile(UpdateProfileRequestModel obj)
        {
            var getProfile = profileRepository.Get(obj.Id);
            if (getProfile == null)
            {
                System.Console.WriteLine("No Profile match");
            }
            else
            {
                var profile = new Profile
                {
                     Id = obj.Id,
                    Address = obj.Address ?? getProfile.Address,
                    PhoneNumber = obj.PhoneNumber ?? getProfile.PhoneNumber,
                    FirstName = obj.FirstName ?? getProfile.FirstName,
                    LastName = obj.LastName ?? getProfile.LastName,
                    Age = obj.Age !=0 ? obj.Age : getProfile.Age ,

                };
                profileRepository.Update(profile);
               System.Console.WriteLine("Successfully Updated");
            }

        }
    }
}