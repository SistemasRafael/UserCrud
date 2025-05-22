using StudentCrud.Domain.Model.DatabaseModels;
using StudentCrud.Domain.Model.Repositories;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;

namespace StudentCrud.Infrastucture.Database
{
    public class EmailTypeRepository : IEmailTypeRepository
    {
        private readonly string connectionString = ConfigurationManager.ConnectionStrings["localDB"].ConnectionString;

        public IEnumerable<EmailType> GetAll()
        {
            var emailTypes = new List<EmailType>();
            try 
            { 
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlCommand command = connection.CreateCommand())
                    {
                        command.CommandText = "[dbo].[spGetAllEmailType]";
                        command.CommandType = System.Data.CommandType.StoredProcedure;

                        using (var reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                emailTypes.Add(new EmailType()
                                {
                                    Email_Type_Id = int.Parse(GetValue(reader["Email_Type_Id"])),
                                    Email_Type = GetValue(reader["Email_Type"])
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

            return emailTypes;
        }

        public EmailType GetBy(int email_Type_Id)
        {
            var emailTypes = new List<EmailType>();
            
            try 
            { 
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlCommand command = connection.CreateCommand())
                    {
                        command.CommandText = "[dbo].[spGetByEmailType]";
                        command.CommandType = System.Data.CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@Email_Type_Id", email_Type_Id);

                        using (var reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                emailTypes.Add(new EmailType()
                                {
                                    Email_Type_Id = int.Parse(GetValue(reader["Email_Type_Id"])),
                                    Email_Type = GetValue(reader["Email_Type"])
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

            return emailTypes.FirstOrDefault();
        }

        private string GetValue(object field)
        {
            return field != null ? field.ToString() : string.Empty;
        }
    }
}
