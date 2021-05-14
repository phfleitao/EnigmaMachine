using Enigma.Core.Interfaces;

namespace Enigma.MachineEnigmaI.Rotors
{
    public class RotorIV : RotorBase
    {
        private const string DEFAULT_WIREDSEQUENCE = "ESOVPZJAYQUIRHXLNFTGKDCMWB";
        private const string DEFAULT_TURNOVER_NOTCH = "J";
            
        public RotorIV() : base(DEFAULT_WIREDSEQUENCE, DEFAULT_TURNOVER_NOTCH){ }

        public RotorIV(IRotorEngine rotorEngine) : base(rotorEngine) { }
    }
}