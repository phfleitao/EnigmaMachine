using EnigmaAPI.Enums.EnigmaI;

namespace EnigmaAPI.Models.EnigmaI
{
    public class Settings
    {
        public Reflectors Reflector { get; set; }
        public string PlugBoardJumpers { get; set; }
        public RotorSettings SlowRotor { get; set; }
        public RotorSettings MiddleRotor { get; set; }
        public RotorSettings FastRotor { get; set; }

        public Settings()
        {
            ApplyDefaultSettings();
        }

        public Settings(Reflectors reflectorSettings, string plugBoardJumpers, RotorSettings slowRotorSettings, RotorSettings middleRotorSettings, RotorSettings fastRotorSettings)
        {
            Reflector = reflectorSettings;
            PlugBoardJumpers = plugBoardJumpers;
            SlowRotor = slowRotorSettings;
            MiddleRotor = middleRotorSettings;
            FastRotor = fastRotorSettings;
        }

        private void ApplyDefaultSettings()
        {
            Reflector = Reflectors.ReflectorB;
            PlugBoardJumpers = string.Empty;
            SlowRotor = new RotorSettings(Rotors.RotorIII);
            MiddleRotor = new RotorSettings(Rotors.RotorII);
            FastRotor = new RotorSettings(Rotors.RotorI);
        }
    }
}
