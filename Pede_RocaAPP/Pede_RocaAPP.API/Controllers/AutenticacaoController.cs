using Microsoft.AspNetCore.Mvc;
using Pede_RocaAPP.Application.Interface;
using Pede_RocaAPP.Domain.Account;
using FirebaseAdmin.Auth; // Firebase Admin SDK
using Pede_RocaAPP.Domain.Entities;

namespace Pede_RocaAPP.API.Controllers
{
    [Route("api/[controller]")]
    public class AutenticacaoController : Controller
    {
        private readonly IAuthenticate _authenticate;
        private readonly IUsuarioService _usuarioService;

        public AutenticacaoController(IAuthenticate authenticate, IUsuarioService usuarioService)
        {
            _authenticate = authenticate;
            _usuarioService = usuarioService;
        }

        [HttpPost(Name = "Gerar Token")]
        public async Task<ActionResult<UserToken>> Login([FromBody] LoginRequest loginRequest)
        {
            try
            {
                // Valida o token JWT usando o Firebase Admin SDK
                FirebaseToken decodedToken = await FirebaseAuth.DefaultInstance.VerifyIdTokenAsync(loginRequest.Token);
                string firebaseUid = decodedToken.Uid; // UID do Firebase

                // // Verifica se o email no token corresponde ao email passado
                if (decodedToken.Claims.TryGetValue("email", out object tokenEmail) && tokenEmail.ToString() == loginRequest.Email)
                {
                    var usuario = await _usuarioService.GetByEmailAsync(loginRequest.Email);
                    var token = _authenticate.GenerateToken(usuario.Id, loginRequest.Email, usuario.NivelAcesso);

                    return token;
                }
                else
                {
                    return Unauthorized("O e-mail fornecido não corresponde ao token.");
                }
            }
            catch (FirebaseAuthException ex)
            {
                return Unauthorized($"Erro ao validar o token Firebase: {ex.Message}");
            }
        }
    }
}
