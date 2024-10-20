using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Pede_RocaAPP.Application.DTOs;
using Pede_RocaAPP.Application.Interface;
using Pede_RocaAPP.Domain.Entities;
using Pede_RocaAPP.Domain.Account;
using FirebaseAdmin.Auth;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Pede_RocaAPP.API.Controllers
{
    [Route("api/usuario")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IAuthenticate _authenticate;
        private readonly IUsuarioService _usuarioService;

        public UsuarioController(IUsuarioService usuarioService, IAuthenticate authenticate)
        {
            _usuarioService = usuarioService;
            _authenticate = authenticate;
        }

        [HttpPost(Name = "AdicionarUsuario")]
        public async Task<ActionResult> Post([FromBody] UsuarioCreateDTO usuarioDTO)
        {
            if (usuarioDTO == null)
            {
                return BadRequest("Erro de dados inválidos. Verifique o payload de envio e tente novamente!");
            }

            var usuarioExiste = await _usuarioService.GetByEmailAsync(usuarioDTO.Email);
            if (usuarioExiste != null) return BadRequest("Email já cadastrado");

            var usuarioId = await _usuarioService.AdicionarAsync(usuarioDTO);

            var usuarioCriado = await _usuarioService.GetByIdAsync(usuarioId);
            if (usuarioCriado == null) return BadRequest("Erro ao criar o usuário.");

            var token = _authenticate.GenerateToken(usuarioCriado.Id, usuarioCriado.Email, usuarioCriado.NivelAcesso);

            return CreatedAtRoute("GetUsuario", new { id = usuarioId }, new
            {
                id = usuarioId,
                message = "Usuario criado com sucesso",
                token
            });
        }

        [HttpPut("{id}", Name = "AtualizarUsuario")]
        public async Task<ActionResult> Put(Guid id, [FromBody] UsuarioDTO usuarioDTO)
        {
            var usuarioExistente = await _usuarioService.GetByIdAsync(id);

            if (usuarioExistente == null)
            {
                return NotFound("Usuário não encontrado");
            }

            if (usuarioDTO == null)
            {
                return BadRequest("Dados inválidos");
            }

            await _usuarioService.AtualizarAsync(id, usuarioDTO);

            return Ok(new
            {
                mensagem = $"Usuario com o id {id} foi atualizado com sucesso"
            });
        }

        [HttpPut("alterar-foto-perfil/{id}", Name = "AtualizarFotoPerfil")]
        public async Task<ActionResult> PutFotoPerfil(Guid id, [FromBody] AtualizarFotoPerfilRequest atualizarProfilePictureRequest)
        {
            var usuarioExistente = await _usuarioService.GetByIdAsync(id);

            if (usuarioExistente == null)
            {
                return NotFound("Usuário não encontrado");
            }

            await _usuarioService.AtualizarFotoPerfilAsync(id, atualizarProfilePictureRequest.UidFotoPerfil);

            return Ok(new
            {
                message = "Foto de perfil atualizada com sucesso"
            });
        }

        [HttpPut("alterar-status-usuario/{id}", Name = "AtualizarStatusUsuario")]
        public async Task<ActionResult> PutStatusUsuario(Guid id, [FromBody] AtualizarStatusUsuarioRequest atualizarStatusUsuarioRequest)
        {
            var usuarioExistente = await _usuarioService.GetByIdAsync(id);
            if (usuarioExistente == null) return NotFound("Usuário não encontrado");

            await _usuarioService.AtualizarStatusUsuarioAsync(id, atualizarStatusUsuarioRequest.Status);

            return Ok(new
            {
                message = "Status do usuário atualizado com sucesso"
            });
        }

        [HttpPut("alterar-nivel-usuario/{id}", Name = "AtualizarNivelAcessoUsuario")]
        public async Task<ActionResult> PutNivelAcessoUsuario(Guid id, [FromBody] AtualizarNivelAcessoUsuarioRequest nivelAcesso)
        {
            var usuarioExistente = await _usuarioService.GetByIdAsync(id);
            if (usuarioExistente == null) return NotFound("Usuário não encontrado");

            await _usuarioService.AtualizarNivelAcessoUsuarioAsync(id, nivelAcesso.NivelAcesso);

            return Ok(new
            {
                message = $"Nivel do usuário atualizado com sucesso, agora o usuário é {nivelAcesso}"
            });
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

            return Ok(new
            {
                message = "Usuario removido com sucesso"
            });
        }

        // [Authorize]
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
