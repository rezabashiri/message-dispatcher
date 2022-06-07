using IdentityModel.Client;

namespace Message.Dispatcher.Web.Interfaces;

public interface IAuthencticationHelper
{
    Task<TokenResponse> GetTokenAsync(PasswordTokenRequest request);
    Task<bool> SignOutAsync();
}