using StudentCrud.Domain.Model.DatabaseModels;
using System.Collections.Generic;

namespace StudentCrud.Domain.Services.Contracts
{
    public interface IPhoneTypeService
    {
        IEnumerable<PhoneType> GetAll();
        PhoneType GetBy(int phone_Type_Id);
    }
}
