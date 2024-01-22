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
    public class MessageRepository : IMessageRepository
    {

        public void Create(Message obj)
        {
            int sqlBitValue = obj.IsDeleted ? 1 : 0;
            using (var conn = new MySqlConnection(TablesContext.connectionString))
            {
               conn.Open();
                var query = $"insert into Message (id, chatId, Timesent, senderEmail, messageChat, isDeleted) values( '{obj.Id}', '{obj.ChatId}', '{obj.TimeSent.ToString("yyyy-MM-dd HH:mm:ss")}', '{obj.SenderEmail}','{obj.MessageChat}', '{sqlBitValue}');";
                var command = new MySqlCommand(query, conn);
                command.ExecuteNonQuery(); 
            } 
        }

        public bool Delete(int messageId)
        {
            using (var conn = new MySqlConnection(TablesContext.connectionString))
            {
                conn.Open();
                var query = $"Update Message set isDeleted = 1 where Id = '{messageId}';";
                var command = new MySqlCommand(query, conn);
                var reader = command.ExecuteNonQuery();
                if (reader > 0)
                {
                    return true;
                }
                return false;
            }
        }

        public Message Get(int Id)
        {
           using (var conn = new MySqlConnection(TablesContext.connectionString))
            {
                conn.Open();
                var query = $"Select * from Message where Id = '{Id}';";
                var command = new MySqlCommand(query, conn);
                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    return new Message { Id = (int)reader["id"],  ChatId= (int)reader["ChatId"],  MessageChat = reader["messageChat"].ToString(), SenderEmail= reader["senderEmail"].ToString(), TimeSent= (DateTime)reader["timeSent"], IsDeleted = Convert.ToBoolean(reader["isDeleted"]) };
                }
                return null;
            }
        }

        // public List<Message> GetAll()
        // {
        //     var listMessage = new List<Message>();
        //   using (var conn = new MySqlConnection(connectionString))
        //     {
        //         conn.Open();
        //         var query = $"Select * from Message ;";
        //         var command = new MySqlCommand(query, conn);
        //         var reader = command.ExecuteReader();
        //         while (reader.Read())
        //         {
        //             listMessage.Add(new Message { Id = (int)reader["id"],  ChatId= (int)reader["ChatId"],  MessageChat = reader["messageChat"].ToString(), SenderEmail= reader["senderEmail"].ToString(), TimeSent= (DateTime)reader["timeSent"], IsDeleted = Convert.ToBoolean(reader["isDeleted"]) });
                    
        //         }
        //         return listMessage;
            
        //     }
        //}

        public List<Message> GetChat(int ChatId)
        {
            var messages = new List<Message>();
            using (var conn = new MySqlConnection(TablesContext.connectionString))
            {
                conn.Open();
                var query = $"Select * from Message where ChatId = '{ChatId}';";
                var command = new MySqlCommand(query, conn);
                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    messages.Add(new Message { Id = (int)reader["id"],  ChatId= (int)reader["ChatId"],  MessageChat = reader["messageChat"].ToString(), SenderEmail= reader["senderEmail"].ToString(), TimeSent= (DateTime)reader["timeSent"], IsDeleted = Convert.ToBoolean(reader["isDeleted"]) });
                }
                return messages;
            }
        }

        
    }
}