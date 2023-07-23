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

        public async Task<AlterarUsuarioView> Alterar(AlterarUsuarioView alterarusuario)  
        {
            var usuario = _mapper.Map<Usuario>(alterarusuario);
            var usuarioAlterado = await _UsuarioRepository.AlterarAsync(usuario);
            return _mapper.Map<AlterarUsuarioView>( usuarioAlterado);
        }

        public async Task Excluir(int id) => await _UsuarioRepository.Excluir(id);

        public async Task<NovoUsuarioView> Incluir(NovoUsuarioView novoUsuarioView) 
        {
            var Usuario = _mapper.Map<Usuario>(novoUsuarioView);
            var UsuarioIncluido = await _UsuarioRepository.IncluirAsync(Usuario);
            return _mapper.Map<NovoUsuarioView>(UsuarioIncluido);
        }

        public async Task<AlterarUsuarioView> SelecionarAsync(int id)
        {
            var Usuario = await _UsuarioRepository.SelecionarAsync(id);
            return _mapper.Map<AlterarUsuarioView>(Usuario);
        }

        public async Task<IEnumerable<AlterarUsuarioView>> SelecionarTodosAnync()
        {
            var Usuario = await _UsuarioRepository.SelecionarTodosAnync();
            return _mapper.Map<IEnumerable<AlterarUsuarioView>>(Usuario);
        }

       
    }
}
