using StudentCrud.Domain.Model.DatabaseModels;
using System.Collections.Generic;

namespace StudentCrud.Domain.Services.Contracts
{
    public interface IGenderTypeService
    {
        IEnumerable<GenderType> GetAll();
        GenderType GetBy(int gender_Type_Id);
    }
}
