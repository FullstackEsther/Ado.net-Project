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
    public class ChatRepository : IChatRepository
    {
        
        public void Create(Chat obj)
        {
            int sqlBitValue = obj.IsDeleted ? 1 : 0;
            using (var conn = new MySqlConnection(TablesContext.connectionString))
            {
                conn.Open();
                var query = $"insert into Chat (id, menteeId, mentorId,  isDeleted) values( '{obj.Id}', '{obj.MenteeId}', '{obj.MentorId}', '{sqlBitValue}');";
                var command = new MySqlCommand(query, conn);
                command.ExecuteNonQuery();
            }
        }

        // public bool Delete(int id)
        // {
        //     using (var conn = new MySqlConnection(connectionString))
        //     {
        //         conn.Open();
        //         var query = $"Update Chat set isDeleted = 1 where id = '{id}';";
        //         var command = new MySqlCommand(query, conn);
        //         var reader = command.ExecuteNonQuery();
        //         if (reader > 0)
        //         {
        //             return true;
        //         }
        //         return false;
        //     }
        // }

        public Chat Get(int id)
        {
            using (var conn = new MySqlConnection(TablesContext.connectionString))
            {
                conn.Open();
                var query = $"Select * from Chat where Id = '{id}';";
                var command = new MySqlCommand(query, conn);
                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    return new Chat { Id = (int)reader["id"], MenteeId = (int)reader["menteeId"], MentorId = (int)reader["mentorId"], IsDeleted = Convert.ToBoolean(reader["isDeleted"]) };
                }
                return null;
            }
        }
            public List<Chat> GetAll()
            {
                var getAll = new List<Chat>();
              using (var conn = new MySqlConnection(TablesContext.connectionString))
            {
                conn.Open();
                var query = $"Select * from Chat ;";
                var command = new MySqlCommand(query, conn);
                var reader = command.ExecuteReader(); 
                while (reader.Read())
                {
                   getAll.Add(new Chat {Id = (int)reader["id"], MenteeId = (int)reader["menteeId"], MentorId = (int)reader["mentorId"], IsDeleted = Convert.ToBoolean(reader["isDeleted"])} );
                } 
                return getAll;
            }
            }

            public Chat GetbyId(int menteeId, int mentorId)
            {
                using (var conn = new MySqlConnection(TablesContext.connectionString))
            {
                conn.Open();
                var query = $"Select * from Chat where menteeId = '{menteeId}' And mentorId = '{mentorId}';";
                var command = new MySqlCommand(query, conn);
                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    return new Chat { Id = (int)reader["id"], MenteeId = (int)reader["menteeId"], MentorId = (int)reader["mentorId"], IsDeleted = Convert.ToBoolean(reader["isDeleted"]) };
                }
                return null;
            }
            }

            // public Chat GetbyRefNo(string menteeRef)
            // {
            //     throw new NotImplementedException();
            // }

           
        }
    }