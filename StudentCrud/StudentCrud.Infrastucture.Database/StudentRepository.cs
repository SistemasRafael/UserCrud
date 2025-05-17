using StudentCrud.Domain.Model.Common;
using StudentCrud.Domain.Model.DatabaseModels;
using StudentCrud.Domain.Model.Repositories;
using System.Collections.Generic;

namespace StudentCrud.Infrastucture.Database
{
    public class StudentRepository : IStudentRepository
    {
        public ResultTrack Add(Student parameters)
        {
            throw new System.NotImplementedException();
        }

        public ResultTrack Delete(Student parameters)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<Student> GetAll()
        {
            throw new System.NotImplementedException();
        }

        public Student GetBy(int parameters)
        {
            throw new System.NotImplementedException();
        }

        public ResultTrack Update(Student parameters)
        {
            throw new System.NotImplementedException();
        }
    }
}
