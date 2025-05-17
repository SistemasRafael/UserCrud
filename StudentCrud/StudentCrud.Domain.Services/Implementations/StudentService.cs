using StudentCrud.Domain.Model.Common;
using StudentCrud.Domain.Model.DatabaseModels;
using StudentCrud.Domain.Model.Repositories;
using StudentCrud.Domain.Services.Contracts;
using StudentCrud.Infrastucture.Database;
using System.Collections.Generic;

namespace StudentCrud.Domain.Services.Implementations
{
    public class StudentService : IStudentService
    {
        IStudentRepository studentRepository = new StudentRepository();

        public ResultTrack Add(Student entity)
        {
            return studentRepository.Add(entity);
        }

        public ResultTrack Delete(Student entity)
        {
            return studentRepository.Delete(entity);
        }

        public IEnumerable<Student> GetAll()
        {
            return studentRepository.GetAll();
        }

        public Student GetBy(int student_Id)
        {
            return studentRepository.GetBy(student_Id);
        }

        public ResultTrack Update(Student entity)
        {
            return studentRepository.Update(entity);
        }
    }
}
