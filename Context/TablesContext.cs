using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace AdoProject.Context
{
    public class TablesContext
    {
        public static string connectionString = "Server = localhost ; user = root ; database = chatconsole; password = 123456789";
        
        public static void CreateDb(string connectionString)
        {
            using (var connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                var query = "Create Database if not exists ChatConsole;";
                var command = new MySqlCommand(query, connection);
                command.ExecuteNonQuery();
            }
        }

        public static void CreateUser(string connectionString)
        {
            using (var connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                var query = "Create Table if not exists User(id int auto_increment primary key , email varchar(50), password varchar(30), role varchar(30), isDeleted TINYINT );";
                var command = new MySqlCommand(query, connection);
                command.ExecuteNonQuery();
             
            }
        }

        public static void CreateProfile(string connectionString)
        {
            using (var connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                var query = "Create Table if not exists Profile(id int auto_increment primary key, age int, firstName varchar(25),  lastName varchar(25), address varchar(30), PhoneNumber varchar(11), isDeleted TINYINT)";
                var command = new MySqlCommand(query, connection);
                command.ExecuteNonQuery();
             
            }
        }

        public static void CreateMentor(string connectionString)
        {
            using (var connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                var query = "Create Table if not exists Mentor(id int auto_increment primary key, UserId int, FOREIGN KEY (UserId) REFERENCES User(id), categoryId int, FOREIGN KEY (categoryId) REFERENCES category(id),profileId int, FOREIGN KEY (profileId) REFERENCES Profile(id), mentorStatus int, yearsOfExperience int, refNum varchar(20), isDeleted TINYINT );";
                var command = new MySqlCommand(query, connection);
                command.ExecuteNonQuery();
            }
        }

        public static void CreateMentee(string connectionString)
        {
            using (var connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                var query = "Create Table if not exists Mentee(id int auto_increment primary key, mentorId int NULL, FOREIGN KEY(mentorId) REFERENCES mentor(id), UserId int, FOREIGN KEY(UserId) REFERENCES user(id),ProfileId int, FOREIGN KEY (ProfileId) REFERENCES Profile(id), referenceNo varchar(25),  isDeleted TINYINT );";
                var command = new MySqlCommand(query, connection);
                command.ExecuteNonQuery();
                
            }
        }

         public static void CreateManager(string connectionString)
        {
            using (var connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                var query = "Create Table if not exists Manager(id int auto_increment primary key, userId int,FOREIGN KEY(userId) REFERENCES user(id), profileId int, FOREIGN KEY (profileId) REFERENCES Profile(id), isDeleted TINYINT );";
                var command = new MySqlCommand(query, connection);
                command.ExecuteNonQuery();
                
            }
        }

         public static void CreateChat(string connectionString)
        {
            using (var connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                var query = "Create Table if not exists Chat(id int auto_increment primary key, mentorId int, FOREIGN KEY(mentorId) REFERENCES mentor(id), menteeId int, FOREIGN KEY(menteeId) REFERENCES mentee(id), isDeleted TINYINT );";
                var command = new MySqlCommand(query, connection);
                command.ExecuteNonQuery();
            }
        }

        public static void CreateCategory(string connectionString)
        {
            using (var connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                var query = "Create Table if not exists Category(id int auto_increment primary key,Name varchar(20), isDeleted TINYINT );";
                var command = new MySqlCommand(query, connection);
                command.ExecuteNonQuery();
                
            }
        }

        public static void CreateMessage(string connectionString)
        {
            using (var connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                var query = "Create Table if not exists Message(id int auto_increment primary key,chatId int, foreign key(chatId) references chat(id),messageChat varchar(250), senderEmail varchar(30), timeSent Datetime,  isDeleted TINYINT );";
                var command = new MySqlCommand(query, connection);
                command.ExecuteNonQuery();
                
            }
        }
    }
}