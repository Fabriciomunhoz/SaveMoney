using SaveMoney.Domain.Entities;

namespace SaveMoney.Domain.Account
{
    public interface IAuthenticate
    {
        Task<bool> Authenticate(string email, string password);
        Task<string> RegisterUser(string email, string password);
        Task<UserToken> GenerateToken(string email);
        Task Logout();
    }
}
