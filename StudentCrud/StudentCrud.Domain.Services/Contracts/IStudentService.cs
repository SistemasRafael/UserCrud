using StudentCrud.Domain.Model.Common;
using StudentCrud.Domain.Model.DatabaseModels;
using System.Collections.Generic;

namespace StudentCrud.Domain.Services.Contracts
{
    public interface IStudentService
    {
        ResultTrack Add(Student entity);
        ResultTrack Update(Student entity);
        ResultTrack Delete(Student entity);
        IEnumerable<Student> GetAll();
        Student GetBy(int student_Id);
    }
}
