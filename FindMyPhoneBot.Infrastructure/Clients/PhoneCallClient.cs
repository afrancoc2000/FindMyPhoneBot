namespace FindMyPhoneBot.Infrastructure.Clients
{
    using System;
    using System.Configuration;
    using System.Collections.Generic;
    using System.Net.Http;
    using System.Net.Http.Headers;
    using System.Text;
    using System.Threading.Tasks;
    using Nexmo.Api.Voice;

    [Serializable]
    public class PhoneCallClient : IPhoneCallClient
    {
        #region Data Members
        #endregion

        #region Construction

        public PhoneCallClient()
        {
        }

        #endregion

        #region IPhoneCallClient Members

        public void MakePhoneCall(long phoneNumber)
        {
            Call.Do(new Call.CallCommand
            {
                to = new[]
                {
                    new Call.Endpoint {
                        type = "phone",
                        number = string.Format("57{0}", phoneNumber)
                    }
                },
                from = new Call.Endpoint
                {
                    type = "phone",
                    number = "12034089688"
                },
                answer_url = new[]
                {
                    "https://nexmo-community.github.io/ncco-examples/first_call_talk.json"
                }
            });
        }

        #endregion
    }

}
