using System.ComponentModel.DataAnnotations;

namespace MouseSensitivityConverter.Models
{
    public class SensitivityInput
    {
        [Required(ErrorMessage = "please enter valid input")]
        [Range(0.1, 1000, ErrorMessage = "please enter valid input between 0.1 and 1000.")]
        public double CmPer360 { get; set; }

        [Required(ErrorMessage = "Please select a game.")]
        public string SelectedGame { get; set; }

        public double Result { get; set; }
    }
}
