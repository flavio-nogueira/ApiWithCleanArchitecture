using ApiWithCleanArchitecture.Application.Interfaces;
using ApiWithCleanArchitecture.Application.ModelViews.Usuario;
using ApiWithCleanArchitecture.Domain.Entities;
using ApiWithCleanArchitecture.Domain.Interfaces;
using AutoMapper;

namespace ApiWithCleanArchitecture.Application.Services
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IUsuarioRepository _UsuarioRepository;
        private readonly IMapper _mapper;

        public UsuarioService(IUsuarioRepository UsuarioRepository, IMapper mapper)
        {
            _UsuarioRepository = UsuarioRepository;
            _mapper = mapper;
        }

        public async Task<AlterarUsuarioView> Alterar(AlterarUsuarioView alterarUsuario)
        {
            var usuario = _mapper.Map<Usuario>(alterarUsuario);
            var usuarioAlterado = await _UsuarioRepository.AlterarAsync(usuario);
            return _mapper.Map<AlterarUsuarioView>(usuarioAlterado);
        }

        public async Task Excluir(string login) => await _UsuarioRepository.Excluir(login);

        public async Task<NovoUsuarioView> Incluir(NovoUsuarioView incluirUsuario)
        {
            var usuario = _mapper.Map<Usuario>(incluirUsuario);
            var UsuarioIncluido = await _UsuarioRepository.IncluirAsync(usuario);
            return _mapper.Map<NovoUsuarioView>(UsuarioIncluido);
        }

        public async Task<UsuarioLogadoView> LoginAsync(string login, string senha)
        {
            var usuarioLogadoView = new UsuarioLogadoView();

            if (await _UsuarioRepository.ValidarLoginAsync(login)==false)
            {
                usuarioLogadoView.Logado = false;
                usuarioLogadoView.Aviso = "Usuario nao encontrato";
                return usuarioLogadoView;
            }
            else
            {
                var usuario = new Usuario();
                usuario.Login = login;  
                usuario.Senha = senha;
                await _UsuarioRepository.ValidarSenhaAsync(usuario);
                usuarioLogadoView.Logado = false;
                usuarioLogadoView.Aviso = "Senha nao confere !";
                return usuarioLogadoView;

            }
        }

        public async Task<AlterarUsuarioView> SelecionarAsync(string login)
        {
            var Usuario = await _UsuarioRepository.SelecionarAsync(login);
            return _mapper.Map<AlterarUsuarioView>(Usuario);
        }

        public async Task<IEnumerable<AlterarUsuarioView>> SelecionarTodosAnync()
        {
            var Usuario = await _UsuarioRepository.SelecionarTodosAnync();
            return _mapper.Map<IEnumerable<AlterarUsuarioView>>(Usuario);
        }
    }
}
