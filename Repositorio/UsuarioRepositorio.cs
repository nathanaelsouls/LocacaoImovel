using APILocacaoImovel.Data;
using APILocacaoImovel.Models;
using APILocacaoImovel.Repositorio.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace APILocacaoImovel.Repositorio
{
    public class UsuarioRepositorio : IUsuarioRepositorio
    {
        private readonly Contexto _dbContext;
        public UsuarioRepositorio(Contexto locacaoImovelDBContext)
        {
            _dbContext = locacaoImovelDBContext;
        }

        public async Task<UsuarioModel> BuscarPorIdAsync(int id)
        {
            return await _dbContext.Usuarios.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<UsuarioModel>> BuscarTodosUsuariosAsync()
        {
            return await _dbContext.Usuarios.ToListAsync();
        }

        public async Task<UsuarioModel> AdicionarAsync(UsuarioModel usuario)
        {
            await _dbContext.Usuarios.AddAsync(usuario);
            await _dbContext.SaveChangesAsync();

            return usuario;
        }

        public async Task<UsuarioModel> AtualizarAsync(UsuarioModel usuario, int id)
        {
            UsuarioModel usuarioPorid = await BuscarPorIdAsync(id);

            if (usuarioPorid == null)
            {
                throw new Exception($"Usuário para o ID: {id} não foi encontrado no banco de dados.");
            }

            usuarioPorid.Id = id;
            usuarioPorid.Nome = usuario.Nome;
            usuarioPorid.Email = usuario.Email;
            usuarioPorid.Telefone = usuario.Telefone;

            _dbContext.Usuarios.Update(usuarioPorid);
            await _dbContext.SaveChangesAsync();

            return usuarioPorid;
        }

        public async Task<bool> ApagarAsync(int id)
        {
            UsuarioModel usuarioPorid = await BuscarPorIdAsync(id);

            if (usuarioPorid == null)
            {
                throw new Exception($"Usuário para o ID: {id} não foi encontrado no banco de dados.");
            }

            _dbContext.Usuarios.Remove(usuarioPorid);
            await _dbContext.SaveChangesAsync();

            return true;
        }

    }
}
