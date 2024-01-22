using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AdoProject.Context;
using AdoProject.Model;
using AdoProject.Repository.Interface;
using MySql.Data.MySqlClient;
using Org.BouncyCastle.Asn1.Misc;

namespace AdoProject.Repository.Implementation
{
    public class ProfileRepository : IProfileRepository
    {
        public void Create(Profile obj)
        {
            int sqlBitValue = obj.IsDeleted ? 1 : 0;
            using (var conn = new MySqlConnection(TablesContext.connectionString))
            {
                conn.Open();
                var query = $"insert into Profile (id , age , firstName , lastName, address, phoneNumber, isDeleted) values('{obj.Id}', '{obj.Age}', '{obj.FirstName}', '{obj.LastName}','{obj.Address}', '{obj.PhoneNumber}','{sqlBitValue}');";
                var command = new MySqlCommand(query, conn);
                command.ExecuteNonQuery();
            }
        }

        public bool Delete(int id)
        {
            using (var conn = new MySqlConnection(TablesContext.connectionString))
            {
                conn.Open();
                var query = $"Update Profile set isDeleted = 1 where Id = '{id}';";
                var command = new MySqlCommand(query, conn);
                var reader = command.ExecuteNonQuery(); 
                if (reader > 0)
                {
                    return true;
                }
                return false;
            }
        }

        public Profile Get(int Id)
        {
            using (var conn = new MySqlConnection(TablesContext.connectionString))
            {
                conn.Open();
                var query = $"Select * from profile where Id = '{Id}';";
                var command = new MySqlCommand(query, conn);
                var reader = command.ExecuteReader(); 
                while (reader.Read())
                {
                    return new Profile {Id = (int)reader["id"], Age = (int)reader["age"], FirstName = reader["firstName"].ToString(), LastName = reader["lastName"].ToString(), Address = reader["address"].ToString(), PhoneNumber = reader["phoneNumber"].ToString(), IsDeleted = Convert.ToBoolean(reader["isDeleted"])};
                } 
                return null;
            }
        }

        public List<Profile> GetAll()
        {
             var getAll = new List<Profile>();
              using (var conn = new MySqlConnection(TablesContext.connectionString))
            {
                conn.Open();
                var query = $"Select * from Profile ;";
                var command = new MySqlCommand(query, conn);
                var reader = command.ExecuteReader(); 
                while (reader.Read())
                {
                   getAll.Add(new Profile {Id = (int)reader["id"], Age = (int)reader["age"], FirstName = reader["firstName"].ToString(), LastName = reader["lastName"].ToString(), Address = reader["address"].ToString(), PhoneNumber = reader["phoneNumber"].ToString(),  IsDeleted = Convert.ToBoolean(reader["isDeleted"])});
                } 
                return getAll;
            }
        }

        // public Profile GetbyMentorId(int mentorId)
        // {
        //     using (var conn = new MySqlConnection(connectionString))
        //     {
        //         conn.Open();
        //         var query = $"Select * from profile where mentorId = '{mentorId}';";
        //         var command = new MySqlCommand(query, conn);
        //         var reader = command.ExecuteReader(); 
        //         while (reader.Read())
        //         {
        //             return new Profile {Id = (int)reader["id"], Age = (int)reader["age"], FirstName = reader["firstName"].ToString(), LastName = reader["lastName"].ToString(), Address = reader["address"].ToString(), PhoneNumber = reader["phoneNumber"].ToString(), IsDeleted = Convert.ToBoolean(reader["isDeleted"])};
        //         } 
        //         return null;
        //     }
        // }

        public bool Update(Profile obj)
        {
           using (var conn = new MySqlConnection(TablesContext.connectionString))
            {
                conn.Open();
                var query = $"Update Profile set age = '{obj.Age}', firstName = '{obj.FirstName}', lastName = '{obj.LastName}', address = '{obj.Address}', phoneNumber = '{obj.PhoneNumber}' where id = '{obj.Id}';";
                var command = new MySqlCommand(query, conn);
                var reader = command.ExecuteNonQuery(); 
                if (reader > 0)
                {
                    return true;
                }
                return false;
            }
        }
       
        public int GetProfileId()
        {
            using (var conn = new MySqlConnection(TablesContext.connectionString))
            {
                conn.Open();
                var query = " SELECT MAX(id) FROM Profile;";
                var command = new MySqlCommand(query, conn);
                int rowCount = Convert.ToInt32(command.ExecuteScalar());
                return rowCount;
            }
        }

   
        
    }
}