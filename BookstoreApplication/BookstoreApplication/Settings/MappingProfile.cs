using AutoMapper;
using BookstoreApplication.DTOs;
using BookstoreApplication.Models;

namespace BookstoreApplication.Settings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Book, BookDto>()
                .ForMember(dest => dest.Age, opt => opt.MapFrom(src => DateTime.Now.Year - src.PublishedDate.Year))
                .ForMember(dest => dest.AuthorFullName, opt => opt.MapFrom(src => src.Author.FullName))
                .ForMember(dest => dest.PublisherName, opt => opt.MapFrom(src => src.Publisher.Name))
                .ReverseMap();

            CreateMap<Book, BookDetailsDto>()
                .ForMember(dest => dest.AuthorFullName, opt => opt.MapFrom(src => src.Author.FullName))
                .ForMember(dest => dest.PublisherName, opt => opt.MapFrom(src => src.Publisher.Name))
                .ReverseMap();

            CreateMap<Author, AuthorDTO>().ReverseMap();

            CreateMap<RegistrationDto, ApplicationUser>();
            CreateMap<ApplicationUser, ProfileDto>();

            CreateMap<SaveIssueDto, Issue>();
        }
    }
}