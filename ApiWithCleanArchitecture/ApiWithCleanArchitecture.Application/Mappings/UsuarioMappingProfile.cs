using ApiWithCleanArchitecture.Application.ModelViews.Usuario;
using ApiWithCleanArchitecture.Domain.Entities;
using AutoMapper;

namespace ApiWithCleanArchitecture.Application.Mappings
{
    public class UsuarioMappingProfile : Profile
    {
        public UsuarioMappingProfile()
        {
            #region NovoUsuarioView para Usuario
            CreateMap<NovoUsuarioView, Usuario>()
                .ForMember(d => d.Id, o => o.MapFrom(x => Guid.NewGuid()))
                .ForMember(d => d.DataCriacao, o => o.MapFrom(x => DateTime.Now))
                .ForMember(d => d.DataAlteracao, o => o.MapFrom(x => DateTime.Now));
            #endregion

            #region Usuario para NovoUsuarioView
            CreateMap<Usuario, NovoUsuarioView>();
            #endregion

            #region AlterarUsuarioView para Usuario
            CreateMap<AlterarUsuarioView, Usuario>()
                .ForMember(d => d.DataAlteracao, o => o.MapFrom(x => DateTime.Now));
            #endregion

            #region Usuario para AlterarUsuarioView
            CreateMap<Usuario, AlterarUsuarioView>();
            #endregion

            #region Usuario para UsuarioView
            CreateMap<Usuario, UsuarioView>();
            #endregion

            #region TokenUsuario para TokenView
            CreateMap<TokenUsuario, TokenView>();
            #endregion


        }
    }
}
