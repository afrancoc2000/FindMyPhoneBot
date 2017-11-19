namespace FindMyPhoneBot.Infrastructure.Clients
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net.Http;
    using System.Net.Http.Headers;
    using System.Text;
    using System.Threading.Tasks;
    using System.Web;
    using FindMyPhoneBot.Domain.Common;
    using FindMyPhoneBot.Infrastructure.Mappings;
    using Newtonsoft.Json;

    [Serializable]
    public class LuisClient : ILuisClient
    {
        #region Data Members

        private static HttpClient client = new HttpClient();

        private readonly string uri;
        private readonly string apiKey;

        #endregion

        #region Construction

        public LuisClient(string uri, string apiKey)
        {
            this.uri = uri;
            this.apiKey = apiKey;
        }

        #endregion

        #region ILuisClient Members

        public async Task<IntentionResult> GetUserIntent(string message)
        {
            string apiUri = $"{uri}?subscription-key={apiKey}&verbose=true&timezoneOffset=0&q={HttpUtility.UrlEncode(message)}";

            client.DefaultRequestHeaders.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage response = await client.GetAsync(apiUri);

            if (!response.IsSuccessStatusCode)
            {
                throw new ApplicationException("LUIS API didn't answered successfully");
            }

            var json = response.Content.ReadAsStringAsync().Result;
            var result = JsonConvert.DeserializeObject<LuisResponse>(json);

            var intention = IntentionFactory.GetInstance(result.TopScoringIntent.Name);
            var intentionResult = new IntentionResult { Intention = intention };

            if (result.Entities.Any())
            {
                intentionResult.Telefono = result.Entities.First().Value;
            }

            return intentionResult;
        }

        #endregion


    }
}
