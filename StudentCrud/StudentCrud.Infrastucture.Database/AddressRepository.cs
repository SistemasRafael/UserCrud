using StudentCrud.Domain.Model.Common;
using StudentCrud.Domain.Model.DatabaseModels;
using StudentCrud.Domain.Model.Repositories;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace StudentCrud.Infrastucture.Database
{
    public class AddressRepository : IAddressRepository
    {
        private readonly string connectionString = "Server=192.168.1.7\\SQLEXPRESS;Integrated Security=false;Initial Catalog=CrudStudent;User ID=sa;Password=12baterista;";

        public ResultTrack Add(Address entity)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlCommand command = connection.CreateCommand())
                    {
                        command.CommandText = "[dbo].[spAddAddress]";
                        command.CommandType = System.Data.CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@Student_Id", entity.Student_Id);
                        command.Parameters.AddWithValue("@Address_Line", entity.Address_Line);
                        command.Parameters.AddWithValue("@City", entity.City);
                        command.Parameters.AddWithValue("@Zip_Codepost", entity.Zip_Codepost);
                        command.Parameters.AddWithValue("@State", entity.State);

                        var Address_Id = command.ExecuteScalar();

                        return new ResultTrack()
                        {
                            Output = Address_Id
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

        public ResultTrack Delete(Address entity)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlCommand command = connection.CreateCommand())
                    {
                        command.CommandText = "[dbo].[spDeleteAddress]";
                        command.CommandType = System.Data.CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@Address_Id", entity.Address_Id);

                        var address = command.ExecuteScalar();

                        return new ResultTrack()
                        {
                            Output = address
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

        public IEnumerable<Address> GetAll()
        {
            var addresses = new List<Address>();

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlCommand command = connection.CreateCommand())
                    {
                        command.CommandText = "[dbo].[spGetAllAddress]";
                        command.CommandType = System.Data.CommandType.StoredProcedure;

                        using (var reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                addresses.Add(new Address()
                                {
                                    Address_Id = int.Parse(GetValue(reader["Address_Id"])),
                                    Student_Id = int.Parse(GetValue(reader["Student_Id"])),
                                    Address_Line = GetValue(reader["Address_Line"]),
                                    City = GetValue(reader["City"]),
                                    Zip_Codepost = GetValue(reader["Zip_Codepost"]),
                                    State = GetValue(reader["State"])
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

            return addresses;
        }

        public Address GetBy(int address_id)
        {
            var addresses = new List<Address>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = "[dbo].[spGetByAddress]";
                    command.CommandType = System.Data.CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@Address_Id", address_id);

                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            addresses.Add(new Address()
                            {
                                Address_Id = int.Parse(GetValue(reader["Address_Id"])),
                                Student_Id = int.Parse(GetValue(reader["Student_Id"])),
                                Address_Line = GetValue(reader["Address_Line"]),
                                City = GetValue(reader["City"]),
                                Zip_Codepost = GetValue(reader["Zip_Codepost"]),
                                State = GetValue(reader["State"])
                            });
                        }
                    }
                }
            }

            return addresses.FirstOrDefault();
        }

        public Address GetByStudentId(int student_Id)
        {
            var addresses = new List<Address>();

            try { 
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlCommand command = connection.CreateCommand())
                    {
                        command.CommandText = "[dbo].[spGetAddressByStudentId]";
                        command.CommandType = System.Data.CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@Student_Id", student_Id);

                        using (var reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                addresses.Add(new Address()
                                {
                                    Address_Id = int.Parse(GetValue(reader["Address_Id"])),
                                    Student_Id = int.Parse(GetValue(reader["Student_Id"])),
                                    Address_Line = GetValue(reader["Address_Line"]),
                                    City = GetValue(reader["City"]),
                                    Zip_Codepost = GetValue(reader["Zip_Codepost"]),
                                    State = GetValue(reader["State"])
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

            return addresses.FirstOrDefault();
        }

        public ResultTrack Update(Address entity)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlCommand command = connection.CreateCommand())
                    {
                        command.CommandText = "[dbo].[spUpdateAddress]";
                        command.CommandType = System.Data.CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@Address_Id", entity.Address_Id);
                        command.Parameters.AddWithValue("@Address_Line", entity.Address_Line);
                        command.Parameters.AddWithValue("@City", entity.City);
                        command.Parameters.AddWithValue("@Zip_Codepost", entity.Zip_Codepost);
                        command.Parameters.AddWithValue("@State", entity.State);

                        var address_Id = command.ExecuteScalar();

                        return new ResultTrack()
                        {
                            Output = address_Id
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
