using Microsoft.EntityFrameworkCore;
using Pede_RocaAPP.Domain.Entities;
using Pede_RocaAPP.Domain.Interfaces;
using Pede_RocaAPP.Infra.Data.Context;

namespace Pede_RocaAPP.Infra.Data.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private ApplicationDbContext _usuarioContext;

        public UsuarioRepository(ApplicationDbContext context)
        {
            _usuarioContext = context;
        }

        public async Task<Usuario> AdicionarAsync(Usuario usuario)
        {
            // Criptografar a senha do usuário antes de salvar
            usuario.Senha = BCrypt.Net.BCrypt.HashPassword(usuario.Senha);
            usuario.Status = true;

            // Atribuir a data e hora atual em UTC ao campo CreateUserDate
            usuario.CreateUserDate = DateTime.UtcNow;

            _usuarioContext.Add(usuario);
            await _usuarioContext.SaveChangesAsync();
            return usuario;
        }

        public async Task<Usuario> AtualizarAsync(Guid id, Usuario usuario)
        {
            var usuarioExistente = await _usuarioContext.Usuarios.FindAsync(id);

            if (usuarioExistente == null)
            {
                throw new Exception("Usu�rio n�o encontrado");
            }

            // Atualize os campos
            _usuarioContext.Entry(usuarioExistente).CurrentValues.SetValues(usuario);

            // Salve as mudan�as
            await _usuarioContext.SaveChangesAsync();

            return usuarioExistente;
        }

        public async Task<Usuario> AtualizarFotoPerfilAsync(Guid id, string uidFotoPerfil)
        {
            var usuarioExistente = await _usuarioContext.Usuarios.FindAsync(id);

            if (usuarioExistente == null)
            {
                throw new Exception("Usu�rio n�o encontrado");
            }

            usuarioExistente.UidFotoPerfil = uidFotoPerfil;

            _usuarioContext.Entry(usuarioExistente).State = EntityState.Modified;

            await _usuarioContext.SaveChangesAsync();

            return usuarioExistente;
        }

        public async Task<Usuario> DeleteAsync(Usuario usuario)
        {
            _usuarioContext.Remove(usuario);
            await _usuarioContext.SaveChangesAsync();
            return usuario;
        }

        public async Task<Usuario> GetByIdAsync(Guid id)
        {
            var usuario = await _usuarioContext.Usuarios.FindAsync(id);
            return usuario;
        }

        public async Task<Usuario> GetByEmailAsync(string Email)
        {
            var usuario = await _usuarioContext.Usuarios
                    .Where(u => u.Email.ToLower() == Email.ToLower())
                    .FirstOrDefaultAsync();
            return usuario;
        }

        public async Task<Usuario> GetByEmailESenhaAsync(string email, string senha)
        {
            var usuario = await _usuarioContext.Usuarios.FirstOrDefaultAsync(u => u.Email == email);

            if (usuario == null || !BCrypt.Net.BCrypt.Verify(senha, usuario.Senha))
            {
                return null;
            }

            return usuario;
        }

        public async Task<IEnumerable<Usuario>> GetAllAsync()
        {
            return await _usuarioContext.Usuarios.OrderBy(u => u.Nome).ToListAsync();
        }
    }
}