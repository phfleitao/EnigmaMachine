using Enigma.Core.Interfaces;

namespace Enigma.MachineEnigmaI.Reflectors
{
    public class ReflectorC : IReflector
    {
        private readonly string _baseSequence = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        private readonly string _reflectionSequence = "FVPJIAOYEDRZXWGCTKUQSBNMHL";

        public string BaseSequence { get; private set; }

        public string WiredSequence { get; private set; }

        public int PositionFrom { get; private set; }

        public int PositionTo { get; private set; }

        public char ValueFrom { get; private set; }

        public char ValueTo { get; private set; }

        public int Reflect(int inputPosition)
        {
            char reflectedCharacter = _reflectionSequence[inputPosition];
            var outputPosition = _baseSequence.IndexOf(reflectedCharacter);

            PositionFrom = inputPosition;
            PositionTo = outputPosition;
            ValueFrom = _baseSequence[inputPosition];
            ValueTo = reflectedCharacter;

            return outputPosition;
        }
    }
}