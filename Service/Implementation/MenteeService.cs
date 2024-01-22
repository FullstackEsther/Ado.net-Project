using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using AdoProject.DTO;
using AdoProject.Model;
using AdoProject.Repository.Implementation;
using AdoProject.Repository.Interface;
using AdoProject.Service.Interface;

namespace AdoProject.Service.Implementation
{
    public class MenteeService : IMenteeService
    {
        IMenteeRepository menteeRepository = new MenteeRepository();
        IMentorRepository mentorRepository = new MentorRepository();
        IUserRepository userRepository = new UserRepository();
        IProfileRepository profileRepository = new ProfileRepository();
         IMentorService mentorService = new MentorService();

        private int Assign(int categoryId)
        {
            List<Mentor> availableMentor = new List<Mentor>();
            var mentors = mentorRepository.GetAll().Where(c => c.CategoryId == categoryId).ToList();
            if (mentors.Count == 0)
            {
                System.Console.WriteLine("There are no mentors in this category");
                return default;
            }
            foreach (var availMentor in mentors)
            {
                var check = CheckAvailableMentors(availMentor.Id);
                if (!check)
                {
                    availableMentor.Add(availMentor);
                }
            }

            Random rand = new Random();
            int index = rand.Next(0, availableMentor.Count);
            var mentor = availableMentor[index];
            // var getMentor = mentorRepository.Get(mentor.Id);
            System.Console.WriteLine($"Mentor Assigned and Reference number  is {mentor.RefNum}");
            return mentor.Id;
        }

        private bool CheckAvailableMentors(int mentorId)
        {
            var getAll = menteeRepository.GetAll().Where(c => c.MentorId == mentorId).ToList();
            if (getAll.Count == 2)
            {
                return true;
            }
            return false;
        }

        public void Create(MenteeRequestModel obj, int categoryid)
        {
            var check = userRepository.Check(obj.Email);
            if (!check)
            {
                User user = new User
                {
                    Email = obj.Email,
                    Password = obj.Password,
                    Role = "Mentee",
                    IsDeleted = false
                };
                userRepository.Create(user);
                Profile profile = new Profile()
                {
                    Address = obj.Address,
                    Age = obj.Age,
                    FirstName = obj.FirstName,
                    LastName = obj.LastName,
                    PhoneNumber = obj.PhoneNumber,
                    IsDeleted = false
                };
                profileRepository.Create(profile);
                Random rand = new Random();
                Mentee mentee = new Mentee
                {
                    UserId = userRepository.GetUserId(),
                    ProfileId = profileRepository.GetProfileId(),
                    ReferenceNo = $"MenteeRef{rand.Next(1000, 100000)}",
                    MentorId = Assign(categoryid),
                    IsDeleted = false
                };
                menteeRepository.Create(mentee);
            }
        }

        public void Delete(int id)
        {
            var delete = menteeRepository.Delete(id);
            if (delete)
            {
                System.Console.WriteLine("Successfully Deleted");
            }
        }

        public MenteeDto Get(int id)
        {
            var mentee = menteeRepository.Get(id);
            if (mentee != null)
            {
                var userProfile = userRepository.Get(mentee.UserId);
                var menteeProfile = profileRepository.Get(mentee.ProfileId);
                var mentor = mentorService.Get(mentee.MentorId);
                var gettt = new MenteeDto
                {
                    Address = menteeProfile.Address,
                    Age = menteeProfile.Age,
                    Email = userProfile.Email,
                    FirstName = menteeProfile.FirstName,
                    LastName = menteeProfile.LastName,
                    PhoneNumber = menteeProfile.PhoneNumber,
                    ReferenceNo = mentee.ReferenceNo,
                    menteeId = mentee.Id,
                    ProfileId = menteeProfile.Id,
                    UserId = userProfile.Id,
                    MentorRef = mentor.RefNum,
                    MentorId = mentor.mentorId
                };
                return gettt;
            }
            return null;
        }

        public List<MenteeDto> GetAll()
        {
            var menteelist = new List<MenteeDto>();
            var getAll = menteeRepository.GetAll().Where(c => c.IsDeleted == false).ToList();
            if (getAll.Count != 0)
            {
                foreach (var mentee in getAll)
                {
                    var menteeProfile = profileRepository.Get(mentee.ProfileId);
                    var userProfile = userRepository.Get(mentee.UserId);
                    var menteeDto = new MenteeDto
                    {
                        menteeId = mentee.Id,
                        Email = userProfile.Email,
                        Address = menteeProfile.Address,
                        Age = menteeProfile.Age,
                        FirstName = menteeProfile.FirstName,
                        LastName = menteeProfile.LastName,
                        PhoneNumber = menteeProfile.PhoneNumber,
                        ReferenceNo = mentee.ReferenceNo,
                    };
                    menteelist.Add(menteeDto);
                    foreach (var item in menteelist)
                    {
                        System.Console.WriteLine($"Email: {item.Email} \t RefNum: {item.ReferenceNo} \t Id: {item.menteeId} ");
                    }
                }
                return menteelist;
            }
            return null;
        }



        public void Update(UpdateMenteeRequestModel obj)
        {
            var updateMentee = menteeRepository.Get(obj.Id);
            if (updateMentee != null)
            {
                var mentee = new Mentee
                {
                    Id = obj.Id,
                    MentorId = obj.mentorId,
                };
                menteeRepository.Update(mentee.MentorId, mentee.Id);
            }
        }


        public void ToStrings(MenteeDto dto)
        {
            System.Console.WriteLine($"Email: {dto.Email}\tFirstName: {dto.FirstName}\tLastName: {dto.LastName}\tAge: {dto.Age}\tMentorRef: {dto.MentorRef}");
        }

        public MenteeDto GetByUserId(int userId)
        {
           var mentee = menteeRepository.GetByUserId(userId);
            if (mentee != null)
            {
                var userProfile = userRepository.Get(userId);
                var menteeProfile = profileRepository.Get(mentee.ProfileId);
                return new MenteeDto
                {
                    Address = menteeProfile.Address,
                    Age = menteeProfile.Age,
                    Email = userProfile.Email,
                    FirstName = menteeProfile.FirstName,
                    LastName = menteeProfile.LastName,
                    PhoneNumber = menteeProfile.PhoneNumber,
                    ReferenceNo = mentee.ReferenceNo,
                    menteeId = mentee.Id,
                    ProfileId = menteeProfile.Id,
                    UserId = userProfile.Id,

                };
            }
            return null;
        }
    }
}