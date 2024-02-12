using CryptoScanner.Data.Models;
using System.Globalization;
using System.Text.RegularExpressions;

namespace CryptoScanner.App
{
    public static class CryptoService
    {

        public static List<CryptoViewModel> SortByNameAscending(List<CryptoViewModel> unsortedList)
        {
            return unsortedList.OrderBy(x => x.Name).ToList();
        }

        public static List<CryptoViewModel> SortByNameDescending(List<CryptoViewModel> unsortedList)
        {
            return unsortedList.OrderByDescending(x => x.Name).ToList();
        }

        public static List<CryptoViewModel> SortByPrice(List<CryptoViewModel> unsortedList)
        {
            return unsortedList.OrderBy(x => x.Price).ToList();
        }

        public static List<CryptoViewModel> SortByPriceDescending(List<CryptoViewModel> unsortedList)
        {
            return unsortedList.OrderByDescending(x => x.Price).ToList();
        }

        public static string ConvertToSnakeCase(string input)
        {
            // Ersätt mellanslag med bindestreck och konvertera till små bokstäver
            return Regex.Replace(input, @"\s+", "-").ToLowerInvariant();
        }

        public static string ConvertToTitleCase(string input)
        {
            // Ersätt bindestreck med mellanslag och använd Title Case
            TextInfo textInfo = new CultureInfo("en-US", false).TextInfo;
            return textInfo.ToTitleCase(input.Replace("-", " "));
        }
    }
}