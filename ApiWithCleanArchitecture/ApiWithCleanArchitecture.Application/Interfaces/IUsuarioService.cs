using ApiWithCleanArchitecture.Application.ModelViews.Usuario;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiWithCleanArchitecture.Application.Interfaces
{
    public interface IUsuarioService
    {
        Task<NovoUsuarioView> Incluir(NovoUsuarioView incluirUsuario);
        Task<AlterarUsuarioView> Alterar(AlterarUsuarioView alterarUsuario); 
        Task Excluir(string login);
        Task<AlterarUsuarioView> SelecionarAsync(string login);
        Task<UsuarioLogadoView> LoginAsync(string login, string senha); 
        Task<IEnumerable<AlterarUsuarioView>> SelecionarTodosAnync();
    }
}
