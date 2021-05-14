using Enigma.Core;
using Enigma.Core.Interfaces;
using Enigma.MachineEnigmaI.Reflectors;
using Enigma.MachineEnigmaI.Rotors;

namespace Enigma.MachineEnigmaI
{
    public class EnigmaI : IEnigma
    {
        private readonly IEntryWheel _entryWheel;
        private readonly IPlugBoard _plugBoard;
        private readonly IRotor _slowRotor;
        private readonly IRotor _middleRotor;
        private readonly IRotor _fastRotor;        
        private readonly IReflector _reflector;
        public EnigmaI()
        {
            _entryWheel = new EntryWheel();
            _plugBoard = new PlugBoard();
            _fastRotor = new RotorI();
            _middleRotor = new RotorII();
            _slowRotor = new RotorIII();
            _reflector = new ReflectorB();
        }

        public EnigmaI(IRotor slowRotor, IRotor middleRotor, IRotor fastRotor, IReflector reflector)
        {
            _entryWheel = new EntryWheel();
            _plugBoard = new PlugBoard();

            _slowRotor = slowRotor;
            _middleRotor = middleRotor;
            _fastRotor = fastRotor;

            _reflector = reflector;
        }

        public void ConfigureOutterRingSetting(char slowRotorSetting, char middleRotorSetting, char fastRotorSetting)
        {
            _slowRotor.ConfigureOutterRingSetting(slowRotorSetting);
            _middleRotor.ConfigureOutterRingSetting(middleRotorSetting);
            _fastRotor.ConfigureOutterRingSetting(fastRotorSetting);           
        }

        public void ConfigureInnerRingSetting(char slowRotorSetting, char middleRotorSetting, char fastRotorSetting)
        {
            _slowRotor.ConfigureInnerRingSetting(slowRotorSetting);
            _middleRotor.ConfigureInnerRingSetting(middleRotorSetting);
            _fastRotor.ConfigureInnerRingSetting(fastRotorSetting);
        }

        public void ConfigurePlugBoard(string plugBoardJumpers)
        {
            _plugBoard.PlugJumpers(plugBoardJumpers);
        }

        public char Write(char input)
        {
            return ProcessConversionFlow(input);
        }

        public string WriteText(string inputText)
        {
            string processedText = "";
            for (int i = 0; i < inputText.Length; i++)
            {
                processedText += Write(inputText[i]).ToString();
            }

            return processedText;
        }

        private char ProcessConversionFlow(char input){

            int position = _plugBoard.Process(input);
            position = _entryWheel.Process(position);
            position = _fastRotor.Process(position, true);
            position = _middleRotor.Process(position, _fastRotor.IsTurnedOver);
            position = _slowRotor.Process(position, _middleRotor.IsTurnedOver);

            position = _reflector.Reflect(position);

            position = _slowRotor.ProcessReflection(position);
            position = _middleRotor.ProcessReflection(position);
            position = _fastRotor.ProcessReflection(position);
            position = _entryWheel.ProcessReflection(position);
            var outputValue = _plugBoard.ProcessReflection(position);

            return outputValue;
        }
    }
}