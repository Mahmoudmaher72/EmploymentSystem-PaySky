using AutoMapper;
using EmploymentSystem.Application.Commands.User;
using EmploymentSystem.Application.Commands.Vacancies;
using EmploymentSystem.Application.Commands.Vacancies.Apply;
using EmploymentSystem.Application.DTOs;
using EmploymentSystem.Domain.Entities;


namespace EmploymentSystem.Application.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<User, UserDto>()
                .ForMember(dest => dest.RoleName, opt => opt.MapFrom(src => src.Role.Name));
            CreateMap<Vacancy, VacancyDto>();

            CreateMap<Domain.Entities.Application, ApplicationDto>();
            CreateMap<User, ApplicantDto>();

            CreateMap<RegisterUserCommand, User>()
                .ForMember(dest => dest.PasswordHash, opt => opt.MapFrom(src => BCrypt.Net.BCrypt.HashPassword(src.Password)));

            CreateMap<CreateVacancyCommand, Vacancy>();

            CreateMap<ApplyForVacancyCommand, Domain.Entities.Application>();
        }
    }
}
