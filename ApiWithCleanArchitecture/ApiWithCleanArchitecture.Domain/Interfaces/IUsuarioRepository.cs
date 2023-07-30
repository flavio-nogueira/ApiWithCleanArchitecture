using ApiWithCleanArchitecture.Domain.Entities;

namespace ApiWithCleanArchitecture.Domain.Interfaces
{
    public interface IUsuarioRepository
    {
        Task<IEnumerable<Usuario>> ConsultatTodosUsuarioAnync();
        Task<Usuario> ConsultaUsuarioAnync(string login);
        Task<bool> ValidarLoginAsync(string login);
        Task<bool> ValidarSenhaAsync(Usuario usuario);
        Task<Usuario> IncluirAsync(Usuario usuario);
        Task<Usuario> AlterarAsync(Usuario usuario);
        Task<bool> ExisteUsuarioAsync(string login);
        Task Excluir(string login);

    }
}
