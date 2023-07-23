using ApiWithCleanArchitecture.Domain.Entities;

namespace ApiWithCleanArchitecture.Domain.Interfaces
{
    public interface IUsuarioRepository
    {
        Task<IEnumerable<Usuario>> SelecionarTodosAnync();
        Task<Usuario> SelecionarAsync(int id);
        Task<Usuario> LoginAsync(string login);
        Task<Usuario> IncluirAsync(Usuario usuario);
        Task<Usuario> AlterarAsync(Usuario usuario);
        Task Excluir(int id);

    }
}
