using Enigma.Core.Interfaces;

namespace Enigma.MachineEnigmaI.Rotors
{
    public class RotorII : RotorBase
    {
        private const string DEFAULT_WIREDSEQUENCE = "AJDKSIRUXBLHWTMCQGZNPYFVOE";
        private const string DEFAULT_TURNOVER_NOTCH = "E";
            
         public RotorII() : base(DEFAULT_WIREDSEQUENCE, DEFAULT_TURNOVER_NOTCH){ }

        public RotorII(IRotorEngine rotorEngine) : base(rotorEngine) { }        
    }
}