using CryptoScanner.App;
using CryptoScanner.Data.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CryptoScanner.UI.Pages
{
    public class OttoTestPageModel : PageModel
    {
        public async Task OnGet()
        {
            ApiCaller caller = new();

            //Fungerar, list blir alla crypto currencies i API:t
            //List<CryptoViewModel> list = await caller.GetAllCryptoToViewModels();

            CryptoViewModel bitcoin = await caller.GetCryptoViewModelById("bitcoin");
        }
    }
}
