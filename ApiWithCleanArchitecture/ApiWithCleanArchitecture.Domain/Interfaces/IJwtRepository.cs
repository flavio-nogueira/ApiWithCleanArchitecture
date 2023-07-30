using ApiWithCleanArchitecture.Domain.Entities;

namespace ApiWithCleanArchitecture.Domain.Interfaces
{
    public interface IJwtRepository
    {
        Task<TokenUsuario> GerarToken(Usuario usuario);
    }
}
