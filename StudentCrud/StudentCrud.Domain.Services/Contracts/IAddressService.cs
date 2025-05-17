using StudentCrud.Domain.Model.Common;
using StudentCrud.Domain.Model.DatabaseModels;
using System.Collections.Generic;

namespace StudentCrud.Domain.Services.Contracts
{
    public interface IAddressService
    {
        ResultTrack Add(Address entity);
        ResultTrack Update(Address entity);
        ResultTrack Delete(Address entity);
        IEnumerable<Address> GetAll();
        Address GetBy(int address_Id);
    }
}
