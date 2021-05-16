using Enigma.Core;
using Enigma.Core.Exceptions;
using Enigma.Core.Interfaces;
using Enigma.MachineEnigmaI.Reflectors;
using Enigma.MachineEnigmaI.Rotors;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

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
        private IList<IEnigmaLog> _enigmaLogs;
        public IReadOnlyCollection<IEnigmaLog> Logs => _enigmaLogs.ToList().AsReadOnly();
        
        private IEnigmaLog _enigmaLog;

        public EnigmaI()
        {
            _enigmaLogs = new List<EnigmaILog>().ToList<IEnigmaLog>();
            _entryWheel = new EntryWheel();
            _plugBoard = new PlugBoard();
            _fastRotor = new RotorI();
            _middleRotor = new RotorII();
            _slowRotor = new RotorIII();
            _reflector = new ReflectorB();
        }

        public EnigmaI(IRotor slowRotor, IRotor middleRotor, IRotor fastRotor, IReflector reflector)
        {
            _enigmaLogs = new List<EnigmaILog>().ToList<IEnigmaLog>();
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
            _enigmaLog = new EnigmaILog(0);
            var convertedValue = ProcessConversion(input);
            _enigmaLogs.Add(_enigmaLog);

            return convertedValue;
        }

        public string WriteText(string inputText)
        {
            inputText = inputText.ToUpper();
            string processedText = "";
            for (int i = 0; i < inputText.Length; i++)
            {
                _enigmaLog = new EnigmaILog(i);

                var convertedValue = ProcessConversion(inputText[i]);
                processedText += convertedValue;

                _enigmaLogs.Add(_enigmaLog);
            }

            return processedText;
        }

        private static void ValidateInputText(string input)
        {
            var regex = new Regex(@"^([A-Z])*$");
            if (!regex.IsMatch(input))
                throw new EnigmaException($"Invalid text input!");
        }

        private char ProcessConversion(char input)
        {
            input = char.ToUpper(input);
            ValidateInputText(input.ToString());

            return ProcessConversionFlow(input);
        }

        private char ProcessConversionFlow(char input)
        {
            int step = 0;
            
            int position = _plugBoard.Process(input);
            LogPlugBoardStep(step++, "PlugBoard Processed", _plugBoard);

            position = _entryWheel.Process(position);
            LogEntryWheelStep(step++, "EntryWheel Processed", _entryWheel);

            position = _fastRotor.Process(position, true);
            LogRotorStep(step++, "FastRotor Processed", _fastRotor);
            
            position = _middleRotor.Process(position, _fastRotor.IsTurnedOver);
            LogRotorStep(step++, "MiddleRotor Processed", _middleRotor);

            position = _slowRotor.Process(position, _middleRotor.IsTurnedOver);
            LogRotorStep(step++, "SlowRotor Processed", _slowRotor);

            position = _reflector.Reflect(position);
            LogReflectorStep(step++, "Reflector Processed", _reflector);

            position = _slowRotor.ProcessReflection(position);
            LogRotorStep(step++, "SlowRotor Reflection Processed", _slowRotor);

            position = _middleRotor.ProcessReflection(position);
            LogRotorStep(step++, "MiddleRotor Reflection Processed", _middleRotor);

            position = _fastRotor.ProcessReflection(position);
            LogRotorStep(step++, "FastRotor Reflection Processed", _fastRotor);

            position = _entryWheel.ProcessReflection(position);
            LogEntryWheelStep(step++, "EntryWheel Reflection Processed", _entryWheel);

            var outputValue = _plugBoard.ProcessReflection(position);
            LogPlugBoardStep(step++, "PlugBoard Reflection Processed", _plugBoard);

            return outputValue;
        }

        private void LogRotorStep(int step, string description, IRotor rotor)
        {
            var logBuilder = new EnigmaILogStepBuilder();
            var logStep = logBuilder.WithStep(step)
                                    .WithStepDescription(description)
                                    .WithPositionFrom(rotor.PositionFrom)
                                    .WithPositionTo(rotor.PositionTo)
                                    .WithValueFrom(rotor.ValueFrom)
                                    .WithValueTo(rotor.ValueTo)
                                    .WithSequence(rotor.BaseSequence)
                                    .WithWiredSequence(rotor.WiredSequence)
                                    .WithTurnOverNotch(rotor.TurnOverNotch)
                                    .WithDisplayWindow(rotor.DisplayWindow)
                                    .WithRingSetting(rotor.RingSetting)
                                    .Build();
            
            _enigmaLog.AddStep(logStep);
        }

        private void LogReflectorStep(int step, string description, IReflector reflector)
        {
            var logBuilder = new EnigmaILogStepBuilder();
            var logStep = logBuilder.WithStep(step)
                                    .WithStepDescription(description)
                                    .WithPositionFrom(reflector.PositionFrom)
                                    .WithPositionTo(reflector.PositionTo)
                                    .WithValueFrom(reflector.ValueFrom)
                                    .WithValueTo(reflector.ValueTo)
                                    .WithSequence(reflector.BaseSequence)
                                    .WithWiredSequence(reflector.WiredSequence)
                                    .Build();

            _enigmaLog.AddStep(logStep);
        }

        private void LogPlugBoardStep(int step, string description, IPlugBoard plugBoard)
        {
            var logBuilder = new EnigmaILogStepBuilder();
            var logStep = logBuilder.WithStep(step)
                                    .WithStepDescription(description)
                                    .WithPositionFrom(plugBoard.PositionFrom)
                                    .WithPositionTo(plugBoard.PositionTo)
                                    .WithValueFrom(plugBoard.ValueFrom)
                                    .WithValueTo(plugBoard.ValueTo)
                                    .WithSequence(plugBoard.BaseSequence)
                                    .WithWiredSequence(plugBoard.WiredSequence)
                                    .WithJumpers(plugBoard.Jumpers)
                                    .Build();

            _enigmaLog.AddStep(logStep);
        }

        private void LogEntryWheelStep(int step, string description, IEntryWheel entryWheel)
        {
            var logBuilder = new EnigmaILogStepBuilder();
            var logStep = logBuilder.WithStep(step)
                                    .WithStepDescription(description)
                                    .WithPositionFrom(entryWheel.PositionFrom)
                                    .WithPositionTo(entryWheel.PositionTo)
                                    .WithValueFrom(entryWheel.ValueFrom)
                                    .WithValueTo(entryWheel.ValueTo)
                                    .WithSequence(entryWheel.BaseSequence)
                                    .WithWiredSequence(entryWheel.WiredSequence)
                                    .Build();

            _enigmaLog.AddStep(logStep);
        }
    }
}