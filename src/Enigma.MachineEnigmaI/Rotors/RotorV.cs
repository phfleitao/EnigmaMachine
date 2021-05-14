using Enigma.Core.Interfaces;

namespace Enigma.MachineEnigmaI.Rotors
{
    public class RotorV : RotorBase
    {
        private const string DEFAULT_WIREDSEQUENCE = "VZBRGITYUPSDNHLXAWMJQOFECK";
        private const string DEFAULT_TURNOVER_NOTCH = "Z";
            
        public RotorV() : base(DEFAULT_WIREDSEQUENCE, DEFAULT_TURNOVER_NOTCH){ }

        public RotorV(IRotorEngine rotorEngine) : base(rotorEngine) { }
    }
}