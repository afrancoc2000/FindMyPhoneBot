using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace FindMyPhoneBot.Infrastructure.Mappings
{
    [DataContract]
    internal class Entity
    {
        [DataMember(Name = "entity")]
        public string Value { get; set; }

        [DataMember(Name = "type")]
        public string Name { get; set; }

        [DataMember(Name = "startIndex")]
        public int StartIndex { get; set; }

        [DataMember(Name = "endIndex")]
        public int EndIndex { get; set; }

        [DataMember(Name = "score")]
        public double Score { get; set; }
    }
}
