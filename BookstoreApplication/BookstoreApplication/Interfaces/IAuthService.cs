using BookstoreApplication.DTOs;

namespace BookstoreApplication.Interfaces
{
    public interface IAuthService
    {
        Task RegisterAsync(RegistrationDto data);
        Task Login(LoginDto data);
    }
}
