using StudentCrud.Domain.Model.Common;
using StudentCrud.Domain.Model.DatabaseModels;
using StudentCrud.Domain.Model.Repositories;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;

namespace StudentCrud.Infrastucture.Database
{
    public class PhoneRepository : IPhoneRepository
    {
        private readonly string connectionString = ConfigurationManager.ConnectionStrings["localDB"].ConnectionString;

        public ResultTrack Add(Phone entity)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlCommand command = connection.CreateCommand())
                    {
                        command.CommandText = "[dbo].[spAddPhone]";
                        command.CommandType = System.Data.CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@Student_Id", entity.Student_Id);
                        command.Parameters.AddWithValue("@Phone_Number", entity.Phone_Number);
                        command.Parameters.AddWithValue("@Phone_Type", entity.Phone_Type);
                        command.Parameters.AddWithValue("@Country_Code", entity.Country_Code);
                        command.Parameters.AddWithValue("@Area_Code", entity.Area_Code);

                        var phone_Id = command.ExecuteScalar();

                        return new ResultTrack()
                        {
                            Output = phone_Id
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

        public ResultTrack Delete(Phone entity)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlCommand command = connection.CreateCommand())
                    {
                        command.CommandText = "[dbo].[spDeletePhone]";
                        command.CommandType = System.Data.CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@Phone_Id", entity.Phone_Id);

                        var phone_id = command.ExecuteScalar();

                        return new ResultTrack()
                        {
                            Output = phone_id
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

        public IEnumerable<Phone> GetAll()
        {
            var phones = new List<Phone>();

            try 
            { 
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlCommand command = connection.CreateCommand())
                    {
                        command.CommandText = "[dbo].[spGetAllPhone]";
                        command.CommandType = System.Data.CommandType.StoredProcedure;

                        using (var reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                phones.Add(new Phone()
                                {
                                    Phone_Id = int.Parse(GetValue(reader["Phone_Id"])),
                                    Student_Id = int.Parse(GetValue(reader["Student_Id"])),
                                    Phone_Number = GetValue(reader["Phone_Number"]),
                                    Phone_Type = int.Parse(GetValue(reader["Phone_Type"])),
                                    Country_Code = GetValue(reader["Country_Code"]),
                                    Area_Code = GetValue(reader["Area_Code"]),
                                    Create_On = DateTime.Parse(GetValue(reader["Create_On"])),
                                    Update_On = DateTime.Parse(GetValue(reader["Update_On"]))
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

            return phones;
        }

        public Phone GetBy(int phone_id)
        {
            var phones = new List<Phone>();
            try 
            { 
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlCommand command = connection.CreateCommand())
                    {
                        command.CommandText = "[dbo].[spGetByPhone]";
                        command.CommandType = System.Data.CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@Phone_Id", phone_id);

                        using (var reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                phones.Add(new Phone()
                                {
                                    Phone_Id = int.Parse(GetValue(reader["Phone_Id"])),
                                    Student_Id = int.Parse(GetValue(reader["Student_Id"])),
                                    Phone_Number = GetValue(reader["Phone_Number"]),
                                    Phone_Type = int.Parse(GetValue(reader["Phone_Type"])),
                                    Country_Code = GetValue(reader["Country_Code"]),
                                    Area_Code = GetValue(reader["Area_Code"]),
                                    Create_On = DateTime.Parse(GetValue(reader["Create_On"])),
                                    Update_On = DateTime.Parse(GetValue(reader["Update_On"]))
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

            return phones.FirstOrDefault();
        }

        public Phone GetByStudentId(int student_Id)
        {
            var phones = new List<Phone>();

            try 
            { 
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlCommand command = connection.CreateCommand())
                    {
                        command.CommandText = "[dbo].[spGetPhoneByStudent_Id]";
                        command.CommandType = System.Data.CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@Student_Id", student_Id);

                        using (var reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                phones.Add(new Phone()
                                {
                                    Phone_Id = int.Parse(GetValue(reader["Phone_Id"])),
                                    Student_Id = int.Parse(GetValue(reader["Student_Id"])),
                                    Phone_Number = GetValue(reader["Phone_Number"]),
                                    Phone_Type = int.Parse(GetValue(reader["Phone_Type"])),
                                    Country_Code = GetValue(reader["Country_Code"]),
                                    Area_Code = GetValue(reader["Area_Code"]),
                                    Create_On = DateTime.Parse(GetValue(reader["Create_On"])),
                                    Update_On = DateTime.Parse(GetValue(reader["Update_On"]))
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

            return phones.FirstOrDefault();
        }

        public ResultTrack Update(Phone entity)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlCommand command = connection.CreateCommand())
                    {
                        command.CommandText = "[dbo].[spUpdatePhone]";
                        command.CommandType = System.Data.CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@Phone_Id", entity.Phone_Id);
                        command.Parameters.AddWithValue("@Phone_Number", entity.Phone_Number);
                        command.Parameters.AddWithValue("@Phone_Type", entity.Phone_Type);
                        command.Parameters.AddWithValue("@Country_Code", entity.Country_Code);
                        command.Parameters.AddWithValue("@Area_Code", entity.Area_Code);

                        var phone_Id = command.ExecuteScalar();

                        return new ResultTrack()
                        {
                            Output = phone_Id
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
