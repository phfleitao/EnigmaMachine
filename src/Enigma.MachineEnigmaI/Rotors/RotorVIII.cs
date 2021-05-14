using Enigma.Core.Interfaces;

namespace Enigma.MachineEnigmaI.Rotors
{
    public class RotorVIII : RotorBase
    {
        private const string DEFAULT_WIREDSEQUENCE = "FKQHTLXOCBJSPDZRAMEWNIUYGV";
        private const string DEFAULT_TURNOVER_NOTCH = "Z+M";
            
        public RotorVIII() : base(DEFAULT_WIREDSEQUENCE, DEFAULT_TURNOVER_NOTCH){ }

        public RotorVIII(IRotorEngine rotorEngine) : base(rotorEngine) { }
    }
}