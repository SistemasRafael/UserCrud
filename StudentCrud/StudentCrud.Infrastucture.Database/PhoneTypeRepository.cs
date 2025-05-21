using StudentCrud.Domain.Model.DatabaseModels;
using StudentCrud.Domain.Model.Repositories;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace StudentCrud.Infrastucture.Database
{
    public class PhoneTypeRepository : IPhoneTypeRepository
    {
        private readonly string connectionString = "Server=192.168.1.7\\SQLEXPRESS;Integrated Security=false;Initial Catalog=CrudStudent;User ID=sa;Password=12baterista;";
        public IEnumerable<PhoneType> GetAll()
        {
            var phoneTypes = new List<PhoneType>();

            try 
            { 
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlCommand command = connection.CreateCommand())
                    {
                        command.CommandText = "[dbo].[spGetAllPhoneType]";
                        command.CommandType = System.Data.CommandType.StoredProcedure;

                        using (var reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                phoneTypes.Add(new PhoneType()
                                {
                                    Phone_Type_Id = int.Parse(GetValue(reader["Phone_Type_Id"])),
                                    Phone_Type = GetValue(reader["Phone_Type"])
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

            return phoneTypes;
        }

        public PhoneType GetBy(int phone_Type_Id)
        {
            var phoneTypes = new List<PhoneType>();

            try 
            { 
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlCommand command = connection.CreateCommand())
                    {
                        command.CommandText = "[dbo].[spGetByPhoneType]";
                        command.CommandType = System.Data.CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@Phone_Type_Id", phone_Type_Id);

                        using (var reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                phoneTypes.Add(new PhoneType()
                                {
                                    Phone_Type_Id = int.Parse(GetValue(reader["Phone_Type_Id"])),
                                    Phone_Type = GetValue(reader["Phone_Type"])
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

            return phoneTypes.FirstOrDefault();
        }

        private string GetValue(object field)
        {
            return field != null ? field.ToString() : string.Empty;
        }
    }
}
