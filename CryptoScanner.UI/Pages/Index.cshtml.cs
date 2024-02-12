using CryptoScanner.Data.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CryptoScanner.UI.Pages
{
    public class IndexModel : PageModel
    {

        public string? ErrorMessage { get; set; }
        [BindProperty]
        public CryptoViewModel Crypto { get; set; }
        public async Task OnGet()
        {

        }

        public async Task<IActionResult> OnPost()
        {


            if (Crypto != null)
            {
                ErrorMessage = "Try Searching for something else";
                //La in de här för att kunna köra programmet. Ta bort sen /Otto
                throw new Exception();
            }
            try
            {

            }
            catch (Exception ex)
            {
                ErrorMessage = ex.Message;
            }
            //La in de här för att kunna köra programmet. Ta bort sen /Otto
            throw new Exception();

        }
    }
}