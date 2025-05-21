using StudentCrud.Domain.Model.DatabaseModels;
using StudentCrud.Domain.Model.Repositories;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace StudentCrud.Infrastucture.Database
{
    public class GenderTypeRepository : IGenderTypeRepository
    {
        private readonly string connectionString = "Server=192.168.1.7\\SQLEXPRESS;Integrated Security=false;Initial Catalog=CrudStudent;User ID=sa;Password=12baterista;";
        public IEnumerable<GenderType> GetAll()
        {
            var genderType = new List<GenderType>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = "[dbo].[spGetAllGenderType]";
                    command.CommandType = System.Data.CommandType.StoredProcedure;

                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            genderType.Add(new GenderType()
                            {
                                Gender_Type_Id = int.Parse(GetValue(reader["Gender_Type_Id"])),
                                Gender_Type = GetValue(reader["Gender_Type"])
                            });
                        }
                    }
                }
            }

            return genderType;
        }

        public GenderType GetBy(int gender_Type_Id)
        {
            var genderType = new List<GenderType>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = "[dbo].[spGetByGenderType]";
                    command.CommandType = System.Data.CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@Gender_Type_Id", gender_Type_Id);

                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            genderType.Add(new GenderType()
                            {
                                Gender_Type_Id = int.Parse(GetValue(reader["Gender_Type_Id"])),
                                Gender_Type = GetValue(reader["Gender_Type"])
                            });
                        }
                    }
                }
            }

            return genderType.FirstOrDefault();
        }

        private string GetValue(object field)
        {
            return field != null ? field.ToString() : string.Empty;
        }
    }
}
