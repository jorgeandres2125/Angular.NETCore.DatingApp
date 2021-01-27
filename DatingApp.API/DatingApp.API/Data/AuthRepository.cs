using DatingApp.API.Models;
using DatingApp.API.Security;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatingApp.API.Data
{
    public class AuthRepository : IAuthRepository
    {
        private readonly ApplicatioDataContext _context;
        public AuthRepository(ApplicatioDataContext context)
        {
            _context = context;
        }
        public async Task<User> Login(string username, string password)
        {
            var user = await _context.Users.FirstOrDefaultAsync(x => x.UserName == username);
            if (user == null)
                return null;
            /*
            if (!VerifyPasswordHash(password, user.PasswordHash, user.PasswordSalt))
                return null;
            */
            return user;
        }

        private bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            var strSalt = Encoding.UTF8.GetString(passwordSalt, 0, passwordSalt.Length);
            var strHash = Encoding.UTF8.GetString(passwordHash, 0, passwordHash.Length);
            bool result = Hash.Validate(password, strSalt, strHash);
            return result;
        }

        public async Task<User> Register(User user, string password)
        {
            byte[] passwordHash;
            byte[] passwordSalt;
            CreatePasswordHash(password, out passwordHash, out passwordSalt);
            /*
            user.PasswordHash = passwordHash;
            user.PasswordSalt = passwordSalt;
            */
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
            return user;
        }

        private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            var strSalt = Salt.Create();
            passwordSalt = Encoding.UTF8.GetBytes(strSalt);
            passwordHash = Encoding.UTF8.GetBytes(Hash.Create(password, strSalt));
        }

        public async Task<bool> UserExists(string username)
        {
            if (await _context.Users.AnyAsync(x => x.UserName == username))
                return true;
            else
                return false;
        }
    }
}
