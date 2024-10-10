using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Pede_RocaAPP.Application.DTOs;
using Pede_RocaAPP.Application.Interface;
using Pede_RocaAPP.Domain.Entities;

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
        public async Task<ActionResult> Post([FromBody] UsuarioCreateDTO usuarioDTO)
        {
            if (usuarioDTO == null)
            {
                return BadRequest("Erro de dados inválidos. Verifique o payload de envio e tente novamente!");
            }

            var usuarioExiste = await _usuarioService.GetByEmailAsync(usuarioDTO.Email);

            if (usuarioExiste != null)
            {
                return BadRequest("Email já cadastrado");
            }

            var usuarioId = await _usuarioService.AdicionarAsync(usuarioDTO);

            return CreatedAtRoute("GetUsuario", new { id = usuarioId }, new
            {
                id = usuarioId,
                message = "Usuario criado com sucesso"
            });
        }

        [HttpPut("{id}", Name = "AtualizarUsuario")]
        public async Task<ActionResult> Put(Guid id, [FromBody] UsuarioDTO usuarioDTO)
        {
            // Busca o usuário atual do banco de dados
            var usuarioExistente = await _usuarioService.GetByIdAsync(id);

            if (usuarioExistente == null)
            {
                return NotFound("Usuário não encontrado");
            }

            if (id != usuarioExistente.Id)
            {
                return BadRequest("Id não válido");
            }

            if (usuarioDTO == null)
            {
                return BadRequest("Dados inválidos");
            }

            // Mantém os dados existentes para campos não atualizados
            usuarioExistente.Email = string.IsNullOrEmpty(usuarioDTO.Email) ? usuarioExistente.Email : usuarioDTO.Email;
            usuarioExistente.Senha = string.IsNullOrEmpty(usuarioDTO.Senha) ? usuarioExistente.Senha : usuarioDTO.Senha;
            usuarioExistente.Nome = string.IsNullOrEmpty(usuarioDTO.Nome) ? usuarioExistente.Nome : usuarioDTO.Nome;
            usuarioExistente.Telefone = string.IsNullOrEmpty(usuarioDTO.Telefone) ? usuarioExistente.Telefone : usuarioDTO.Telefone;
            usuarioExistente.Cpf = string.IsNullOrEmpty(usuarioDTO.Cpf) ? usuarioExistente.Cpf : usuarioDTO.Cpf;

            // Verificando se as datas são as padrões ou se foram passadas na requisição
            usuarioExistente.DataNasc = usuarioDTO.DataNasc == default(DateTime) ? usuarioExistente.DataNasc : usuarioDTO.DataNasc;

            // O Status e o Nível de Acesso são campos obrigatórios, então devem ser atualizados
            usuarioExistente.Status = usuarioDTO.Status;
            usuarioExistente.NivelAcesso = string.IsNullOrEmpty(usuarioDTO.NivelAcesso) ? usuarioExistente.NivelAcesso : usuarioDTO.NivelAcesso;

            // Atualizando a foto de perfil, se fornecida
            usuarioExistente.UidFotoPerfil = string.IsNullOrEmpty(usuarioDTO.UidFotoPerfil) ? usuarioExistente.UidFotoPerfil : usuarioDTO.UidFotoPerfil;

            // Assegurando que a data de criação da conta não seja alterada
            usuarioExistente.CreateUserDate = usuarioExistente.CreateUserDate;

            // Atualiza os dados no banco de dados
            await _usuarioService.AtualizarAsync(id, usuarioExistente);

            return Ok(usuarioExistente);
        }

        [HttpDelete("{id}", Name = "DeleteUsuario")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(MensagemResponse))]
        public async Task<ActionResult<UsuarioDTO>> DeleteAsync(Guid id)
        {
            var usuarioDto = await _usuarioService.GetByIdAsync(id);
            
            if (usuarioDto == null)
            {
                return NotFound("Usuário não encontrado");
            }

            await _usuarioService.DeleteAsync(id);

            return Ok(new
            {
                message = "Usuario removido com sucesso"
            });
        }

        [Authorize]
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

        [Authorize]
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