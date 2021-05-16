using Enigma.Core.Interfaces;
using Enigma.MachineEnigmaI.Rotors;
using EnigmaAPI.Enums.EnigmaI;

namespace EnigmaAPI.Factories.EnigmaI
{
    public class RotorFactory
    {
        public static IRotor Create(Rotors rotors)
        {
            switch (rotors)
            {
                case Rotors.RotorI:
                    return new RotorI();
                case Rotors.RotorII:
                    return new RotorII();
                case Rotors.RotorIII:
                    return new RotorIII();
                case Rotors.RotorIV:
                    return new RotorIV();
                case Rotors.RotorV:
                    return new RotorV();
                case Rotors.RotorVI:
                    return new RotorVI();
                case Rotors.RotorVII:
                    return new RotorVII();
                case Rotors.RotorVIII:
                    return new RotorVIII();
            }
            return null;            
        }
    }
}
