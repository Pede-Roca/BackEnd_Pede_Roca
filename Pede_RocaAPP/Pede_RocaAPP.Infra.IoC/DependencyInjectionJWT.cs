using System.Text;
using FirebaseAdmin;
using FirebaseAdmin.Auth;
using Google.Apis.Auth.OAuth2;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Text.Json;
using System.Security.Claims;

namespace Pede_RocaAPP.Infra.IoC
{
    public static class DependencyInjectionJWT
    {
        public static IServiceCollection AddInfrastructureJWT(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddAuthentication(opt =>
            {
                opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })

            .AddJwtBearer(options =>
            {
                options.Events = new JwtBearerEvents
                {
                    OnMessageReceived = async context =>
                    {
                        var token = context.Request.Headers["Authorization"].ToString().Replace("Bearer ", string.Empty);

                        if (string.IsNullOrEmpty(token))
                        {
                            context.NoResult(); // Nenhum token encontrado
                            return;
                        }

                        try
                        {
                            // Verifica o token com Firebase Admin
                            var decodedToken = await FirebaseAuth.DefaultInstance.VerifyIdTokenAsync(token);
                            Console.WriteLine("Token decodificado: " + decodedToken.Uid);

                            // Cria uma lista de claims
                            var claims = new List<Claim>
                            {
                                new Claim(ClaimTypes.NameIdentifier, decodedToken.Uid),
                                new Claim("email", decodedToken.Claims["email"].ToString())
                            };

                            // Se tiver claims adicionais no token, você pode adicionar aqui
                            foreach (var claim in decodedToken.Claims)
                            {
                                claims.Add(new Claim(claim.Key, claim.Value.ToString()));
                            }

                            // Associa o ClaimsPrincipal ao contexto da requisição
                            var claimsIdentity = new ClaimsIdentity(claims, JwtBearerDefaults.AuthenticationScheme);
                            context.Principal = new ClaimsPrincipal(claimsIdentity);

                            // Marca a autenticação como bem-sucedida
                            context.Success();
                        }
                        catch (FirebaseAuthException e)
                        {
                            // Falha na autenticação
                            Console.WriteLine("Erro ao decodificar token: " + e.Message);
                            context.Fail("Token inválido.");
                        }
                    }
                };

                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = $"https://securetoken.google.com/{configuration["Jwt:ValidAudience"]}",
                    ValidAudience = configuration["Jwt:ValidAudience"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:SecretKey"])),
                    ClockSkew = TimeSpan.Zero
                };
            });

            return services;
        }
    }
}
