using StudentCrud.Domain.Model.Common;
using StudentCrud.Domain.Model.DatabaseModels;
using System.Collections.Generic;

namespace StudentCrud.Domain.Services.Contracts
{
    public interface IPhoneService
    {
        ResultTrack Add(Phone entity);
        ResultTrack Update(Phone entity);
        ResultTrack Delete(Phone entity);
        IEnumerable<Phone> GetAll();
        Phone GetBy(int phonr_Id);
        Phone GetByStudentId(int student_Id);
    }
}
