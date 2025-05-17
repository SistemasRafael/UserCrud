using StudentCrud.Domain.Model.Common;
using StudentCrud.Domain.Model.DatabaseModels;
using StudentCrud.Domain.Model.Repositories;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace StudentCrud.Infrastucture.Database
{
    public class EmailRepository : IEmailRepository
    {
        private readonly string connectionString = "Server=192.168.1.7\\SQLEXPRESS;Integrated Security=false;Initial Catalog=CrudStudent;User ID=sa;Password=12baterista;";

        public ResultTrack Add(Email entity)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlCommand command = connection.CreateCommand())
                    {
                        command.CommandText = "[dbo].[spAddEmail]";
                        command.CommandType = System.Data.CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@Student_Id", entity.Student_Id);
                        command.Parameters.AddWithValue("@Email_Name", entity.Email_Name);
                        command.Parameters.AddWithValue("@Email_Type", entity.Email_Type);

                        var Email_Name = command.ExecuteScalar();

                        return new ResultTrack()
                        {
                            Output = Email_Name
                        };
                    }
                }
            }
            catch (Exception ex)
            {
                var random = new Random();
                return new ResultTrack()
                {
                    ResultId = random.Next(90000),
                    Message = ex.Message,
                    Source = ex,
                    HasError = true,
                    HasSQLError = false,
                    Output = null
                };
            }
        }

        public ResultTrack Delete(Email entity)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlCommand command = connection.CreateCommand())
                    {
                        command.CommandText = "[dbo].[spDeleteEmail]";
                        command.CommandType = System.Data.CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@Email_Name", entity.Email_Name);

                        var email_Name = command.ExecuteScalar();

                        return new ResultTrack()
                        {
                            Output = email_Name
                        };
                    }
                }
            }
            catch (Exception ex)
            {
                var random = new Random();
                return new ResultTrack()
                {
                    ResultId = random.Next(90000),
                    Message = ex.Message,
                    Source = ex,
                    HasError = true,
                    HasSQLError = false,
                    Output = null
                };
            }
        }

        public IEnumerable<Email> GetAll()
        {
            var emails = new List<Email>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = "[dbo].[spGetAllEmail]";
                    command.CommandType = System.Data.CommandType.StoredProcedure;

                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            emails.Add(new Email()
                            {
                                Email_Name = GetValue(reader["Email_Name"]),
                                Student_Id = int.Parse(GetValue(reader["Student_Id"])),
                                Email_Type = int.Parse(GetValue(reader["Email_Type"])),
                                Create_On = DateTime.Parse(GetValue(reader["Create_On"])),
                                Update_On = DateTime.Parse(GetValue(reader["Update_On"]))
                            });
                        }
                    }
                }
            }

            return emails;
        }

        public Email GetBy(string email_Name)
        {
            var emails = new List<Email>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = "[dbo].[spGetByEmail]";
                    command.CommandType = System.Data.CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@Email_Name", email_Name);

                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            emails.Add(new Email()
                            {
                                Email_Name = GetValue(reader["Email_Name"]),
                                Student_Id = int.Parse(GetValue(reader["Student_Id"])),
                                Email_Type = int.Parse(GetValue(reader["Email_Type"])),
                                Create_On = DateTime.Parse(GetValue(reader["Create_On"])),
                                Update_On = DateTime.Parse(GetValue(reader["Update_On"]))
                            });
                        }
                    }
                }
            }

            return emails.FirstOrDefault();
        }

        public ResultTrack Update(Email entity)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlCommand command = connection.CreateCommand())
                    {
                        command.CommandText = "[dbo].[spUpdateEmail]";
                        command.CommandType = System.Data.CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@Email_Name", entity.Email_Name);
                        command.Parameters.AddWithValue("@Email_Type", entity.Email_Type);

                        var email_name = command.ExecuteScalar();

                        return new ResultTrack()
                        {
                            Output = email_name
                        };
                    }
                }
            }
            catch (Exception ex)
            {
                var random = new Random();
                return new ResultTrack()
                {
                    ResultId = random.Next(90000),
                    Message = ex.Message,
                    Source = ex,
                    HasError = true,
                    HasSQLError = false,
                    Output = null
                };
            }
        }

        private string GetValue(object field)
        {
            return field != null ? field.ToString() : string.Empty;
        }
    }
}
