using Enigma.Core.Interfaces;

namespace Enigma.MachineEnigmaI.Rotors
{
    public class RotorVI : RotorBase
    {
        private const string DEFAULT_WIREDSEQUENCE = "JPGVOUMFYQBENHZRDKASXLICTW";
        private const string DEFAULT_TURNOVER_NOTCH = "Z+M";
            
        public RotorVI() : base(DEFAULT_WIREDSEQUENCE, DEFAULT_TURNOVER_NOTCH){ }

        public RotorVI(IRotorEngine rotorEngine) : base(rotorEngine) { }
    }
}