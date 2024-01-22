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
    public class MenteeRepository : IMenteeRepository
    {
        public void Create(Mentee obj)
        {
          
            int sqlBitValue = obj.IsDeleted ? 1 : 0;
            using (var conn = new MySqlConnection(TablesContext.connectionString))
            {
                conn.Open(); 
                var query = $"insert into Mentee (id, userId , mentorId ,profileId, referenceNo, isDeleted) values( '{obj.Id}', '{obj.UserId}', '{obj.MentorId}', '{obj.ProfileId}','{obj.ReferenceNo}', '{sqlBitValue}');";
                var command = new MySqlCommand(query, conn);
                command.ExecuteNonQuery();
            }
        }

        public bool Delete(int id)
        {
           using (var conn = new MySqlConnection(TablesContext.connectionString))
            {
                conn.Open();
                var query = $"Update Mentee set isDeleted = 1 where id = '{id}';";
                var command = new MySqlCommand(query, conn);
                var reader = command.ExecuteNonQuery(); 
                if (reader > 0)
                {
                    return true;
                }
                return false;
            }
        }

        public Mentee Get(int id)
        {
             using (var conn = new MySqlConnection(TablesContext.connectionString))
            {
                conn.Open();
                var query = $"Select * from Mentee where Id = '{id}';";
                var command = new MySqlCommand(query, conn);
                var reader = command.ExecuteReader(); 
                while (reader.Read())
                {
                    return new Mentee {Id = (int)reader["id"], UserId =(int) reader["userid"],ProfileId =(int) reader["profileId"], MentorId = (int) reader["mentorId"],ReferenceNo =  reader["referenceNo"].ToString() ,IsDeleted = Convert.ToBoolean(reader["isDeleted"])};
                } 
                return null;
            }
        }

        public List<Mentee> GetAll()
        {
             var getAll = new List<Mentee>();
              using (var conn = new MySqlConnection(TablesContext.connectionString))
            {
                conn.Open();
                var query = $"Select * from Mentee ;";
                var command = new MySqlCommand(query, conn);
                var reader = command.ExecuteReader(); 
                while (reader.Read())
                {
                   getAll.Add(new Mentee {Id = (int)reader["id"], UserId =(int) reader["userid"],ProfileId =(int) reader["profileId"], MentorId = (int) reader["mentorId"],ReferenceNo =  reader["referenceNo"].ToString() ,IsDeleted = Convert.ToBoolean(reader["isDeleted"])});
                } 
                return getAll;
            }
        }

        public bool Update(int mentorId, int id)
        {
           using (var conn = new MySqlConnection(TablesContext.connectionString))
            {
                conn.Open();
                var query = $"Update Mentee set mentorId = '{mentorId}'  where id = '{id}';";
                var command = new MySqlCommand(query, conn);
                var reader = command.ExecuteNonQuery(); 
                if (reader > 0)
                {
                    return true;
                }
                return false;
            }
        }

         public int GetMenteeId()
        {
            using (var conn = new MySqlConnection(TablesContext.connectionString))
            {
                
                conn.Open();
                var query = " SELECT MAX(id) FROM Mentee;";
                var command = new MySqlCommand(query, conn);
                int rowCount = Convert.ToInt32(command.ExecuteScalar());
                return rowCount;
            }
        }

        public List<Mentee> GetMenteesByMentorId(int mentorId)
        {
            var getAll = GetAll().Where(c => c.MentorId == mentorId && c.IsDeleted == false).ToList();
            if (getAll.Count == 0)
            {
                System.Console.WriteLine("No Mentee Assigned");
                return new List<Mentee>();
            }
            return getAll;
        }
        public Mentee GetByUserId(int userId)
        {
             using (var conn = new MySqlConnection(TablesContext.connectionString))
            {
                conn.Open();
                var query = $"Select * from Mentee where userid = '{userId}';";
                var command = new MySqlCommand(query, conn);
                var reader = command.ExecuteReader(); 
                while (reader.Read())
                {
                    return new Mentee {Id = (int)reader["id"], UserId =(int) reader["userid"],ProfileId =(int) reader["profileId"], MentorId = (int) reader["mentorId"],ReferenceNo =  reader["referenceNo"].ToString() ,IsDeleted = Convert.ToBoolean(reader["isDeleted"])};
                } 
                return null;
            }
        }
    }
}