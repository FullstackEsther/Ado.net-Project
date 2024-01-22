using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AdoProject.Context;
using AdoProject.Model;
using AdoProject.Repository.Interface;
using MySql.Data.MySqlClient;

namespace AdoProject.Repository.Implementation
{
    public class UserRepository : IUserRepository
    {
        
        public bool Check(string email)
        {
            using (var conn = new MySqlConnection(TablesContext.connectionString))
            {
                conn.Open();
                var query = $"Select * from User where email = '{email}';";
                var command = new MySqlCommand(query, conn);
                var reader = command.ExecuteReader();
                if (reader.Read())
                {
                    return true;
                }
                return false;
            }
        }

        public void Create(User obj)
        {
            int sqlBitValue = obj.IsDeleted ? 1 : 0;
            using (var conn = new MySqlConnection(TablesContext.connectionString))
            {
                conn.Open();
                var query = $"insert into User (id , email , password , role , isDeleted) values('{obj.Id}', '{obj.Email}', '{obj.Password}', '{obj.Role}', '{sqlBitValue}');";
                var command = new MySqlCommand(query, conn);
                command.ExecuteNonQuery();  
            }
        }

        public bool Delete(int id)
        {
           using (var conn = new MySqlConnection(TablesContext.connectionString))
            {
                conn.Open();
                var query = $"Update User set isDeleted = 1 where id = '{id}';";
                var command = new MySqlCommand(query, conn);
                var reader = command.ExecuteNonQuery(); 
                if (reader > 0)
                {
                    return true;
                }
                return false;
            }
        }

        public User Get(string email)
        {
            using (var conn = new MySqlConnection(TablesContext.connectionString))
            {
                conn.Open();
                var query = $"Select * from User where email = '{email}';";
                var command = new MySqlCommand(query, conn);
                var reader = command.ExecuteReader(); 
                while (reader.Read())
                {
                    return new User{Id = (int)reader["id"], Email = reader["email"].ToString(), Password = reader["password"].ToString(), Role = reader["role"].ToString(), IsDeleted = Convert.ToBoolean(reader["isDeleted"])};
                } 
                return null;
            }
           
        }

        public User Get(int id)
        {
            using (var conn = new MySqlConnection(TablesContext.connectionString))
            {
                conn.Open();
                var query = $"Select * from User where Id = '{id}';";
                var command = new MySqlCommand(query, conn);
                var reader = command.ExecuteReader(); 
                while (reader.Read())
                {
                    return new User{Id = (int)reader["id"], Email = reader["email"].ToString(), Password = reader["password"].ToString(), Role = reader["role"].ToString(), IsDeleted = Convert.ToBoolean(reader["isDeleted"])};
                } 
                return null;
            }
        }

        public List<User> GetAll()
        {
            var getAll = new List<User>();
              using (var conn = new MySqlConnection(TablesContext.connectionString))
            {
                conn.Open();
                var query = $"Select * from User ;";
                var command = new MySqlCommand(query, conn);
                var reader = command.ExecuteReader(); 
                while (reader.Read())
                {
                   getAll.Add(new User{Id = (int)reader["id"], Email = reader["email"].ToString(), Password = reader["password"].ToString(), Role = reader["role"].ToString(), IsDeleted = Convert.ToBoolean(reader["isDeleted"])});
                   return getAll;
                } 
                return null;
            }
        }

        public User GetbyEmailAndPin(string email, string password)
        {
             using (var conn = new MySqlConnection(TablesContext.connectionString))
            {
                conn.Open();
                var query = $"Select * from User where email = '{email}'&& password = '{password}' ;";
                var command = new MySqlCommand(query, conn);
                var reader = command.ExecuteReader(); 
                while (reader.Read())
                {
                    return new User{Id = (int)reader["id"], Email = reader["email"].ToString(), Password = reader["password"].ToString(), Role = reader["role"].ToString(), IsDeleted = Convert.ToBoolean(reader["isDeleted"])};
                } 
                return null;
            }
        }

        public bool Update(string email, string password)
        {
            using (var conn = new MySqlConnection(TablesContext.connectionString))
            {
                conn.Open();
                var query = $"Update User set password = '{password}' where email = '{email}';";
                var command = new MySqlCommand(query, conn);
                var reader = command.ExecuteNonQuery(); 
                if (reader > 0)
                {
                    return true;
                }
                return false;
            }
        }
         public int GetUserId()
        {
            using (var conn = new MySqlConnection(TablesContext.connectionString))
            {
                
                conn.Open();
                var query = " SELECT MAX(id) FROM User;";
                var command = new MySqlCommand(query, conn);
                int rowCount = Convert.ToInt32(command.ExecuteScalar());
                return rowCount;
            }
        }
    }
}