using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AdoProject.Context;
using AdoProject.Model;
using AdoProject.Repository.Interface;
using MySql.Data.MySqlClient;
using Newtonsoft.Json;

namespace AdoProject.Repository.Implementation
{
    public class MentorRepository : IMentorRepository
    {


        public void Create(Mentor obj)
        {
            int sqlBitValue = obj.IsDeleted ? 1 : 0;
            using (var conn = new MySqlConnection(TablesContext.connectionString))
            {
                conn.Open();
                var query = $"insert into Mentor (id, userId , categoryId , yearsOfExperience ,profileId, refNum, mentorStatus, isDeleted) values( '{obj.Id}', '{obj.UserId}', '{obj.CategoryId}','{obj.YearsOfExperience}', '{obj.ProfileId}','{obj.RefNum}', '1','{sqlBitValue}');";
                var command = new MySqlCommand(query, conn);
                command.ExecuteNonQuery();
            }
        }

        public bool Delete(int id)
        {
            using (var conn = new MySqlConnection(TablesContext.connectionString))
            {
                conn.Open();
                var query = $"Update Mentor set isDeleted = 1 where id = '{id}';";
                var command = new MySqlCommand(query, conn);
                var reader = command.ExecuteNonQuery(); 
                if (reader > 0)
                {
                    return true;
                }
                return false;
            }
        }

        public Mentor Get(int id)
        {
             using (var conn = new MySqlConnection(TablesContext.connectionString))
            {
                conn.Open();
                var query = $"Select * from Mentor where Id = '{id}';";
                var command = new MySqlCommand(query, conn);
                var reader = command.ExecuteReader(); 
                while (reader.Read())
                {
                    return new Mentor {Id = (int)reader["id"], CategoryId =(int) reader["categoryId"], ProfileId =(int) reader["profileId"], MentorStatus = (MentorStatus)reader["mentorStatus"] ,YearsOfExperience = (int) reader["yearsOfExperience"], RefNum = reader["RefNum"].ToString(), UserId = (int)reader["userId"], IsDeleted = Convert.ToBoolean(reader["isDeleted"])};
                } 
                return null;
            }
        }

        public List<Mentor> GetAll()
        {
             var getAll = new List<Mentor>();
              using (var conn = new MySqlConnection(TablesContext.connectionString))
            {
                conn.Open();
                var query = $"Select * from Mentor ;";
                var command = new MySqlCommand(query, conn);
                var reader = command.ExecuteReader(); 
                while (reader.Read())
                {
                   getAll.Add(new Mentor {Id = (int)reader["id"], CategoryId =(int) reader["categoryId"], RefNum = (string) reader["refNum"], UserId = (int)reader["userId"],  ProfileId =(int) reader["profileId"], MentorStatus = (MentorStatus)reader["mentorStatus"], YearsOfExperience = (int) reader["yearsOfExperience"] , IsDeleted = Convert.ToBoolean(reader["isDeleted"])});
                } 
                return getAll;
            }
        }

        public List<Mentor> GetbyCategoryId(int categoryId)
        {
             var getAll = new List<Mentor>();
             using (var conn = new MySqlConnection(TablesContext.connectionString))
            {
                conn.Open();
                var query = $"Select * from Mentor where categoryId = '{categoryId}';";
                var command = new MySqlCommand(query, conn);
                var reader = command.ExecuteReader(); 
                while (reader.Read())
                {
                    
                  getAll.Add(new Mentor {Id = (int)reader["id"], CategoryId =(int) reader["categoryId"], UserId = (int)reader["userId"], RefNum = reader["RefNum"].ToString(),ProfileId =(int) reader["profileId"], MentorStatus = (MentorStatus)reader["mentorStatus"] ,YearsOfExperience = (int) reader["yearsOfExperience"] , IsDeleted = Convert.ToBoolean(reader["isDeleted"])});
                  
                } 
                return getAll;
            }
        }

        public Mentor GetbyRefNum(string refNum)
        {
             using (var conn = new MySqlConnection(TablesContext.connectionString))
            {
                conn.Open();
                var query = $"Select * from Mentor where refnum = '{refNum}';";
                var command = new MySqlCommand(query, conn);
                var reader = command.ExecuteReader(); 
                while (reader.Read())
                {
                    return new Mentor {Id = (int)reader["id"], CategoryId =(int) reader["categoryId"], UserId = (int)reader["userId"], RefNum = reader["RefNum"].ToString(),ProfileId =(int) reader["profileId"], MentorStatus = (MentorStatus)reader["mentorStatus"] ,YearsOfExperience = (int) reader["yearsOfExperience"] , IsDeleted = Convert.ToBoolean(reader["isDeleted"])};
                } 
                return null;
            }
        }

        public Mentor GetByUserId(int userId)
        {
            using (var conn = new MySqlConnection(TablesContext.connectionString))
            {
                conn.Open();
                var query = $"Select * from Mentor where userid = '{userId}';";
                var command = new MySqlCommand(query, conn);
                var reader = command.ExecuteReader(); 
                while (reader.Read())
                {
                    return new Mentor {Id = (int)reader["id"], CategoryId =(int) reader["categoryId"], ProfileId =(int) reader["profileId"], MentorStatus = (MentorStatus)reader["mentorStatus"] ,YearsOfExperience = (int) reader["yearsOfExperience"], RefNum = reader["RefNum"].ToString(), UserId = (int)reader["userId"], IsDeleted = Convert.ToBoolean(reader["isDeleted"])};
                } 
                return null;
            }
        }

        public bool Update(Mentor obj)
        {
            using (var conn = new MySqlConnection(TablesContext.connectionString))
            {
                conn.Open();
                var query = $"Update Mentor set MentorStatus = '{Convert.ToInt32(obj.MentorStatus)}', yearsOfExperience = '{obj.YearsOfExperience}' where id = '{obj.Id}';";
                var command = new MySqlCommand(query, conn);
                var reader = command.ExecuteNonQuery(); 
                if (reader > 0)
                {
                    return true;
                }
                return false;
            }
        }
        
    }
}