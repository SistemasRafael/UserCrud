using StudentCrud.Domain.Model.Common;
using StudentCrud.Domain.Model.DatabaseModels;
using StudentCrud.Domain.Model.Repositories;
using StudentCrud.Domain.Services.Contracts;
using StudentCrud.Infrastucture.Database;
using System.Collections.Generic;

namespace StudentCrud.Domain.Services.Implementations
{
    public class AddressService : IAddressService
    {
        private readonly IAddressRepository addressRepository = new AddressRepository();

        public ResultTrack Add(Address entity)
        {
            return addressRepository.Add(entity);
        }

        public ResultTrack Delete(Address entity)
        {
            return addressRepository.Delete(entity);
        }

        public IEnumerable<Address> GetAll()
        {
            return addressRepository.GetAll();
        }

        public Address GetBy(int address_Id)
        {
            return addressRepository.GetBy(address_Id);
        }

        public Address GetByStudentId(int student_Id)
        {
            return addressRepository.GetByStudentId(student_Id);
        }

        public ResultTrack Update(Address entity)
        {
            return addressRepository.Update(entity);
        }
    }
}
