using System;
using System.Collections.Generic;
using System.Text;

namespace FindMyPhoneBot.Domain.Common
{
    public static class IntentionFactory
    {

        public static Intention GetInstance(string name)
        {
            switch (name)
            {
                case "BuscarTelefono":
                    return Intention.BuscarTelefono;
                case "Saludar":
                    return Intention.Saludar;
                case "Terminar":
                    return Intention.Terminar;
                case "None":
                default:
                    return Intention.None;
            }
        }

    }
}
