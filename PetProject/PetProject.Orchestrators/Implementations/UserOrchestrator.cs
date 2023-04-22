using NLog;
using PetProject.Orchestrators.Interfaces;
using PetProject.Entities.Models;
using PetProject.DataContext.MSSql;
using PetProject.DataContext.Interfaces;
using PetProject.DataAccess.Repositories.Interfaces;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace PetProject.Orchestrators.Implementations
{
    public class UserOrchestrator : IUserOrchestrator 
    {
        private static readonly Logger mLogger = LogManager.GetLogger("UserOrchestratorLogger");

        private readonly IRepository<IUserContext, User, Guid> mUser;

        public UserOrchestrator(IRepository<IUserContext, User, Guid> user) 
        {
            mUser = user;
        }

        public List<User> GetUsers()
        {
            mLogger.Info("Start GET Orchestrator method GetUsers");

            var users = mUser.GetAll().ToList();

            return users;
        }

        public User AddUser(User user)
        {
            mLogger.Info("Start Post Orchestrator method AddUser");

            mUser.Add(user);
            mUser.SaveChanges();

            return user;
        }
        
        public string DeleteUser(User user)
        {
            mLogger.Info("Start Post Orchestrator method DeleteUser");

            mUser.Remove(user);
            mUser.SaveChanges();

            return "User successful delete!";
        }
        
        public string AuthorizationUser(string userName)
        {
            var claims = new List<Claim> { new Claim(ClaimTypes.Name, userName) };
            // создаем JWT-токен
            var jwt = new JwtSecurityToken(
                    issuer: AuthOptions.ISSUER,
                    audience: AuthOptions.AUDIENCE,
                    claims: claims,
                    expires: DateTime.UtcNow.Add(TimeSpan.FromMinutes(2)),
                    signingCredentials: new SigningCredentials(AuthOptions.GetSymmetricSecurityKey(), SecurityAlgorithms.HmacSha256));

            return new JwtSecurityTokenHandler().WriteToken(jwt);
        }
    }

    public class AuthOptions
    {
        public const string ISSUER = "MyAuthServer"; // издатель токена
        public const string AUDIENCE = "MyAuthClient"; // потребитель токена
        const string KEY = "mysupersecret_secretkey!123";   // ключ для шифрации
        public static SymmetricSecurityKey GetSymmetricSecurityKey() =>
            new SymmetricSecurityKey(Encoding.UTF8.GetBytes(KEY));
    }
}
