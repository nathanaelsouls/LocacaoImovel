using APILocacaoImovel.Models;
using APILocacaoImovel.Repositorio.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace APILocacaoImovel.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioRepositorio _usuarioRepositorio;
        public UsuarioController(IUsuarioRepositorio usuarioRepositorio)
        {
            _usuarioRepositorio = usuarioRepositorio;
        }

        [HttpGet]
        public async Task<ActionResult<List<UsuarioModel>>> BuscarTodas()
        {
            List<UsuarioModel> usuarios = await _usuarioRepositorio.BuscarTodosUsuariosAsync();
            return Ok(usuarios);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<UsuarioModel>> BuscarPorId(int id)
        {
            UsuarioModel usuario = await _usuarioRepositorio.BuscarPorIdAsync(id);
            return Ok(usuario);
        }

        [HttpPost]
        public async Task<ActionResult<UsuarioModel>> Cadastrar([FromBody] UsuarioModel usuarioModel)
        {
            UsuarioModel usuario = await _usuarioRepositorio.AdicionarAsync(usuarioModel);
            return Ok(usuario);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<UsuarioModel>> Alterar([FromBody] UsuarioModel usuarioModel, int id)
        {            
            UsuarioModel usuario = await _usuarioRepositorio.AtualizarAsync(usuarioModel, id);
            return Ok(usuario);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<UsuarioModel>> Deletar(int id)
        {
            bool excluido = await _usuarioRepositorio.ApagarAsync(id);
            return Ok(excluido);
        }
    }
}
