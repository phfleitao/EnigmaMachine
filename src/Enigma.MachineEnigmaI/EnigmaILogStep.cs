using Enigma.Core.Interfaces;

namespace Enigma.MachineEnigmaI
{
    public class EnigmaILogStep : IEnigmaLogStep
    {
        public int Step { get; set; }
        public string StepDescription { get; set; }
        public int PositionFrom { get; set; }
        public int PositionTo { get; set; }
        public char ValueFrom { get; set; }
        public char ValueTo { get; set; }
        public string Sequence { get; set; }
        public string WiredSequence { get; set; }
        public char[] TurnOverNotch { get; set; }
        public char? RingSetting { get; set; }
        public char? DisplayWindow { get; set; }
        public string Jumpers { get; set; }
    }
}
