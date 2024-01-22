using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AdoProject.DTO;
using AdoProject.Model;
using AdoProject.Service.Implementation;
using AdoProject.Service.Interface;
using Microsoft.VisualBasic;

namespace AdoProject.Menu
{
    public class MentorMenu
    {
        IUserService userService = new UserService();
        IProfileService profileService = new ProfileService();
        IMentorService mentorService = new MentorService();
        IMenteeService menteeService = new MenteeService();
        ICategoryService categoryService = new CategoryService();
        IChatService chatService = new ChatService();
        IMessageService messageService = new MessageService();
        UpdateProfileRequestModel updateProfileRequestModel = new UpdateProfileRequestModel();
        UpdateMentorRequestModel updateMentorRequestModel = new UpdateMentorRequestModel();

        public void CreateMentor()
        {
            System.Console.Write("Enter your Firstname :");
            string firstName = Console.ReadLine();

            System.Console.Write("Enter your Lastname :");
            string lastName = Console.ReadLine();

            System.Console.Write("Enter your Address :");
            string address = Console.ReadLine();

            System.Console.Write("Enter your PhoneNumber :");
            string phoneNumber = Console.ReadLine();

            System.Console.Write("Enter your Age :");
            int age = int.TryParse(Console.ReadLine(), out int result) ? result : 0;

            Console.Write("enter your number years of experience: ");
            int years = int.TryParse(Console.ReadLine(), out int results) ? results : 0;
            string categoryname = "";
            while (true)
            {
                categoryService.GetAll();

                Console.Write("enter the name of category: ");
                categoryname = Console.ReadLine();

                var check = categoryService.Get(categoryname);
                if (check != null)
                {
                    break;
                }
            }

            Console.Write("enter your email: ");
            string email = Console.ReadLine();

            Console.Write("enter your password: ");
            string pass = Console.ReadLine();

            MentorRequestModel mentorRequestModel = new MentorRequestModel()
            {
                Address = address,
                Age = age,
                CategoryId = categoryService.Get(categoryname).Id,
                Email = email,
                FirstName = firstName,
                LastName = lastName,
                Password = pass,
                PhoneNumber = phoneNumber,
                YearsOfExperience = years
            };
            mentorService.Create(mentorRequestModel);
            // System.Console.WriteLine("Mentor created Successfully");
        }
        public void UseCaseMentor()
        {
            try
            {
                while (true)
                {
                    System.Console.WriteLine("Enter 1 to view profile \nEnter 2 to update profile \nEnter 3 to view Mentees \nEnter 4 chat with Mentee \nEnter 5 to go back");
                    int opt = int.Parse(Console.ReadLine());
                    if (opt == 1)
                    {
                        var get = mentorService.Get(MainMenu.loggedInId);
                        mentorService.ToStrings(get);


                    }
                    else if (opt == 2)
                    {
                        Update();

                    }
                    else if (opt == 3)
                    {
                        mentorService.GetMenteeDtos(MainMenu.loggedInId);
                    }
                    else if (opt == 4)
                    {
                        Messaging();
                    }
                    else if (opt == 5)
                    {
                        break;
                    }
                    else
                    {
                        System.Console.WriteLine("invalid input");
                    }
                }

            }
            catch (Exception ex)
            {
                System.Console.WriteLine(ex.Message);
                UseCaseMentor();
            }
        }

        private void Update()
        {
            var array = new string[] { "FirstName", "LastName", "Address", "PhoneNumber", "Age", "YearsOfExperience", "Password" };
            int id = 1;
            foreach (var item in array)
            {
                System.Console.WriteLine($"{id}\t {item}");
                id++;
            }
            System.Console.WriteLine("Enter the amount of the items you want to update");
            int response = int.TryParse(Console.ReadLine(), out int result) ? result : 0;
            Looping(response);


        }

        private void Looping(int response)
        {
            try
            {
                //  var mentObj = mentorService.Get(MainMenu.loggedInEmail);
                // var profileObj = profileService.Get(MainMenu.loggedInEmail);
                // var userObj = userService.Get(MainMenu.loggedInEmail);
                string password = "";
                for (int i = 0; i < response; i++)
                {
                    System.Console.WriteLine("Enter the id of the item you want to update");
                    int ans = int.Parse(Console.ReadLine());

                    switch (ans)
                    {
                        case 1:
                            System.Console.WriteLine("Enter the value");
                            updateProfileRequestModel.FirstName = Console.ReadLine();
                            break;
                        case 2:
                            System.Console.WriteLine("Enter the value");
                            updateProfileRequestModel.LastName = Console.ReadLine();
                            break;

                        case 3:
                            System.Console.WriteLine("Enter the value");
                            updateProfileRequestModel.Address = Console.ReadLine();
                            break;

                        case 4:
                            System.Console.WriteLine("Enter the value");
                            updateProfileRequestModel.PhoneNumber = Console.ReadLine();
                            break;

                        case 5:
                            System.Console.WriteLine("Enter the value");
                            updateProfileRequestModel.Age = int.Parse(Console.ReadLine());
                            break;

                        case 6:
                            System.Console.WriteLine("Enter the value");
                            updateMentorRequestModel.YearsOfExperience = int.Parse(Console.ReadLine());
                            break;

                        case 7:
                            System.Console.WriteLine("Enter the value");
                            password = Console.ReadLine();
                            break;

                        default:
                            System.Console.WriteLine("Invalid Input");
                            break;
                    }
                }
                var getMentor = mentorService.Get(MainMenu.loggedInId);
                updateProfileRequestModel.Id = getMentor.ProfileId;
                profileService.UpdateProfile(updateProfileRequestModel);
                mentorService.UpdateMentor(updateMentorRequestModel);
                if (!string.IsNullOrWhiteSpace(password))
                {
                    userService.UpdateUser(MainMenu.loggedInEmail, password);
                }
            }
            catch (Exception ex)
            {
                System.Console.WriteLine(ex.Message);
            }
        }

        public void Messaging()
        {
            var mentor = mentorService.Get(MainMenu.loggedInId);
            if (mentor.Mentees?.Count == 0)
            {
                System.Console.WriteLine("Cannot chat, No mentee assigned!");
            }
            else
            {
                System.Console.WriteLine("Select Mentee id");
                mentorService.ToStrings(mentor.Mentees);
                var menteeId = int.Parse(Console.ReadLine());
                var getChat = chatService.GetbyId(menteeId, MainMenu.loggedInId);
                if (getChat == null)
                {
                    Chat chat = new Chat()
                    {
                        IsDeleted = false,
                        MenteeId = menteeId,
                        MentorId = MainMenu.loggedInId,

                    };
                    chatService.Create(chat);
                    System.Console.Write("Enter the message you want to send :");
                    var messageContent = Console.ReadLine();
                    Message message = new Message()
                    {
                        ChatId = chat.Id,
                        IsDeleted = false,
                        MessageChat = messageContent,
                        SenderEmail = MainMenu.loggedInEmail,
                        TimeSent = DateTime.Now
                    };
                    messageService.Create(message);

                }
                else
                {
                    messageService.GetChat(getChat.Id);

                    while (true)
                    {
                        System.Console.Write("Enter the message you want to send or 0 to exist:");
                        var messageContent = Console.ReadLine();
                        if (messageContent == 0.ToString())
                        {
                            break;
                        }
                        Message message = new Message()
                        {
                            IsDeleted = false,
                            ChatId = getChat.Id,
                            MessageChat = messageContent,
                            SenderEmail = MainMenu.loggedInEmail,
                            TimeSent = DateTime.Now,
                        };
                        messageService.Create(message);
                    }

                }
            }
        }
    }
}