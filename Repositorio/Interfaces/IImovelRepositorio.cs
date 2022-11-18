using APILocacaoImovel.Models;

namespace APILocacaoImovel.Repositorio.Interfaces
{
    public interface IImovelRepositorio
    {
        Task<List<ImovelModel>> BuscarTodosImoveisAsync();
        Task<ImovelModel> BuscarPorIdAsync(int id);
        Task<ImovelModel> AdicionarAsync(ImovelModel locacao);
        Task<ImovelModel> AtualizarAsync(ImovelModel locacao, int id);
        Task<bool> ApagarAsync(int id);
    }
}
