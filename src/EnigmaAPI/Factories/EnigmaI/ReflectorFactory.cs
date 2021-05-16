using Enigma.Core.Interfaces;
using Enigma.MachineEnigmaI.Reflectors;
using EnigmaAPI.Enums.EnigmaI;

namespace EnigmaAPI.Factories.EnigmaI
{
    public class ReflectorFactory
    {
        public static IReflector Create(Reflectors reflectors)
        {
            switch (reflectors)
            {
                case Reflectors.ReflectorB:
                    return new ReflectorB();
                case Reflectors.ReflectorC:
                    return new ReflectorC();
            }
            return null;            
        }
    }
}
