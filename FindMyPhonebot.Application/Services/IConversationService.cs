using System.Threading.Tasks;

namespace FindMyPhonebot.Application.Services
{
    public interface IConversationService
    {
        Task<string> GetApplicationAnswer(string message);
    }
}