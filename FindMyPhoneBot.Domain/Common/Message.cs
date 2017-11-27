using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindMyPhoneBot.Domain.Common
{
    public class Message
    {
        public static readonly string HelloMessage = "Hola, Soy un bot, y te puedo ayudar haciendote una llamada para encontrar tu teléfono, que quieres hacer?";
        public static readonly string GoodByMessage = "Hasta luego, vuelve pronto ;)";
        public static readonly string CantHelpMessage = "Lo siento, no puedo ayudarte con eso :(";
        public static readonly string CallingMessage = "Dame un minuto, Ya te llamo :)";
        public static readonly string AskPhoneMessage = "¿Cual es tu teléfono?";
        public static readonly string InvalidPhoneNumberMessage = "Tu número de teléfono no es válido, ¿Me puedes dar otro?";
        public static readonly string ErrorMessage = "Lo siento he fallado, por favor habla con un administrador";

    }
}
