using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AdoProject.DTO;
using AdoProject.Repository.Implementation;
using AdoProject.Repository.Interface;
using AdoProject.Service.Interface;

namespace AdoProject.Service.Implementation
{
    public class UserService : IUserService
    {
        IUserRepository userRepository = new UserRepository();


        public void Delete(int id)
        {
            var IsDeleted = userRepository.Delete(id);
            if (IsDeleted)
            {
                System.Console.WriteLine("Deleted successfully");
            }
        }

        public UserDto Get(string email)
        {
            var user = userRepository.Get(email);
            if (user == null)
            {
                System.Console.WriteLine($"Email {email} doesn't exist");
                return null;
            }
            return new UserDto
            {
                Id = user.Id,
                Email = user.Email,
                Role = user.Role
            };
        }
        public UserDto Get(int id)
        {
            var user = userRepository.Get(id);
            if (user == null)
            {
                System.Console.WriteLine($"Email {id} doesn't exist");
                return null;
            }
            return new UserDto
            {
                Id = user.Id,
                Email = user.Email,
                Role = user.Role
            };
        }

        public List<UserDto> GetAll()
        {
            var listOfUsers = userRepository.GetAll().Where(x => x.IsDeleted == false);
            var users = listOfUsers.Select(user => new UserDto
            {
                Id = user.Id,
                Email = user.Email,
                Role = user.Role,
            }).ToList();

            return users;
        }

        public UserDto Login(LoginRequestModel model)
        {
            var user = userRepository.GetbyEmailAndPin(model.Email, model.Password);
            if (user == null)
            {
                Console.WriteLine($"{model.Email} or {model.Password} invaild ");
                return null;
            }
            return new UserDto
            {
                Email = user.Email,
                Id = user.Id,
                Role = user.Role,
            };
        }

        
        public void UpdateUser(string email , string password)
        {
            var user = userRepository.Get(email);
            if (user == null)
            {
                System.Console.WriteLine("User not Available");
            }
            else
            {
                var update = userRepository.Update(email, password);

                if (update)
                {
                    System.Console.WriteLine("Updated sucessfully");
                }
            }
        }
    }
}