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
    public class ManagerRepository : IManagerRepository
    {
        
        public Manager Get(int Id)
        {
            using (var conn = new MySqlConnection(TablesContext.connectionString))
            {
                conn.Open();
                var query = $"Select * from Manager where Id = '{Id}';";
                var command = new MySqlCommand(query, conn);
                var reader = command.ExecuteReader(); 
                while (reader.Read())
                {
                    return new Manager {Id = (int)reader["id"], UserId = (int)reader["userId"] , ProfileId = (int)reader["profileId"] , IsDeleted = Convert.ToBoolean(reader["isDeleted"])};
                } 
                return null;
            }
        }
    }
}