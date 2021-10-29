namespace Clean14000716.Application.Common.Interfaces.Public
{
    public interface ISendMessage
    {
        bool SendSms(string phoneNumber);
        bool SendEmail(string email);
    }
}