using ApiWithCleanArchitecture.Application.ModelViews.Usuario;
using ApiWithCleanArchitecture.Domain.Entities;
using ApiWithCleanArchitecture.Domain.Interfaces;
using ApiWithCleanArchitecture.Infra.Data.Context;
using Microsoft.AspNet.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using PasswordVerificationResult = Microsoft.AspNetCore.Identity.PasswordVerificationResult;

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

            ConverteSenhaEmHash(usuario);

            _context.Entry(UsuarioConsultado).CurrentValues.SetValues(usuario);

            await _context.SaveChangesAsync();

            return UsuarioConsultado;
        }

        public async Task<Usuario> IncluirAsync(Usuario usuario)
        {
            var passwordHasher = new PasswordHasher<Usuario>();
            usuario.Senha = passwordHasher.HashPassword(usuario, usuario.Senha);
            _context.Usuarios.AddAsync(usuario);
            await _context.SaveChangesAsync();
            return usuario;
        }

        public async Task<bool> ValidarLoginAsync(string login)  
        {
            var UsuarioConsultado = await _context.Usuarios.FindAsync(login);

            if (UsuarioConsultado == null)
            {
                return false;
            }
            return true;
        }

        public async Task<bool> ValidarSenhaAsync(Usuario usuario)  
        {
            var passwordHasher = new PasswordHasher<Usuario>();
            var usuarioConsultado = await SelecionarAsync(usuario.Login);

            ConverteSenhaEmHash(usuario);
            var status = passwordHasher.VerifyHashedPassword(usuario, usuarioConsultado.Senha, usuario.Senha);

            switch (status)
            {
                case PasswordVerificationResult.Failed:
                    return false;
                case PasswordVerificationResult.Success:
                    return true;
                case PasswordVerificationResult.SuccessRehashNeeded:
                    await AlterarAsync(usuario);
                    return true;
                default:
                    throw new InvalidOperationException();
            }

        }

        public async Task<Usuario> SelecionarAsync(string login)
        {
            return await _context.Usuarios.FindAsync(login);
        }

        public async Task<IEnumerable<Usuario>> SelecionarTodosAnync()
        {
            return await _context.Usuarios.AsNoTracking().ToListAsync();
        }

        private void ConverteSenhaEmHash(Usuario usuario)
        {
            var passwordHasher = new PasswordHasher<Usuario>();
            usuario.Senha = passwordHasher.HashPassword(usuario, usuario.Senha);
        }


        public async Task Excluir(string login)
        {
            var UsuarioExcluido = await _context.Usuarios.FindAsync(login);
            _context.Usuarios.Remove(UsuarioExcluido);
            await _context.SaveChangesAsync();
        }

        
    }
}