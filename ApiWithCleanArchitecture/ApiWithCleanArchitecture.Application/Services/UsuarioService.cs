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
        public readonly IJwtRepository _JwtRepository;

        public UsuarioService(IUsuarioRepository UsuarioRepository, IMapper mapper, IJwtRepository JwtRepository)
        {
            _UsuarioRepository = UsuarioRepository;
            _mapper = mapper;
            _JwtRepository = JwtRepository;
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

        public async Task<UsuarioLogadoView> LoginAsync(LoginUsuarioView loginUsuario) 
        {
            var usuarioLogadoView = new UsuarioLogadoView();

            if (await _UsuarioRepository.ValidarLoginAsync(loginUsuario.Email) == false)
            {
                return null;
            }
            else
            {
                var usuario = new Usuario();
                usuario.LoginEmail = loginUsuario.Email;
                usuario.Senha = loginUsuario.Senha;
                if (await _UsuarioRepository.ValidarSenhaAsync(usuario) == false)
                {           
                    return usuarioLogadoView;
                }
                else
                {
                    var usuarioConsulta = await _UsuarioRepository.ConsultaUsuarioAnync(loginUsuario.Email);
                    var _token = await _JwtRepository.GerarToken(usuarioConsulta);
                    usuarioLogadoView.Token = _token.Token;
                    usuarioLogadoView.ValidadeLogin = _token.DataValidade;
                    usuarioLogadoView.Email = usuarioConsulta.LoginEmail;
                    usuarioLogadoView.Nome = usuarioConsulta.Nome;
                    usuarioLogadoView.DataHoraLogin = DateTime.Now;
                    return usuarioLogadoView;
                }

            }
        }

        public async Task<UsuarioView> ConsultarUsuarioAsync(string login)
        {
            var Usuario = await _UsuarioRepository.ConsultaUsuarioAnync(login);
            return _mapper.Map<UsuarioView>(Usuario);
        }

        public async Task<IEnumerable<UsuarioView>> ConsultarTodosUsuariosTodosAnync()
        {
            var Usuario = await _UsuarioRepository.ConsultatTodosUsuarioAnync();
            return _mapper.Map<IEnumerable<UsuarioView>>(Usuario);
        }
    }
}
