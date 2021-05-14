using Enigma.Core.Interfaces;

namespace Enigma.MachineEnigmaI.Rotors
{
    public class RotorI : RotorBase
    {
        private const string DEFAULT_WIREDSEQUENCE = "EKMFLGDQVZNTOWYHXUSPAIBRCJ";
        private const string DEFAULT_TURNOVER_NOTCH = "Q";
            
        public RotorI() : base(DEFAULT_WIREDSEQUENCE, DEFAULT_TURNOVER_NOTCH){ }

        public RotorI(IRotorEngine rotorEngine) : base(rotorEngine) { }
    }
}