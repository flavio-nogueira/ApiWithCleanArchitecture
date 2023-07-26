using ApiWithCleanArchitecture.Domain.Entities;

namespace ApiWithCleanArchitecture.Domain.Interfaces
{
    public interface IUsuarioRepository
    {
        Task<IEnumerable<Usuario>> SelecionarTodosAnync();
        Task<Usuario> SelecionarAsync(string login);
        Task<bool> ValidarLoginAsync(string login); 
        Task<bool> ValidarSenhaAsync(Usuario usuario);
        Task<Usuario> IncluirAsync(Usuario usuario);
        Task<Usuario> AlterarAsync(Usuario usuario);
        Task Excluir(string login); 

    }
}
