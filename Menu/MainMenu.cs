using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AdoProject.DTO;
using AdoProject.Service.Implementation;
using AdoProject.Service.Interface;

namespace AdoProject.Menu
{
    public class MainMenu
    {
         IUserService userService = new UserService();
         IMenteeService menteeService = new MenteeService();
         IMentorService mentorService = new MentorService();
        MenteeMenu menteeMenu = new MenteeMenu();
        MentorMenu mentorMenu = new MentorMenu();
        ManagerMenu managerMenu = new ManagerMenu();
        public static string loggedInEmail = "";
        public static int loggedInId = 0;

        public void UserMenu()
        {
            Console.WriteLine("Enter 1 to register as a Mentor \nEnter 2 to register as a Mentee \nEnter 3 to login");
            int opt = int.Parse(Console.ReadLine());



            if (opt == 1)
            {
                mentorMenu.CreateMentor();
                Options();
            }
            else if (opt == 2)
            {
                menteeMenu.CreateMentee();
                Options();

            }
            else if (opt == 3)
            {
                LoginMenu();

            }
            else
            {
                Console.WriteLine("invalid input");
                UserMenu();
            }
        }

        public void LoginMenu()
        {
            Console.Write("enter your email: ");
            string email = Console.ReadLine();

            Console.Write("enter your password: ");
            string pass = Console.ReadLine();

            LoginRequestModel loginRequestModel = new LoginRequestModel()
            {
                Email = email,
                Password = pass,
            };
            var response = userService.Login(loginRequestModel);

            if (response != null)
            {
                loggedInEmail = email;
                var getUser = userService.Get(email);
                System.Console.WriteLine("Login successful");
                if (response.Role == "Mentee")
                {
                    var menteeId = menteeService.GetByUserId(getUser.Id);
                    loggedInId = menteeId.menteeId;
                    menteeMenu.UseCaseMentee();
                    Options();
                }
                else if (response.Role == "Mentor")
                {
                    var mentorId = mentorService.GetByUserId(getUser.Id);
                    loggedInId = mentorId.mentorId;
                    mentorMenu.UseCaseMentor();
                    Options();
                }
                else if (response.Role == "Manager")
                {
                    managerMenu.Menu();
                    Options();
                }

            }
            else
            {
                System.Console.WriteLine("Login Failed press 1 to Try again or press any number to go to Menu");
                var input = int.Parse(Console.ReadLine());
                if (input == 1)
                {
                    LoginMenu();
                }
                else
                {
                    UserMenu();
                }


            }

        }
        public void Options()
        {
            System.Console.WriteLine("Enter 1 to login \nEnter 2 to go to Main menu");
            int option = int.Parse(Console.ReadLine());
            if (option == 1)
            {
                LoginMenu();
            }
            else
            {
                UserMenu();
            }
        }



    }
}