using AutoMapper;
using AM.Amil.PeNaAreia.Domain.Entities;
using AM.Amil.PeNaAreia.Domain.Dto;

namespace AM.Amil.PeNaAreia.Data.Mapping
{
    public class MappingProfile: Profile
    {
        public MappingProfile()
        {
            //DB to DTO

            CreateMap<CadastroUsuarioDto, Usuario>()
                .ForPath(dest => dest.Cpf, opts => opts.MapFrom(src => src.Cpf))
                .ForPath(dest => dest.Nome, opts => opts.MapFrom(src => src.Nome))
                .ForPath(dest => dest.Email, opts => opts.MapFrom(src => src.Email))
                .ForPath(dest => dest.Senha, opts => opts.MapFrom(src => src.Senha))
                .ReverseMap();

            CreateMap<CadastroProjetoDto, Projeto>()
                .ForPath(dest => dest.Nome, opts => opts.MapFrom(src => src.Nome))
                .ForPath(dest => dest.Estado, opts => opts.MapFrom(src => src.Estado))
                .ForPath(dest => dest.Cidade, opts => opts.MapFrom(src => src.Cidade))
                .ReverseMap();
        }
    }
}
