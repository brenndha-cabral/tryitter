using Microsoft.EntityFrameworkCore;
using tryitter.Database;
using tryitter.Helper;
using tryitter.Interfaces;

namespace tryitter.Repository
{
    public class LoginRepository : ILogin
    {
        protected readonly AplicationContext _context;

        public LoginRepository(AplicationContext context)
        {
            _context = context;
        }

        public async Task<string> TokenGenerate(string email, string password)
        {
            var student = await _context.Students.Where(
                s => s.Email == email
                && s.Password == password
                ).FirstOrDefaultAsync();

            if (student is null)
            {
                return null;
            }

            var token = new TokenGenerator().Generate(student.StudentId);
            return token;
        }
    }
}
