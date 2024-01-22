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
    public class ManagerMenu
    {
        ICategoryService categoryService = new CategoryService();
        IUserService userService = new UserService();
        IProfileService profileService = new ProfileService();
        IMenteeService menteeService = new MenteeService();
        IMentorService mentorService = new MentorService();
        IManagerService managerService = new ManagerService();

         public void Menu()
        {
            while (true)
            {
                System.Console.WriteLine(" Enter 1 to Add Category \n Enter 2 to View mentee \n Enter 3 to View Mentor \n Enter 4 to Delete User \n Enter 5 to View all Mentees \n Enter 6 to view all mentors \n Enter 7 to view all Category \n Enter 8 to go back ");
                int opt = int.Parse(Console.ReadLine());
                if (opt == 1)
                {
                    System.Console.WriteLine("Enter the name of the Category");
                    string name = Console.ReadLine();

                    Category category = new Category
                    {
                            Name = name,
                            IsDeleted = false
                                
                    };
                    categoryService.Create(category);
                        Menu();

                }
                else if (opt == 2)
                {
                    menteeService.GetAll();
                    System.Console.WriteLine("Enter the id of the mentee");
                    int id = int.Parse(Console.ReadLine());
                    menteeService.ToStrings(menteeService.Get(id));
                    Menu();
                }
                else if (opt == 3)
                {
                    mentorService.GetAllMentors();
                    System.Console.WriteLine("Enter the Id of the Mentor");
                    int Id = int.Parse(Console.ReadLine());

                    mentorService.ToStrings(mentorService.Get(Id));
                    Menu();
                }
                else if (opt == 4)
                {
                    System.Console.WriteLine("Enter 1 to delete Mentee /n Enter 2 to delete Mentor");
                    int input = int.Parse(Console.ReadLine());
                    if (input == 1)
                    {
                        DeleteMentee();
                    }
                    if (input == 2)
                    {
                        DeleteMentor();
                    }
                }
                else if (opt == 5)
                {
                    menteeService.GetAll();
                }
                else if (opt == 6)
                {
                    mentorService.GetAllMentors();
                }
                else if (opt == 7)
                {
                    categoryService.GetAll();
                }


                else if (opt == 8)
                {
                    break;
                }
                else
                {
                    System.Console.WriteLine("invalid input");
                }


            }

        }

        private void DeleteMentee()
        {
            var get = menteeService.GetAll();
            if (get.Count == 0)
            {
                System.Console.WriteLine("There are no mentees in this list");
            }
            else
            {
                System.Console.WriteLine("Enter the Id you want to delete");
                int id = int.Parse(Console.ReadLine());
                var getMentee = menteeService.Get(id);
                userService.Delete(getMentee.UserId);
                profileService.Delete(getMentee.ProfileId);
                menteeService.Delete(id);
            }

        }

        private void DeleteMentor()
        {
            var get = mentorService.GetAllMentors();
            if (get.Count == 0)
            {
                System.Console.WriteLine("There are no mentors in this list");
            }
            else
            {
                System.Console.WriteLine("Enter the Id you want to delete");
                int id = int.Parse(Console.ReadLine());
                var getMentor = mentorService.Get(id);
                userService.Delete(getMentor.UserId);
                profileService.Delete(getMentor.ProfileId);
                mentorService.Delete(id);
            }

        }

       

        // public void ListToStrings(List<MenteeDto> mentees)
        // {
        //     foreach (var item in mentees)
        //     {
        //         System.Console.WriteLine($"Email: {item.Email} \t FirstName: {item.FirstName} \t LastName: {item.LastName} \t Id: {item.menteeId} \t MentorId: {item.MentorId}");
        //     }
        // }


    }
}
    
