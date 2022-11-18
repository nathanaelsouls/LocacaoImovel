using APILocacaoImovel.Models;
using APILocacaoImovel.Repositorio;
using APILocacaoImovel.Repositorio.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace APILocacaoImovel.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocacaoController : ControllerBase
    {
        private readonly ILocacaoRepositorio _locacaoRepositorio;

        public LocacaoController(ILocacaoRepositorio locacaoRepositorio)
        {
            _locacaoRepositorio = locacaoRepositorio;
        }

        [HttpGet("buscar-todas-locacoes")]
        public async Task<ActionResult<List<LocacaoModel>>> BuscarTodas()
        {
            List<LocacaoModel> locacao = await _locacaoRepositorio.BuscarTodasLocacoesAsync();
            return Ok(locacao);
        }

        [HttpGet("buscar-locacao/{id}")]
        public async Task<ActionResult<LocacaoModel>> BuscarPorId(int id)
        {
            LocacaoModel locacao = await _locacaoRepositorio.BuscarPorIdAsync(id);
            return Ok(locacao);
        }

        [HttpPost("adicionar-locacao")]
        public async Task<ActionResult<LocacaoModel>> Adicionar(LocacaoModel locacaoModel)
        {
            LocacaoModel locacao = await _locacaoRepositorio.AdicionarAsync(locacaoModel);
            return Ok(locacao);
        }

        [HttpPut("alterar-locacao/{id}")]
        public async Task<ActionResult<LocacaoModel>> Alterar(LocacaoModel locacaoModel, int id)
        {
            LocacaoModel locacao = await _locacaoRepositorio.AtualizarAsync(locacaoModel, id);
            return Ok(locacao);
        }

        [HttpDelete("deletar-locacao/{id}")]
        public async Task<ActionResult<LocacaoModel>> Deletar(int id)
        {
            bool excluido = await _locacaoRepositorio.ApagarAsync(id);
            return Ok(excluido);
        }
    }
}
