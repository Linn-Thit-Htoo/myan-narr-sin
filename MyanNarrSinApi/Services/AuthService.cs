using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using MyanNarrSinApi.Models;
using System.Data;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace MyanNarrSinApi.Services
{
    public class AuthService : ControllerBase
    {
        private readonly MyanNarrSinDbContext _dbContext;
        private IConfiguration config;
        public AuthService(MyanNarrSinDbContext dbContext, IConfiguration configuration)
        {
            this._dbContext = dbContext;
            this.config = configuration;
        }
        public async Task<int> RegisterService(UserModel userModel)
        {
            try
            {
                _dbContext.Users.Add(userModel);
                int rowsEffected = await _dbContext.SaveChangesAsync();
                return rowsEffected;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public async Task<UserModel> LoginService(UserModel userModel)
        {
            try
            {
                var user = await _dbContext.Users.FirstOrDefaultAsync(user => user.Email == userModel.Email && user.Password == userModel.Password);
                return user;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public JwtSecurityToken GenerateToken(UserModel authenticatedUser)
        {
            try
            {
                var claims = new List<Claim>
        {
            new Claim("User_ID", EncryptString(authenticatedUser.User_ID.ToString())),
            new Claim("User_Name", EncryptString(authenticatedUser.User_Name)),
            new Claim("Email", EncryptString(authenticatedUser.Email)),
            new Claim("Gender", EncryptString(authenticatedUser.Gender)),
            new Claim("Age", EncryptString(authenticatedUser.Age.ToString())),
            new Claim("Location", EncryptString(authenticatedUser.Location)),
            new Claim("Type", EncryptString(authenticatedUser.Type)),
            new Claim("Role", EncryptString(authenticatedUser.Role)),
        };

                var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["Jwt:Key"]));
                var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
                var token = new JwtSecurityToken(
                    config["Jwt:Issuer"],
                    config["Jwt:Audience"],
                    claims,
                    expires: DateTime.UtcNow.AddDays(1),
                    signingCredentials: signIn);

                return token;
            }
            catch (Exception ex)
            {
                throw new Exception("Error generating JWT token: " + ex.Message);
            }
        }


        public string EncryptString(string raw)
        {
            byte[] iv = new byte[16];
            byte[] array;
            using (System.Security.Cryptography.Aes aes = System.Security.Cryptography.Aes.Create())
            {
                aes.Key = Encoding.UTF8.GetBytes(config["EncryptionKey"]);
                aes.IV = iv;
                ICryptoTransform encryptor = aes.CreateEncryptor(aes.Key, aes.IV);

                using (MemoryStream memoryStream = new MemoryStream())
                {
                    using (CryptoStream cryptoStream = new CryptoStream((Stream)memoryStream, encryptor, CryptoStreamMode.Write))
                    {
                        using (StreamWriter streamWriter = new StreamWriter((Stream)cryptoStream))
                        {
                            streamWriter.Write(raw);
                        }
                        array = memoryStream.ToArray();
                    }
                }
            }
            return Convert.ToBase64String(array);
        }

        public async Task<bool> CheckDuplicateUserService(string email)
        {
            try
            {
                var user = await _dbContext.Users.FirstOrDefaultAsync(u => u.Email == email);
                return user != null;
            }
            catch (Exception ex)
            {
                return true;
            }
        }

    }
}
