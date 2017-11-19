using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace FindMyPhoneBot.Infrastructure.Mappings
{
    [DataContract]
    internal class LuisResponse
    {
        [DataMember(Name = "query")]
        public string Query { get; set; }

        [DataMember(Name = "topScoringIntent")]
        public Intent TopScoringIntent { get; set; }

        [DataMember(Name = "intents")]
        public ICollection<Intent> Intents { get; set; }

        [DataMember(Name = "entities")]
        public ICollection<Entity> Entities { get; set; }


    }
}
