using Newtonsoft.Json;

namespace CryptoScanner.App
{
    public class ApiCaller
    {
        HttpClient Client { get; set; }
        public ApiCaller()
        {
            Client = new();

        }

        public async Task GetAllCrypto()
        {
            HttpResponseMessage response = await Client.GetAsync("https://api.coingecko.com/api/v3/coins/list");

            if (response.IsSuccessStatusCode)
            {
                string json = await response.Content.ReadAsStringAsync();

                JsonConvert.DeserializeObject<string>(json);
            }
        }

        public async Task GetCryptoById(string id)
        {
            HttpResponseMessage response = await Client.GetAsync($"https://api.coingecko.com/api/v3/simple/price?ids={id}&vs_currencies=sek");

            if (response.IsSuccessStatusCode)
            {
                string json = await response.Content.ReadAsStringAsync();

                JsonConvert.DeserializeObject<string>(json);
            }
        }
    }
}
