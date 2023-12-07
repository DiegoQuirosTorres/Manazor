

using Manazor.Domain.Entities;

namespace Manazor.Application.Interfaces.Repositories
{
    public interface IAuthService
    {
        Task<Employee?> Login(string username, string password);
    }
}
