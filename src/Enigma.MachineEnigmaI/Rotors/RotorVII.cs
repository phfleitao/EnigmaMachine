using Enigma.Core.Interfaces;

namespace Enigma.MachineEnigmaI.Rotors
{
    public class RotorVII : RotorBase
    {
        private const string DEFAULT_WIREDSEQUENCE = "NZJHGRCXMYSWBOUFAIVLPEKQDT";
        private const string DEFAULT_TURNOVER_NOTCH = "Z+M";
            
        public RotorVII() : base(DEFAULT_WIREDSEQUENCE, DEFAULT_TURNOVER_NOTCH){ }

        public RotorVII(IRotorEngine rotorEngine) : base(rotorEngine) { }
    }
}