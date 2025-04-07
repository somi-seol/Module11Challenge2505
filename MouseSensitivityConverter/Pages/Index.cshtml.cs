using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Data.Sqlite;
using MouseSensitivityConverter.Models; // ack ;-;

namespace MouseSensitivityConverter.Pages
{
    public class IndexModel : PageModel
    {
        // bind to input
        [BindProperty]
        public SensitivityInput Input { get; set; }

        // store games : rates
        public Dictionary<string, double> GameRates { get; set; }

        private string _connectionString = "Data Source=data/sensitivities.db";

        public void OnGet()
        {
            LoadGameRates();
        }

        public IActionResult OnPost()
        {
            // data
            LoadGameRates();

            if (!ModelState.IsValid)
            {
                return Page();
            }

            // validation
            if (GameRates.TryGetValue(Input.SelectedGame, out double rate))
            {
                Input.Result = rate / Input.CmPer360;
            }

            return Page();
        }

        // data reader
        private void LoadGameRates()
        {
            GameRates = new Dictionary<string, double>();

            using var connection = new SqliteConnection(_connectionString);
            connection.Open();

            var command = connection.CreateCommand();
            command.CommandText = "SELECT Game, Rate FROM SensitivityRates";

            // fill dict
            using var reader = command.ExecuteReader();
            while (reader.Read())
            {
                var game = reader.GetString(0);
                var rate = reader.GetDouble(1);
                GameRates[game] = rate;
            }
        }
    }
}
