using System.Threading.Tasks;

namespace FindMyPhoneBot.Infrastructure.Clients
{
    public interface IPhoneCallClient
    {
        void MakePhoneCall(long phoneNumber);
    }
}