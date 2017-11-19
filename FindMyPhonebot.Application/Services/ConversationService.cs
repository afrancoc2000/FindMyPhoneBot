using System;
using System.Collections.Generic;
using System.Configuration;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using FindMyPhoneBot.Domain.Common;
using FindMyPhoneBot.Infrastructure.Clients;
using log4net;

namespace FindMyPhonebot.Application.Services
{
    [Serializable]
    public class ConversationService : IConversationService
    {
        private readonly ILuisClient luisClient;
        private readonly IPhoneCallClient phoneCallClient;

        private static readonly ILog logger = LogManager.GetLogger(typeof(ConversationService));

        public ConversationService(ILuisClient luisClient, IPhoneCallClient phoneCallClient)
        {
            this.luisClient = luisClient;
            this.phoneCallClient = phoneCallClient;
        }

        public async Task<string> GetApplicationAnswer(string message)
        {
            try
            {
                var intentionResult = await luisClient.GetUserIntent(message);

                switch (intentionResult.Intention)
                {
                    case Intention.Saludar:
                        return Message.HelloMessage;

                    case Intention.Terminar:
                        return Message.GoodByMessage;

                    case Intention.BuscarTelefono:
                        if (intentionResult.Telefono == null)
                        {
                            return Message.AskPhoneMessage;
                        }

                        var telefono = intentionResult.Telefono.Replace("-", "").Replace(" ", "");
                        var success = long.TryParse(telefono, out long numeroTelefono);
                        if (!success)
                        {
                            return Message.InvalidPhoneNumberMessage;
                        }

                        phoneCallClient.MakePhoneCall(numeroTelefono);
                        return Message.CallingMessage;

                    case Intention.None:
                    default:
                        return Message.CantHelpMessage;
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                return Message.ErrorMessage;
            }
        }

    }
}
