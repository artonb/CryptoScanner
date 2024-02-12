using CryptoScanner.Data.Models;
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

        /// <summary>
        /// Returns the name and id of all crypto currencies in the API
        /// </summary>
        /// <returns>List<CryptoViewModel></returns>
        /// <exception cref="Exception"></exception>
        public async Task<List<CryptoViewModel>> GetAllCryptoToViewModels()
        {
            HttpResponseMessage response = await Client.GetAsync("https://api.coingecko.com/api/v3/coins/list");

            if (response.IsSuccessStatusCode)
            {
                string json = await response.Content.ReadAsStringAsync();

                List<CryptoRootModel>? result = JsonConvert.DeserializeObject<List<CryptoRootModel>>(json);

                if (result != null && result.Count > 0)
                {
                    List<CryptoViewModel> viewResults = new();

                    foreach (CryptoRootModel root in result)
                    {
                        CryptoViewModel newCrypto = new()
                        {
                            Id = root.Id,
                            Name = root.Name,
                        };
                        viewResults.Add(newCrypto);
                    }

                    return viewResults;
                }

            }

            throw new Exception();
        }

        public async Task<CryptoViewModel> GetCryptoViewModelById(string id)
        {
            HttpResponseMessage response = await Client.GetAsync($"https://api.coingecko.com/api/v3/simple/price?ids={id}&vs_currencies=sek");

            if (response.IsSuccessStatusCode)
            {
                string json = await response.Content.ReadAsStringAsync();

                //TODO: SEK blir 0
                CryptoData cryptoData = JsonConvert.DeserializeObject<CryptoData>(json);

                if (cryptoData != null)
                {
                    CryptoViewModel newCrypto = new()
                    {
                        Id = id,
                        Name = id,
                        Price = cryptoData.Sek
                    };

                    return newCrypto;
                }
            }

            throw new Exception();
        }
    }
}
