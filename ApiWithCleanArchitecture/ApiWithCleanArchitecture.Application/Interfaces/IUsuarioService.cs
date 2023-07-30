using ApiWithCleanArchitecture.Application.ModelViews.Usuario;

namespace ApiWithCleanArchitecture.Application.Interfaces
{
    public interface IUsuarioService
    {
        Task<NovoUsuarioView> Incluir(NovoUsuarioView incluirUsuario);
        Task<AlterarUsuarioView> Alterar(AlterarUsuarioView alterarUsuario);
        Task Excluir(string login);
        Task<UsuarioView> ConsultarUsuarioAsync(string login);
        Task<UsuarioLogadoView> LoginAsync(LoginUsuarioView loginUsuario);
        Task<IEnumerable<UsuarioView>> ConsultarTodosUsuariosTodosAnync();
    }
}
