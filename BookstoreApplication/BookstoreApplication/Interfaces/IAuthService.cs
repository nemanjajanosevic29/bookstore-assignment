using BookstoreApplication.DTOs;
using System.Security.Claims;

namespace BookstoreApplication.Interfaces
{
    public interface IAuthService
    {
        Task RegisterAsync(RegistrationDto data);
        Task<string> Login(LoginDto data);          
        Task<ProfileDto> GetProfile(ClaimsPrincipal userPrincipal);   
    }
}