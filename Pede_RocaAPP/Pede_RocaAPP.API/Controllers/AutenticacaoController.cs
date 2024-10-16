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
                // Autentica o usuário com base no email e senha
                var usuario = await _usuarioService.GetPorEmailESenhaAsync(loginRequest.Email, loginRequest.Senha);

                if (usuario == null)
                {
                    return Unauthorized("Usuário ou senha inválidos.");
                }

                Console.Clear();
                Console.WriteLine("Usuário autenticado com sucesso!");
                UserRecord userRecord = await FirebaseAuth.DefaultInstance.GetUserByEmailAsync(usuario.Email);
                Console.WriteLine($"ID: {usuario}");


                // // Cria claims personalizados para o token
                // var claims = new Dictionary<string, object>()
                // {
                //     { "nivelAcesso", usuario.NivelAcesso },  // Claim para o nível de acesso do usuário
                //     { "email", usuario.Email }
                // };

                // // Gera o token personalizado com os claims
                // string customToken = await FirebaseAuth.DefaultInstance.CreateCustomTokenAsync(usuario.Id.ToString(), claims);

                // Retorna o token no corpo da resposta
                return Ok(new
                {
                    Token = "customToken",
                    Message = "Token gerado com sucesso"
                });
            }
            catch (FirebaseAuthException ex)
            {
                return Unauthorized($"Erro ao validar o token Firebase: {ex.Message}");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro interno: {ex.Message}");
            }
        }
    }
}
