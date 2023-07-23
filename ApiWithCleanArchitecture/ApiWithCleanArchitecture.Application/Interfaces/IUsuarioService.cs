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
        Task<NovoUsuarioView> Incluir(NovoUsuarioView ContasPagarDTO);
        Task<AlterarUsuarioView> Alterar(AlterarUsuarioView ContasPagarDTO);
        Task Excluir(int id);
        Task<AlterarUsuarioView> SelecionarAsync(int id);
        Task<IEnumerable<AlterarUsuarioView>> SelecionarTodosAnync();
    }
}
