using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AdoProject.DTO;
using AdoProject.Model;
using AdoProject.Service.Implementation;
using AdoProject.Service.Interface;

namespace AdoProject.Menu
{
    public class MenteeMenu
    {
        IUserService userService = new UserService();
        IProfileService profileService = new ProfileService();
        IMenteeService menteeService = new MenteeService();
        ICategoryService categoryService = new CategoryService();
        IMentorService mentorService = new MentorService();
        IChatService chatService = new ChatService();
        IMessageService messageService = new MessageService();
        UpdateProfileRequestModel updateProfileRequestModel = new UpdateProfileRequestModel();  
        UpdateMenteeRequestModel updateMenteeRequestModel = new UpdateMenteeRequestModel();
        public void CreateMentee()
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

            Console.Write("enter your email: ");
            string email = Console.ReadLine();

            Console.Write("enter your password: ");
            string pass = Console.ReadLine();

            categoryService.GetAll();
            Console.Write("ente the Id of your preferred category : ");
            int id = int.Parse(Console.ReadLine());

            MenteeRequestModel menteeRequestModel = new MenteeRequestModel
            {
                Address = address,
                Age = age,
                Email = email,
                FirstName = firstName,
                LastName = lastName,
                Password = pass,
                PhoneNumber = phoneNumber
            };
            menteeService.Create(menteeRequestModel, id);


        }

        public void UseCaseMentee()
        {
            try
            {
                while (true)
                {
                    System.Console.WriteLine("Enter 1 to chat with mentor\nEnter 2 to update profile\nEnter 3 to view your Profile \nEnter 4 to change Mentor\nEnter 5 to go back");
                    int opt = int.Parse(Console.ReadLine());
                    if (opt == 1)
                    {
                        Messaging();
                    }
                    else if (opt == 2)
                    {
                        Update();
                    }
                    else if (opt == 3)
                    {
                        var get = menteeService.Get(MainMenu.loggedInId);
                        menteeService.ToStrings(get);
                    }
                    else if (opt == 4)
                    {
                        var getMentee = menteeService.Get(MainMenu.loggedInId);
                        Console.WriteLine("Please select Category Name");
                        var ch = categoryService.GetAll();
                        var categoryName = Console.ReadLine();
                        var getCategory = categoryService.Get(categoryName);
                        var getMentorInCategory = mentorService.GetbyCategoryId(getCategory.Id);
                        if (getMentorInCategory.Count == 0)
                        {
                            Console.WriteLine("No Mentor in Category");
                            UseCaseMentee();
                        }
                        Random random = new Random();
                        var index = random.Next(0,getMentorInCategory.Count);
                        var mentor = getMentorInCategory[index];
                        if (mentor.RefNum == getMentee.MentorRef)
                        {
                            index = random.Next(0,getMentorInCategory.Count);
                            mentor = getMentorInCategory[index];
                        }
                        updateMenteeRequestModel.Id = MainMenu.loggedInId;
                        updateMenteeRequestModel.mentorId =mentor.mentorId;
                        if (getMentee != null)
                        {
                            menteeService.Update(updateMenteeRequestModel);
                            System.Console.WriteLine($"Mentor Assigned and email is {mentor.RefNum}");
                        }
                        UseCaseMentee();
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
                UseCaseMentee();

            }
        }

        private void Update()
        {
            var array = new string[] { "FirstName", "LastName", "Address", "PhoneNumber", "Age", "Password" };
            int id = 1;
            foreach (var item in array)
            {
                System.Console.WriteLine($"{id}\t{item}");
                id++;
            }
            System.Console.WriteLine("Enter the amount of the item you want to update");
            int response = int.TryParse(Console.ReadLine(), out int result) ? result : 0;
            Looping(response);


        }

        private void Looping(int response)
        {
            try
            {
                         
               // var GetMentee = menteeService.Get(MainMenu.loggedInId);
                // var profileObj = profileService.Get(GetMentee.ProfileId);
                //var userObj = userService.Get(MainMenu.loggedInEmail);
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
                            updateProfileRequestModel.Age = int.TryParse(Console.ReadLine(), out int result) ? result : 0;
                            break;

                        case 6:
                            System.Console.WriteLine("Enter the value");
                             password = Console.ReadLine();
                            break;

                        default:
                            System.Console.WriteLine("Invalid Input");
                            break;
                    }
                }
                 var getMentee = menteeService.Get(MainMenu.loggedInId);
                updateProfileRequestModel.Id = getMentee.ProfileId;
                profileService.UpdateProfile(updateProfileRequestModel);
                if(!string.IsNullOrWhiteSpace(password))
                {
                    userService.UpdateUser(MainMenu.loggedInEmail, password );
                }
                
            }
            catch (Exception ex)
            {

                System.Console.WriteLine(ex.Message);
                Update();
            }
        }

        public void Messaging()
        {
            try
            {
                var mentee = menteeService.Get(MainMenu.loggedInId);
                if (mentee.MentorId == 0)
                {
                    System.Console.WriteLine("Cannot chat, No mentor assigned!");
                }
                else
                {

                    var getChat = chatService.GetbyId(mentee.menteeId, mentee.MentorId);
                    if (getChat == null)
                    {
                        Chat chat = new Chat()
                        {
                            IsDeleted = false,
                            MenteeId = mentee.menteeId,
                            MentorId = mentee.MentorId,

                        };
                        chatService.Create(chat);
                        var getChat2 = chatService.GetbyId(mentee.menteeId, mentee.MentorId);
                        System.Console.Write("Enter the message you want to send :");
                        var messageContent = Console.ReadLine();
                        Message message = new Message()
                        {
                            ChatId = getChat2.Id,
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
            catch (Exception ex)
            {
                System.Console.WriteLine(ex.Message);
                UseCaseMentee();
            }
        }

    }
}

