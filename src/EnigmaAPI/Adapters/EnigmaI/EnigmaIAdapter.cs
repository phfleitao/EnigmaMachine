using EnigmaAPI.Factories.EnigmaI;
using EnigmaAPI.Models.EnigmaI;
using System;

namespace EnigmaAPI.Adapters.EnigmaI
{
    public static class EnigmaIAdapter
    {
        public static Enigma.MachineEnigmaI.EnigmaI ToEnigmaI(EnigmaIRequestViewModel request)
        {
            var reflectorType = request.Settings.Reflector;
            var reflector = ReflectorFactory.Create(reflectorType);

            var plugBoardJumpers = request.Settings.PlugBoardJumpers;

            var slowRotorType = request.Settings.SlowRotor.Rotor;
            var slowRotorRingSettings = Convert.ToChar(request.Settings.SlowRotor.RingSettings.ToString());
            var slowRotorDisplaySettings = Convert.ToChar(request.Settings.SlowRotor.DisplaySettings.ToString());
            var slowRotor = RotorFactory.Create(slowRotorType);

            var middleRotorType = request.Settings.MiddleRotor.Rotor;
            var middleRotorRingSettings = Convert.ToChar(request.Settings.MiddleRotor.RingSettings.ToString());
            var middleRotorDisplaySettings = Convert.ToChar(request.Settings.MiddleRotor.DisplaySettings.ToString());
            var middleRotor = RotorFactory.Create(middleRotorType);

            var fastRotorType = request.Settings.FastRotor.Rotor;
            var fastRotorRingSettings = Convert.ToChar(request.Settings.FastRotor.RingSettings.ToString());
            var fastRotorDisplaySettings = Convert.ToChar(request.Settings.FastRotor.DisplaySettings.ToString());
            var fastRotor = RotorFactory.Create(fastRotorType);

            var enigmaI = new Enigma.MachineEnigmaI.EnigmaI(slowRotor, middleRotor, fastRotor, reflector);
            enigmaI.ConfigureInnerRingSetting(slowRotorRingSettings, middleRotorRingSettings, fastRotorRingSettings);
            enigmaI.ConfigureOutterRingSetting(slowRotorDisplaySettings, middleRotorDisplaySettings, fastRotorDisplaySettings);
            enigmaI.ConfigurePlugBoard(plugBoardJumpers);

            return enigmaI;
        }
    }
}
