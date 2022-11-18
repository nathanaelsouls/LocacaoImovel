using APILocacaoImovel.Data;
using APILocacaoImovel.Models;
using APILocacaoImovel.Repositorio.Interfaces;
using Correios;
using Microsoft.EntityFrameworkCore;

namespace APILocacaoImovel.Repositorio
{
    public class ImovelRepositorio : IImovelRepositorio
    {
        private readonly Contexto _dbContext;

        public ImovelRepositorio(Contexto locacaoImovelDBContext)
        {
            _dbContext = locacaoImovelDBContext;
        }

        public async Task<ImovelModel> BuscarPorIdAsync(int id)
        {
            return await _dbContext.Imoveis.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<ImovelModel>> BuscarTodosImoveisAsync()
        {
            return await _dbContext.Imoveis.ToListAsync();
        }

        public async Task<ImovelModel> AdicionarAsync(ImovelModel imovel)
        {
            CorreiosApi correiosApi = new();
            if (correiosApi.consultaCEP(imovel.Cep) != null)
            {
                var endereco = correiosApi.consultaCEP(imovel.Cep);
                imovel.Endereco = endereco.end;
                imovel.Cidade = endereco.cidade;
                imovel.Bairro = endereco.bairro;
                imovel.Estado = endereco.uf;
                imovel.Completo1 = endereco.complemento;
                imovel.Completo2 = endereco.complemento2;
            }

            await _dbContext.Imoveis.AddAsync(imovel);
            await _dbContext.SaveChangesAsync();

            return imovel;
        }

        public async Task<ImovelModel> AtualizarAsync(ImovelModel imovel, int id)
        {
            ImovelModel imovelPorId = await BuscarPorIdAsync(id);

            if (imovelPorId == null)
            {
                throw new Exception($"Imovel para o ID: {id} não foi encontrado no banco de dados.");
            }

            imovelPorId.Nome = imovel.Nome;
            imovelPorId.ValorLocacao = imovel.ValorLocacao;
            imovelPorId.Descricao = imovel.Descricao;
            imovelPorId.Cep = imovel.Cep;
            imovelPorId.Endereco = imovel.Endereco;
            imovelPorId.Estado = imovel.Estado;
            imovelPorId.Cidade = imovel.Cidade;

            _dbContext.Imoveis.Update(imovelPorId);
            await _dbContext.SaveChangesAsync();

            return imovelPorId;
        }

        public async Task<bool> ApagarAsync(int id)
        {
            ImovelModel ImovelPorid = await BuscarPorIdAsync(id);

            if (ImovelPorid == null)
            {
                throw new Exception($"Imovel para o ID: {id} não foi encontrado no banco de dados.");
            }

            _dbContext.Imoveis.Remove(ImovelPorid);
            await _dbContext.SaveChangesAsync();

            return true;
        }

    }
}
