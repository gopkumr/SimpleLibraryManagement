using AutoMapper;
using Inventory.Infra.DomainModel;
using Microsoft.AspNetCore.Routing.Constraints;

namespace Inventory.API.Model
{
    public class BookProfile : Profile
    {
        public BookProfile()
        {
            CreateMap<Book, BookModel>()
                .ForMember(q => q.CoverPageImpageName, opt => opt.MapFrom(GetCoverPageImageName))
                .ReverseMap()
                .ForMember(q => q.CoverPageUrl, opt => opt.MapFrom(src => $"http://localhost:8008:/Images/{src.CoverPageImpageName}"));

        }

        string GetCoverPageImageName(Book model, BookModel bookModel)
        {
            return (model.CoverPageUrl??" ").Split("//").LastOrDefault()??"";
        }
    }
}
