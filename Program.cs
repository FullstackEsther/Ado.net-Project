// See https://aka.ms/new-console-template for more information
using System.Net.Http.Headers;
using AdoProject;
using AdoProject.Context;
using AdoProject.DTO;
using AdoProject.Menu;
using AdoProject.Model;
using AdoProject.Repository.Implementation;
using AdoProject.Repository.Interface;
using AdoProject.Service.Implementation;
using AdoProject.Service.Interface;
//string connectionString = "Server = localhost ; user = root ; database = chatConsole;  password = 123456789";
MainMenu mainMenu = new MainMenu();
mainMenu.UserMenu();
// TablesContext.CreateDb(connectionString);
// TablesContext.CreateUser(connectionString);
// TablesContext.CreateCategory(connectionString);
// TablesContext.CreateProfile(connectionString);
// TablesContext.CreateMentor(connectionString);
// TablesContext.CreateMentee(connectionString);
// TablesContext.CreateManager(connectionString);
//TablesContext.CreateChat(connectionString);
//TablesContext.CreateMessage(connectionString);



// // TablesContext.CreateChat(connectionString);
// ICategoryRepository  profileRepository = new CategoryRepository();
// Category category = new Category{
//     Id =1,
//     Name = "Education",
//     IsDeleted = false
// };

// User user = new User{
//     Email = "iamsobowale@gmail.com",
//     Id = 1,
//     IsDeleted = false,
//     Password = "12345",
//     Role = "Mentor"
// };
// Profile profile = new Profile
// {
//     Age = 8,
//     FirstName = "ade",
//     LastName = "ola",
//     PhoneNumber = "0909090909",
//     Address = "abk",
//     IsDeleted = false
// };
//IProfileRepository profileRepository = new ProfileRepository();
// profileRepository.Delete(3);
// Mentee mentee = new Mentee 
// {
//     UserId = 2,
// MentorId = 1,
// ReferenceNo = "tgkgl",

// };
// IMenteeRepository menteeRepository = new MenteeRepository();
// menteeRepository.Create(mentee);

// var get = profileRepository.GetProfileId();
// IMentorRepository categoryRepository = new MentorRepository();
// Mentor mentor = new Mentor{
// UserId = 1,
// RefNum = "1",
// YearsOfExperience = 1,
// CategoryId =1,
// IsDeleted = false,
// Id = 1
// // };
// UpdateMentorRequestModel mentorRequestModel = new UpdateMentorRequestModel()
// {

//      MentorStatus = MentorStatus.Avalaible,
//       Id = 6
// }; 
// UpdateUserRequestModel updateUserRequestModel= new UpdateUserRequestModel()
// {
//     Password = "1645",
//      Email = "dnde@gmail.com"

// };
// UpdateProfileRequestModel updateProfileRequestModel = new UpdateProfileRequestModel()
// {
//     Age = 2,
//     Address = "ib",
//     // FirstName = "ade",
//     // LastName = "zadd",
//     // PhoneNumber = "098654",
//      Id =8
// };
// IMentorService mentorService = new MentorService();
// mentorService.GetAllMentors();
// IProfileService profileService = new ProfileService();
// profileService.UpdateProfile(updateProfileRequestModel);
// IUserService userService = new UserService();
// userService.UpdateUser(updateUserRequestModel);

// // var dd = categoryRepository.GetAll();
// categoryRepository.Create(mentor);
//  LoginRequestModel login = new LoginRequestModel
//  {
//     Email = "iamsobowale@gmail.com",
//     Password = "123"

//  };

// IUserService userService = new UserService();
// userService.GetAll();
// MenteeRequestModel menteeRequestModel = new MenteeRequestModel()
// {
//     Address = "abk",
//     Age = 5,
//     Email = "lust",
//     FirstName = "tyuty",
//     LastName = "tswd",
//     Password = "3456",
//     PhoneNumber = "09878890"
// };
// UpdateMenteeRequestModel updateMenteeRequestModel = new UpdateMenteeRequestModel()
// {
//      Id =3,
//       mentorId = 7,
// };
// MenteeService menteeService = new MenteeService();
// menteeService.Update(updateMenteeRequestModel);
// IManagerService managerService = new ManagerService();
// managerService.Get(1);
// Category category = new Category
// {
//      IsDeleted= false,
//       Name = "Education"
// };

// ICategoryService categoryService = new CategoryService();
// categoryService.Create(category);
// Message message = new Message{
//  ChatId = 1,
//   IsDeleted = false,
//    MessageChat = "how are you doing",
//     SenderEmail = "lust",
     
// };
// IMessageService messageService = new MessageService();
// messageService.Delete(1);
// System.Console.WriteLine();


