using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AdoProject.DTO;
using AdoProject.Menu;
using AdoProject.Model;
using AdoProject.Repository.Implementation;
using AdoProject.Repository.Interface;
using AdoProject.Service.Interface;
using MySql.Data.MySqlClient;

namespace AdoProject.Service.Implementation
{
    public class MentorService : IMentorService
    {
        string connectionString = "Server = localhost ; user = root ; database = chatConsole;  password = 123456789";
        IMentorRepository mentorRepository = new MentorRepository();
        IUserRepository userRepository = new UserRepository();
        IProfileRepository profileRepository = new ProfileRepository();
        IMenteeRepository menteeRepository = new MenteeRepository();
        public void Delete(int id)
        {
            var delete = mentorRepository.Delete(id);
            if (delete)
            {
                System.Console.WriteLine("Successfully Deleted");
            }
        }

        public MentorDto Get(int id)
        {

            var mentor = mentorRepository.Get(id);
            if (mentor != null)
            {
                var mentorProfile = profileRepository.Get(mentor.ProfileId);
                var user = userRepository.Get(mentor.UserId);
                return new MentorDto
                {
                    FirstName = mentorProfile.FirstName,
                    LastName = mentorProfile.LastName,
                    PhoneNumber = mentorProfile.PhoneNumber,
                    mentorId = mentor.Id,
                    ProfileId = mentorProfile.Id,
                    Address = mentorProfile.Address,
                    Age = mentorProfile.Age,
                    CategoryId = mentor.CategoryId,
                    YearsOfExperience = mentor.YearsOfExperience,
                    RefNum = mentor.RefNum,
                    Mentees = GetMenteeDtos(mentor.Id),
                    MentorStatus = mentor.MentorStatus,
                     Email = user.Email,

                };
            }
            else
            {
                System.Console.WriteLine("This mentor does not exist");
                return null;
            }



        }

        public List<MentorDto> GetAllMentors()
        {
            var getAll = mentorRepository.GetAll().Where(x => x.IsDeleted == false).ToList();

            var mentorDtos = new List<MentorDto>();

            foreach (var mentor in getAll)
            {
                var userProfile = profileRepository.Get(mentor.ProfileId);
                var user = userRepository.Get(mentor.UserId);
                var mentorDetails = new MentorDto
                {
                    CategoryId = mentor.CategoryId,
                    YearsOfExperience = mentor.YearsOfExperience,
                    RefNum = mentor.RefNum,
                    MentorStatus = mentor.MentorStatus,
                    FirstName = userProfile.FirstName,
                    LastName = userProfile.LastName,
                    Mentees =  null,
                    PhoneNumber = userProfile.PhoneNumber,
                    mentorId = mentor.Id,
                    Address = userProfile.Address,
                    Age = userProfile.Age,
                    Email = user.Email,   
                };
                mentorDtos.Add(mentorDetails);
            }
            foreach (var item in mentorDtos)
            {
                System.Console.WriteLine($"Id : {item.mentorId}\t Email : {item.Email}\t RefNum: {item.RefNum}");
            }
            return mentorDtos;
        }

        // public MentorDto GetbyRefNum(string refnum)
        // {
        //     throw new NotImplementedException();
        // }

        public void ToStrings(MentorDto obj)
        {
            // var getprofile = profileRepository.Get(obj.mentorId);
            System.Console.WriteLine($"Email : {obj.Email}\t FirstName : {obj.FirstName}\t LastName : {obj.LastName}\t PhoneNumber : {obj.PhoneNumber}\t Age: {obj.Age}");
        }

