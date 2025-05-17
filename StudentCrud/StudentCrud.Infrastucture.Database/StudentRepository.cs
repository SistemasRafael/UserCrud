using StudentCrud.Domain.Model.Common;
using StudentCrud.Domain.Model.DatabaseModels;
using StudentCrud.Domain.Model.Repositories;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace StudentCrud.Infrastucture.Database
{
    public class StudentRepository : IStudentRepository
    {
        private readonly string connectionString = "Server=192.168.1.7\\SQLEXPRESS;Integrated Security=false;Initial Catalog=CrudStudent;User ID=sa;Password=12baterista;";

        public ResultTrack Add(Student entity)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlCommand command = connection.CreateCommand())
                    {
                        command.CommandText = "[dbo].[spAddStudent]";
                        command.CommandType = System.Data.CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@Last_Name", entity.Last_Name);
                        command.Parameters.AddWithValue("@Middle_Name", entity.Middle_Name);
                        command.Parameters.AddWithValue("@First_Name", entity.First_Name);
                        command.Parameters.AddWithValue("@Gender", entity.Gender);

                        var student_Id = command.ExecuteScalar();

                        return new ResultTrack()
                        {
                            Output = student_Id
                        };
                    }
                }
            }
            catch (Exception ex) {
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

        public ResultTrack Delete(Student entity)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlCommand command = connection.CreateCommand())
                    {
                        command.CommandText = "[dbo].[spDeleteStudent]";
                        command.CommandType = System.Data.CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@Student_Id", entity.Student_Id);

                        var student_Id = command.ExecuteScalar();

                        return new ResultTrack()
                        {
                            Output = student_Id
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

        public IEnumerable<Student> GetAll()
        {
            var students = new List<Student>();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = "[dbo].[spGetAllStudent]";
                    command.CommandType = System.Data.CommandType.StoredProcedure;

                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            students.Add(new Student()
                            {
                                Student_Id = int.Parse(GetValue(reader["Student_Id"])),
                                Last_Name = GetValue(reader["Last_Name"]),
                                Middle_Name = GetValue(reader["Middle_Name"]),
                                First_Name = GetValue(reader["First_Name"]),
                                Gender = int.Parse(GetValue(reader["Gender"])),
                                Create_On = DateTime.Parse(GetValue(reader["Create_On"])),
                                Update_On = DateTime.Parse(GetValue(reader["Update_On"])),
                            });
                        }
                    }
                }
            }

            return students;
        }

        public Student GetBy(int student_Id)
        {
            var students = new List<Student>();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = "[dbo].[spGetByStudent]";
                    command.CommandType = System.Data.CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@Student_Id", student_Id);

                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            students.Add(new Student()
                            {
                                Student_Id = int.Parse(GetValue(reader["Student_Id"])),
                                Last_Name = GetValue(reader["Last_Name"]),
                                Middle_Name = GetValue(reader["Middle_Name"]),
                                First_Name = GetValue(reader["First_Name"]),
                                Gender = int.Parse(GetValue(reader["Gender"])),
                                Create_On = DateTime.Parse(GetValue(reader["Create_On"])),
                                Update_On = DateTime.Parse(GetValue(reader["Update_On"]))
                            });
                        }
                    }
                }
            }

            return students.FirstOrDefault();
        }

        public ResultTrack Update(Student entity)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlCommand command = connection.CreateCommand())
                    {
                        command.CommandText = "[dbo].[spUpdateStudent]";
                        command.CommandType = System.Data.CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@Student_Id", entity.Student_Id);
                        command.Parameters.AddWithValue("@Last_Name", entity.Last_Name);
                        command.Parameters.AddWithValue("@Middle_Name", entity.Middle_Name);
                        command.Parameters.AddWithValue("@First_Name", entity.First_Name);
                        command.Parameters.AddWithValue("@Gender", entity.Gender);

                        var student_Id = command.ExecuteScalar();

                        return new ResultTrack()
                        {
                            Output = student_Id
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
