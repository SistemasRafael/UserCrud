using AutoMapper;
using StudentCrud.Domain.Dto;
using StudentCrud.Domain.Model.DatabaseModels;
using StudentCrud.Models;

namespace StudentCrud.Extensions
{
    public static class MapperExtensions
    {
        private static readonly IMapper _applicationMapper
         = new MapperConfiguration(cfg =>
         {
             cfg.CreateMap<StudentAddParameters, Student>();
             cfg.CreateMap<AddressAddParameters, Address>();
             cfg.CreateMap<EmailAddParameters, Email>();
             cfg.CreateMap<PhoneAddParameters, Phone>();

             cfg.CreateMap<Student, StudentDto>();
             cfg.CreateMap<Address, AddressDto>();
             cfg.CreateMap<Email, EmailDto>();
             cfg.CreateMap<Phone, PhoneDto>();

         }).CreateMapper();

        public static Student MapToModel(this StudentAddParameters studentAddParametres)
          => _applicationMapper.Map<Student>(studentAddParametres);

        public static Address MapToModel(this AddressAddParameters addressAddParameters)
          => _applicationMapper.Map<Address>(addressAddParameters);

        public static Email MapToModel(this EmailAddParameters emailAddParameters)
          => _applicationMapper.Map<Email>(emailAddParameters);

        public static Phone MapToModel(this PhoneAddParameters phoneAddParameters)
          => _applicationMapper.Map<Phone>(phoneAddParameters);

        public static StudentDto MapToDto(this Student student)
         => _applicationMapper.Map<StudentDto>(student);

        public static AddressDto MapToDto(this Address address)
          => _applicationMapper.Map<AddressDto>(address);

        public static EmailDto MapToDto(this Email email)
          => _applicationMapper.Map<EmailDto>(email);

        public static PhoneDto MapToDto(this Phone phone)
          => _applicationMapper.Map<PhoneDto>(phone);
    }
}