        public void Create(MentorRequestModel obj)
        {
            var check = userRepository.Check(obj.Email);
            if (check)
            {
                System.Console.WriteLine("Mentor already exist");
            }
            else
            {

                User user = new User
                {
                    Email = obj.Email,
                    Password = obj.Password,
                    Role = "Mentor",
                    IsDeleted = false
                };
                userRepository.Create(user);


                Profile profile = new Profile
                {
                    Age = obj.Age,
                    FirstName = obj.FirstName,
                    LastName = obj.LastName,
                    Address = obj.Address,
                    PhoneNumber = obj.PhoneNumber,
                };
                profileRepository.Create(profile);

                Random rand = new Random();

                Mentor mentor = new Mentor
                {
                    UserId = userRepository.GetUserId(),
                    YearsOfExperience = obj.YearsOfExperience,
                    RefNum = $"MentorRef{rand.Next(1000, 10000)}",
                    CategoryId = obj.CategoryId,
                    MentorStatus = MentorStatus.Avalaible,
                    ProfileId = profileRepository.GetProfileId()
                };
                mentorRepository.Create(mentor);




            }
        }

        public List<MenteeDto>? GetMenteeDtos(int id)
        {
            var listOfMentees = menteeRepository.GetMenteesByMentorId(id).Select(x => new MenteeDto
            {
                menteeId = x.Id,
                ReferenceNo = x.ReferenceNo,
                Email = userRepository.Get(x.UserId).Email,
                FirstName = profileRepository.Get(x.ProfileId).FirstName

            }).ToList();

            return listOfMentees;
        }
        public void UpdateMentor(UpdateMentorRequestModel obj)
        {
            var getMentor = mentorRepository.Get(MainMenu.loggedInId);
            if (getMentor == null)
            {
                System.Console.WriteLine("Mentor does not exist");
            }
            else
            {
                var mentor = new Mentor
                {
                    Id = obj.Id,
                    YearsOfExperience = obj.YearsOfExperience != 0 ? obj.YearsOfExperience : getMentor.YearsOfExperience,
                    MentorStatus = obj.MentorStatus != 0 ? obj.MentorStatus : getMentor.MentorStatus
                };
                mentorRepository.Update(mentor);

            }
        }

        public MentorDto GetByUserId(int userId)
        {
           var mentor = mentorRepository.GetByUserId(userId);
            if (mentor != null)
            {
                var mentorProfile = profileRepository.Get(mentor.ProfileId);
                return new MentorDto
                {
                    FirstName = mentorProfile.FirstName,
                    LastName = mentorProfile.LastName,
                    PhoneNumber = mentorProfile.PhoneNumber,
                    mentorId = mentor.Id,
                    Address = mentorProfile.Address,
                    Age = mentorProfile.Age,
                    CategoryId = mentor.CategoryId,
                    YearsOfExperience = mentor.YearsOfExperience,
                    RefNum = mentor.RefNum,
                    Mentees = null,
                    MentorStatus = mentor.MentorStatus
                };
            }
            else
            {
                System.Console.WriteLine("This mentor does not exist");
                return null;
            }
        }

        public List<MentorDto> GetbyCategoryId(int categoryId)
        {
            var getAll = mentorRepository.GetbyCategoryId(categoryId).Where(x => x.IsDeleted == false).ToList();

            var mentorDtos = new List<MentorDto>();

            foreach (var mentor in getAll)
            {
                var userProfile = profileRepository.Get(mentor.ProfileId);
                var mentorDetails = new MentorDto
                {
                    CategoryId = mentor.CategoryId,
                    YearsOfExperience = mentor.YearsOfExperience,
                    RefNum = mentor.RefNum,
                    Mentees = null,
                    MentorStatus = mentor.MentorStatus,
                    FirstName = userProfile.FirstName,
                    LastName = userProfile.LastName,
                    PhoneNumber = userProfile.PhoneNumber,
                    mentorId = mentor.Id,
                    Address = userProfile.Address,
                    Age = userProfile.Age,
                };

                mentorDtos.Add(mentorDetails);
                // foreach (var item in mentorDtos)
                // {
                //     System.Console.WriteLine($"Email : {item.Email}\nId: {item.mentorId} \nRefNum: {item.RefNum}");
                // }

            }
            return mentorDtos;
        }
        public void ToStrings(List<MenteeDto> listOfMentees )
        {
            foreach (var item in listOfMentees)
            {
                Console.WriteLine($"Mentee Email: {item.Email}\t FirstName : {item.FirstName}\t ReferenceNo : {item.ReferenceNo}\t Id : {item.menteeId}");
            }
        }
    }
}