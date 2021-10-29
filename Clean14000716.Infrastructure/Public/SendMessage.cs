using Clean14000716.Application.Common.Interfaces.Public;
using Clean14000716.Common.ForAutofacMark;

namespace Clean14000716.Infrastructure.Public
{
    public class SendMessage : ISendMessage, IScopedDependency
    {
        public bool SendSms(string phoneNumber)
        {
            return true;
        }

        public bool SendEmail(string email)
        {
            return true;
        }
    }
}