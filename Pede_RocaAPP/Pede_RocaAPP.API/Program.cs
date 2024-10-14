using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.OpenApi.Models;
using Microsoft.IdentityModel.Tokens;
using Pede_RocaAPP.Application.Interface;
using Pede_RocaAPP.Application.Services;
using Pede_RocaAPP.Domain.Interfaces;
using Pede_RocaAPP.Infra.Data.Repositories;
using Pede_RocaAPP.Infra.IoC;
using FirebaseAdmin;
using Google.Apis.Auth.OAuth2;
using Pede_RocaAPP.Domain.Account;
using Pede_RocaAPP.Infra.Data.Identity;
using Serilog;
using System.Text.Json;

internal class Program
{
    private static void Main(string[] args)
    {
        Log.Logger = new LoggerConfiguration().WriteTo.Console().CreateLogger();

        try
        {
            Log.Information("Starting application");

            var builder = WebApplication.CreateBuilder(args);

            builder.Host.UseSerilog();

            var firebaseCredentialsSection = builder.Configuration.GetSection("Firebase-Credentials");
            var firebaseCredentials = JsonSerializer.Serialize(firebaseCredentialsSection.GetChildren().ToDictionary(x => x.Key, x => x.Value));

            FirebaseApp.Create(new AppOptions()
            {
                Credential = GoogleCredential.FromJson(firebaseCredentials)
            });

            builder.Services.AddInfrastructure(builder.Configuration);
            builder.Services.AddInfrastructureJWT(builder.Configuration);
            builder.Services.AddInfrastructureSwagger();

            builder.Services.AddEndpointsApiExplorer();

            builder.Services.AddCors(options =>
            {
                options.AddPolicy(
                    "AllowAll", builder =>
                    {
                        builder.AllowAnyOrigin()
                               .AllowAnyMethod()
                               .AllowAnyHeader();
                    });
            });

            builder.Services.AddControllers();

            var app = builder.Build();

            app.UseSwagger();
            app.UseSwaggerUI();
       
            app.UseSerilogRequestLogging(); // Add Serilog request logging

            app.UseHttpsRedirection();

            app.UseCors("AllowAll");

            app.UseRouting();

            app.UseAuthentication();

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
        catch (Exception ex)
        {
            Log.Fatal(ex, "Application start-up failed");
        }
        finally
        {
            Log.CloseAndFlush();
        }
    }
}