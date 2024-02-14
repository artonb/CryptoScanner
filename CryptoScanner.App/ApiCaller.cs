using CryptoScanner.Data.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

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
        /// Hämtar namnet och id för alla kryptovalutor från API:et.
        /// </summary>
        /// <returns>En lista med <see cref="CryptoViewModel"/> som innehåller namnet och id för varje kryptovaluta.</returns>
        /// <exception cref="Exception">Kastas om det inte går att hämta kryptovalutor från API:et.</exception>
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
            throw new Exception("Something went wrong, try again later");
        }

        /// <summary>
        /// Hämtar en specifik cryptovaluta utifrån vad valutan heter
        /// </summary>
        /// <param name="id">Namnet på cryptovalutan</param>
        /// <returns> En <see cref="CryptoViewModel"/> med id, namn och värdet i SEK</returns>
        /// <exception cref="Exception">Throwar en exception om det inte funkar</exception>
        public async Task<CryptoViewModel> GetCryptoViewModelById(string name)
        {

            string id = CryptoService.ConvertToSnakeCase(name);

            HttpResponseMessage response = await Client.GetAsync($"https://api.coingecko.com/api/v3/simple/price?ids={id.ToLower()}&vs_currencies=sek");

            if (response.IsSuccessStatusCode)
            {
                string json = await response.Content.ReadAsStringAsync();

                JObject jsonObject = JObject.Parse(json);

                if (jsonObject[id] != null && jsonObject[id]["sek"] != null)
                {
                    decimal sekValue = (decimal)jsonObject[id]["sek"];
                    string nameWithTitleCase = CryptoService.ConvertToTitleCase(id);

                    CryptoViewModel newCrypto = new()
                    {
                        Id = id,
                        //TODO: Gör så Name blir Pascal case av id
                        Name = nameWithTitleCase,
                        Price = sekValue
                    };

                    return newCrypto;
                }
            }

            throw new Exception("Can't find cryptocurrency with that name");
        }

    }
}
