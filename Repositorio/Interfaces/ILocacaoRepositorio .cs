using APILocacaoImovel.Models;

namespace APILocacaoImovel.Repositorio.Interfaces
{
    public interface ILocacaoRepositorio
    {
        Task<List<LocacaoModel>> BuscarTodasLocacoesAsync();
        Task<LocacaoModel> BuscarPorIdAsync(int id);
        Task<LocacaoModel> AdicionarAsync(LocacaoModel locacao);
        Task<LocacaoModel> AtualizarAsync(LocacaoModel locacao, int id);
        Task<bool> ApagarAsync(int id);
    }
}
