using APILocacaoImovel.Data;
using APILocacaoImovel.Models;
using APILocacaoImovel.Repositorio.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace APILocacaoImovel.Repositorio
{
    public class LocacaoRepositorio : ILocacaoRepositorio
    {
        private readonly Contexto _dbContext;
        public LocacaoRepositorio(Contexto locacaoImovelDBContext)
        {
            _dbContext = locacaoImovelDBContext;
        }

        public async Task<LocacaoModel> BuscarPorIdAsync(int id)
        {
            return await _dbContext.Locacoes.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<LocacaoModel>> BuscarTodasLocacoesAsync()
        {
            return await _dbContext.Locacoes.ToListAsync();
        }

        public async Task<LocacaoModel> AdicionarAsync(LocacaoModel locacao)
        {
            await _dbContext.Locacoes.AddAsync(locacao);
            await _dbContext.SaveChangesAsync();

            return locacao;
        }

        public async Task<LocacaoModel> AtualizarAsync(LocacaoModel locacao, int id)
        {
            LocacaoModel locacaoPorId = await BuscarPorIdAsync(id);

            if (locacaoPorId == null)
            {
                throw new Exception($"Locacao para o ID: {id} não foi encontrado no banco de dados.");
            }

            locacaoPorId.DataInicio = locacao.DataInicio;
            locacaoPorId.DataFim = locacao.DataFim;

            _dbContext.Locacoes.Update(locacaoPorId);
            await _dbContext.SaveChangesAsync();

            return locacaoPorId;
        }

        public async Task<bool> ApagarAsync(int id)
        {
            LocacaoModel locacaoPorid = await BuscarPorIdAsync(id);

            if (locacaoPorid == null)
            {
                throw new Exception($"Locacao para o ID: {id} não foi encontrado no banco de dados.");
            }

            _dbContext.Locacoes.Remove(locacaoPorid);
            await _dbContext.SaveChangesAsync();

            return true;
        }

    }
}
