using Enigma.Core.Interfaces;

namespace Enigma.MachineEnigmaI.Rotors
{
    public class RotorIII : RotorBase
    {
        private const string DEFAULT_WIREDSEQUENCE = "BDFHJLCPRTXVZNYEIWGAKMUSQO";
        private const string DEFAULT_TURNOVER_NOTCH = "V";
            
        public RotorIII() : base(DEFAULT_WIREDSEQUENCE, DEFAULT_TURNOVER_NOTCH){ }

        public RotorIII(IRotorEngine rotorEngine) : base(rotorEngine) { }
    }
}