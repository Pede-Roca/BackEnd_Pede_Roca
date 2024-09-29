using Microsoft.AspNetCore.Mvc;
using Pede_RocaAPP.Application.DTOs;
using Pede_RocaAPP.Application.Interface;

namespace Pede_RocaAPP.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioService _usuarioService;

        public UsuarioController(IUsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }

        [HttpPost(Name = "AdicionarUsuario")]
        public async Task<ActionResult> Post([FromBody] UsuarioDTO usuarioDTO)
        {
            if (usuarioDTO == null)
            {
                return BadRequest("Erro de dado inválido");
            }
            
            await _usuarioService.AdicionarAsync(usuarioDTO);

            return CreatedAtRoute("GetUsuario", new { id = usuarioDTO.Id }, usuarioDTO);
        }

        [HttpPut("{id}", Name = "AtualizarUsuario")]
        public async Task<ActionResult> Put(Guid id, [FromBody] UsuarioDTO usuarioDTO)
        {
            if (id != usuarioDTO.Id)
            {
                return BadRequest("Id não válido");
            }
            if (usuarioDTO == null)
            {
                return BadRequest("Erro de dado inválido");
            }

            await _usuarioService.AtualizarAsync(id, usuarioDTO);

            return Ok(usuarioDTO);
        }

        [HttpDelete("{id}", Name = "DeleteUsuario")]
        public async Task<ActionResult<UsuarioDTO>> DeleteAsync(Guid id)
        {
            var usuarioDto = await _usuarioService.GetByIdAsync(id);
            if (usuarioDto == null)
            {
                return NotFound("Usuário não encontrado");
            }
            await _usuarioService.DeleteAsync(id);

            return Ok(usuarioDto);
        }

        [HttpGet("{id}", Name = "GetUsuario")]
        public async Task<ActionResult<UsuarioDTO>> GetAsync(Guid id)
        {
            var usuarioDto = await _usuarioService.GetByIdAsync(id);
            if (usuarioDto == null)
            {
                return NotFound("Usuário não encontrado");
            }

            return Ok(usuarioDto);
        }

        [HttpGet(Name = "GetAllUsuarios")]
        public async Task<ActionResult<IEnumerable<UsuarioDTO>>> GetAllAsync()
        {
            var usuariosDto = await _usuarioService.GetAllAsync();
            if (usuariosDto == null)
            {
                return NotFound("Nenhum usuário encontrado");
            }

            return Ok(usuariosDto);
        }
    }
}