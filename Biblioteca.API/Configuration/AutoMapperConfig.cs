using AutoMapper;
using Biblioteca.API.ViewModels;
using Biblioteca.Business.Models;

namespace Biblioteca.API.Configuration
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {
            CreateMap<Editora, EditoraViewModel>().ReverseMap();
            CreateMap<Endereco, EnderecoViewModel>().ReverseMap();
            CreateMap<LivroViewModel, Livro>();
            CreateMap<Autor, AutorViewModel>().ReverseMap();
            CreateMap<Livro, LivroViewModel>()
                .ForMember(destinationMember: dest => dest.NomeEditora, memberOptions: opt => opt.MapFrom(mapExpression: src => src.Editora.Nome))
                .ForMember(destinationMember: dest => dest.NomeAutor, memberOptions: opt => opt.MapFrom(mapExpression: src => src.Autor.Nome));

        }
    }
}
