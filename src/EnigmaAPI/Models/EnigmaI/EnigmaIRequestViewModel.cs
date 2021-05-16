using System.ComponentModel.DataAnnotations;

namespace EnigmaAPI.Models.EnigmaI
{
    public class EnigmaIRequestViewModel
    {
        [Required(ErrorMessage = "Required Field!")]
        public string Text { get; set; }
        public Settings Settings { get; set; }

        public EnigmaIRequestViewModel() : this(string.Empty) { }
        public EnigmaIRequestViewModel(string text, Settings settings = null)
        {
            Text = text;
            Settings = (settings != null) ? settings : new Settings();
        }
    }
}
