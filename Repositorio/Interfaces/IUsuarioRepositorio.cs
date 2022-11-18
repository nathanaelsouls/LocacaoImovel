using APILocacaoImovel.Models;

namespace APILocacaoImovel.Repositorio.Interfaces
{
    public interface IUsuarioRepositorio
    {
        Task<List<UsuarioModel>> BuscarTodosUsuariosAsync();
        Task<UsuarioModel> BuscarPorIdAsync(int id);
        Task<UsuarioModel> AdicionarAsync(UsuarioModel usuario);
        Task<UsuarioModel> AtualizarAsync(UsuarioModel usuario, int id);
        Task<bool> ApagarAsync(int id);
    }
}
