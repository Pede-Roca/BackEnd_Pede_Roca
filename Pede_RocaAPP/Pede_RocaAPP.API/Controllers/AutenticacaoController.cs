using Microsoft.AspNetCore.Mvc;
using Pede_RocaAPP.Application.Interface;
using Pede_RocaAPP.Domain.Account;
using FirebaseAdmin.Auth; // Firebase Admin SDK
using Pede_RocaAPP.Domain.Entities;

namespace Pede_RocaAPP.API.Controllers
{
    [Route("api/login")]
    public class AutenticacaoController : Controller
    {
        private readonly IAuthenticate _authenticate;
        private readonly IUsuarioService _usuarioService;

        public AutenticacaoController(IAuthenticate authenticate, IUsuarioService usuarioService)
        {
            _authenticate = authenticate;
            _usuarioService = usuarioService;
        }

        [HttpPost(Name = "Login")]
        public async Task<ActionResult<UserToken>> Login([FromBody] LoginRequest loginRequest)
        {
            try
            {
                var usuarioEncontrado = await _usuarioService.GetByEmailESenhaAsync(loginRequest.Email, loginRequest.Senha);

                if (usuarioEncontrado == null)
                {
                    return Unauthorized("Usuário ou senha inválidos");
                }

                var token = _authenticate.GenerateToken(usuarioEncontrado.Id, usuarioEncontrado.Email, usuarioEncontrado.NivelAcesso);

                return Ok(token);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return Unauthorized($"Erro ao efetuar o login");
            }
        }
    }
}
