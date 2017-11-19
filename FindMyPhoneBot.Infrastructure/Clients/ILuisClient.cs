using System.Threading.Tasks;
using FindMyPhoneBot.Domain.Common;

namespace FindMyPhoneBot.Infrastructure.Clients
{
    public interface ILuisClient
    {
        Task<IntentionResult> GetUserIntent(string message);
    }
}