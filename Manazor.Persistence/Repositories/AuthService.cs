using Manazor.Application.Interfaces.Repositories;
using Manazor.Domain.Entities;
using Manazor.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using BCrypt.Net;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

           var a = BCrypt.Net.BCrypt.HashPassword(password);

            return employee == null ? null
                                    : BCrypt.Net.BCrypt.Verify(password, employee.Password)
                                    ? employee : null;
        }
    }
}
