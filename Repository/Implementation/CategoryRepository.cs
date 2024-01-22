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
    public class CategoryRepository : ICategoryRepository
    {
       
        public void Create(Category obj)
        {
            using (var conn = new MySqlConnection(TablesContext.connectionString))
            {
                int sqlBitValue = obj.IsDeleted ? 1 : 0;
                conn.Open();
                var query = $"insert into Category (id, Name , isDeleted) values( '{obj.Id}', '{obj.Name}', '{sqlBitValue}');";
                var command = new MySqlCommand(query, conn);
                command.ExecuteNonQuery();
            }
        }

        public Category Get(string name)
        {
             using (var conn = new MySqlConnection(TablesContext.connectionString))
            {
                conn.Open();
                var query = $"Select * from Category where name = '{name}';";
                var command = new MySqlCommand(query, conn);
                var reader = command.ExecuteReader(); 
                while (reader.Read())
                {
                    return new Category{Id = (int)reader["id"], Name = reader["name"].ToString(), IsDeleted = Convert.ToBoolean(reader["isDeleted"])};
                } 
                return null;
            }
        }

        public List<Category> GetAll()
        {
               var getAll = new List<Category>();
               using (var conn = new MySqlConnection(TablesContext.connectionString))
            {
                conn.Open();
                var query = $"Select * from Category ;";
                var command = new MySqlCommand(query, conn);
                var reader = command.ExecuteReader(); 
                while (reader.Read())
                {
                   getAll.Add(new Category{Id = (int)reader["id"],Name = reader["name"].ToString() , IsDeleted = Convert.ToBoolean(reader["isDeleted"])});
                   
                } 
                return getAll;
        }
    }
}
}