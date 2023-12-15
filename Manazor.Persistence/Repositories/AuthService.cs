using Manazor.Application.Interfaces.Repositories;
using Manazor.Domain.Entities;
using Manazor.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
namespace Manazor.Persistence.Repositories
{
    public class AuthService : IAuthService
    {
        private readonly ApplicationDbContext _dbContext;

        public AuthService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Employee?> Login(string username, string password)
        {
            Employee? employee =  await _dbContext.Employees
                                            .Where(e => e.Email == username)
                                            .FirstOrDefaultAsync();

            return employee == null ? null
                                    : BCrypt.Net.BCrypt.Verify(password, employee.Password)
                                    ? employee : null;
        }
    }
}
