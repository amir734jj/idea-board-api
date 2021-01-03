using System.Threading.Tasks;
using Dal.Interfaces;
using Logic.Interfaces;
using Models.Entities;

namespace Logic.Logic
{
    public class PasswordResetLogic : IPasswordResetLogic
    {
        private readonly IEmailServiceApi _emailServiceApi;

        public PasswordResetLogic(IEmailServiceApi emailServiceApi)
        {
            _emailServiceApi = emailServiceApi;
        }

        public async Task SendPasswordResetEmail(User user, string passwordResetToken)
        {
            
        }
    }
}