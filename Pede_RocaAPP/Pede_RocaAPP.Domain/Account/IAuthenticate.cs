using Pede_RocaAPP.Domain.Entities;

namespace Pede_RocaAPP.Domain.Account
{
    public interface IAuthenticate
    {
        Task<bool> AuthenticateAsync(string email, string password);
        Task<bool> UserExist(string email);
        public UserToken GenerateToken(Guid id, string email, string nivelAcesso);
    }
}