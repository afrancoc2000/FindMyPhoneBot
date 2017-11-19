using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace FindMyPhoneBot.Infrastructure.Mappings
{
    [DataContract]
    internal class Intent
    {
        [DataMember( Name = "intent")]
        public string Name { get; set; }

        [DataMember( Name = "score" )]
        public double Score { get; set; }
    }
}
