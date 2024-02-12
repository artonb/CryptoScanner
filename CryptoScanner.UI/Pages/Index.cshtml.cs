using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CryptoScanner.UI.Pages
{
    public class IndexModel : PageModel
    {

        public string? ErrorMessage { get; set; }
        [BindProperty]
        public async Task OnGet()
        {

        }

        public async Task<IActionResult> OnPost()
        {
            if(Crypto !=null)
            {
                ErrorMessage = "Try Searching for something else";
            }
            try
            {

            }
            catch (Exception ex)
            {
              ErrorMessage = ex.Message; 
            }
        }
    }
}