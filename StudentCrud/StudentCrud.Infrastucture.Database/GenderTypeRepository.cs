using StudentCrud.Domain.Model.DatabaseModels;
using StudentCrud.Domain.Model.Repositories;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;

namespace StudentCrud.Infrastucture.Database
{
    public class GenderTypeRepository : IGenderTypeRepository
    {
        private readonly string connectionString = ConfigurationManager.ConnectionStrings["localDB"].ConnectionString;
        public IEnumerable<GenderType> GetAll()
        {
            var genderType = new List<GenderType>();
            
            try 
            { 
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
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }

            return genderType;
        }

        public GenderType GetBy(int gender_Type_Id)
        {
            var genderType = new List<GenderType>();

            try 
            { 
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
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }

            return genderType.FirstOrDefault();
        }

        private string GetValue(object field)
        {
            return field != null ? field.ToString() : string.Empty;
        }
    }
}
