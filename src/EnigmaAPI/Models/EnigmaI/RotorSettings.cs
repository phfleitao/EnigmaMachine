using EnigmaAPI.Enums.EnigmaI;

namespace EnigmaAPI.Models.EnigmaI
{
    public class RotorSettings
    {
        public Rotors Rotor { get; set; }
        public Alphabet RingSettings { get; set; }
        public Alphabet DisplaySettings { get; set; }

        public RotorSettings() { }
        public RotorSettings(Rotors rotor) : this(rotor, Alphabet.A, Alphabet.A) { }
        public RotorSettings(Rotors rotor, Alphabet ringSettings, Alphabet displaySettings)
        {
            Rotor = rotor;
            RingSettings = ringSettings;
            DisplaySettings = displaySettings;
        }
    }
}
