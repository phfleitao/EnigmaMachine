using Enigma.Core.Interfaces;

namespace Enigma.MachineEnigmaI.Reflectors
{
    public class ReflectorB : IReflector
    {
        private readonly string _baseSequence = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        private readonly string _reflectionSequence = "YRUHQSLDPXNGOKMIEBFZCWVJAT";

        public int Reflect(int inputPosition)
        {
            char reflectedCharacter = _reflectionSequence[inputPosition];
            return _baseSequence.IndexOf(reflectedCharacter);
        }
    }
}