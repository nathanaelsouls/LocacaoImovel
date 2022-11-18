using APILocacaoImovel.Models;
using APILocacaoImovel.Repositorio;
using APILocacaoImovel.Repositorio.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace APILocacaoImovel.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImovelController : ControllerBase
    {
        private readonly IImovelRepositorio _imovelRepositorio;

        public ImovelController(IImovelRepositorio imovelRepositorio)
        {
            _imovelRepositorio = imovelRepositorio;
        }

        [HttpGet("buscar-todos-imoveis")]
        public async Task<ActionResult<List<ImovelModel>>> BuscarTodas()
        {
            List<ImovelModel> imovel = await _imovelRepositorio.BuscarTodosImoveisAsync();
            return Ok(imovel);
        }

        [HttpGet("buscar-imovel/{id}")]
        public async Task<ActionResult<ImovelModel>> BuscarPorId(int id)
        {
            ImovelModel imovel = await _imovelRepositorio.BuscarPorIdAsync(id);
            return Ok(imovel);
        }

        [HttpPost("adicionar-imovel")]
        public async Task<ActionResult<ImovelModel>> Cadastrar([FromBody] ImovelModel imovelModel)
        {
            ImovelModel imovel = await _imovelRepositorio.AdicionarAsync(imovelModel);
            return Ok(imovel);
        }

        [HttpPut("alterar-imovel/{id}")]
        public async Task<ActionResult<ImovelModel>> Alterar([FromBody]ImovelModel imovelModel, int id)
        {
            ImovelModel imovel = await _imovelRepositorio.AtualizarAsync(imovelModel, id);
            return Ok(imovel);
        }

        [HttpDelete("deletar-imovel/{id}")]
        public async Task<ActionResult<ImovelModel>> Deletar(int id)
        {
            bool excluido = await _imovelRepositorio.ApagarAsync(id);
            return Ok(excluido);
        }
    }
}
