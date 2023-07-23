using ApiWithCleanArchitecture.Domain.Entities;
using ApiWithCleanArchitecture.Domain.Interfaces;
using ApiWithCleanArchitecture.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace ApiWithCleanArchitecture.Infra.Data.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly ApplicationDbContext _context;

        public UsuarioRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Usuario> AlterarAsync(Usuario usuario)
        {
            var UsuarioConsultado = await _context.Usuarios.FindAsync(usuario.Id);

            if (UsuarioConsultado == null)
            {
                return null;
            }

            _context.Entry(UsuarioConsultado).CurrentValues.SetValues(usuario);

            await _context.SaveChangesAsync();

            return UsuarioConsultado;
        }

        public async Task Excluir(int id)
        {
            var UsuarioExcluido = await _context.Usuarios.FindAsync(id);
            _context.Usuarios.Remove(UsuarioExcluido);
            await _context.SaveChangesAsync();
        } 

        public async Task<Usuario> IncluirAsync(Usuario usuario)
        {
            _context.Usuarios.AddAsync(usuario);
            await _context.SaveChangesAsync();
            return usuario;
        }

        public async Task<Usuario> LoginAsync(string login)
        {
            return await _context.Usuarios
                .AsNoTracking()
                .SingleOrDefaultAsync(p => p.Login == login);
        }

        public async Task<Usuario> LoginSenhaAsync(string login, string senha)
        {
            return await _context.Usuarios
                .AsNoTracking()
                .SingleOrDefaultAsync(p => p.Login == login && p.Senha == senha);
        }

        public async Task<Usuario> SelecionarAsync(int id)
        {
            return await _context.Usuarios.FindAsync(id);
        }

        public async Task<IEnumerable<Usuario>> SelecionarTodosAnync()
        {
            return await _context.Usuarios.AsNoTracking().ToListAsync();
        }
    }
}