using System.Linq;
using System;
using Enigma.Core;
using Enigma.Core.Interfaces;

namespace Enigma.MachineEnigmaI.Rotors
{
    public abstract class RotorBase : IRotor
    {
        private const char DEFAULT_RINGSETTINGS = 'A';
        private const string DEFAULT_SEQUENCE = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";

        protected readonly IRotorEngine _rotorEngine;
        public char RingSetting => _rotorEngine.RingSetting;
        public char DisplayWindow => _rotorEngine.DisplayWindow;
        public string BaseSequence => _rotorEngine.BaseSequence;
        public string WiredSequence => _rotorEngine.WiredSequence;
        public char[] TurnOverNotch => _rotorEngine.TurnOverNotch;
        public bool IsTurnedOver { get; protected set; } = false;
        public int PositionFrom { get; protected set; }
        public int PositionTo { get; protected set; }
        public char ValueFrom { get; protected set; }
        public char ValueTo { get; protected set; }

        public RotorBase(string defaultWiredSequence, string turnOverNotch)
        {
            _rotorEngine = new RotorEngine(DEFAULT_RINGSETTINGS, DEFAULT_SEQUENCE, defaultWiredSequence, turnOverNotch);
        }
        public RotorBase(IRotorEngine rotorEngine)
        {
            this._rotorEngine = rotorEngine;
        }
        public void ConfigureOutterRingSetting(char outterRingSettingCharacter)
        {
            _rotorEngine.ConfigureOutterRingSetting(outterRingSettingCharacter);
        }
        public void ConfigureInnerRingSetting(char innerRingSettingCharacter)
        {
            _rotorEngine.ConfigureInnerRingSetting(innerRingSettingCharacter);
        }

        public int Process(int position, bool hasToRotate)
        {
            ReconfigureTurnOver();
            if (hasToRotate || IsTurnedOver){
                _rotorEngine.RotateLeft();
            }               
                           
            char wiredValue = _rotorEngine.WiredSequence[position];
            int outputPosition = _rotorEngine.BaseSequence.IndexOf(wiredValue);

            PositionFrom = position;
            PositionTo = outputPosition;
            ValueFrom = _rotorEngine.BaseSequence[position];
            ValueTo = wiredValue;

            return outputPosition;
        }

        public int ProcessReflection(int position)
        {
            char reflectedValue = _rotorEngine.BaseSequence[position];
            int outputPosition = _rotorEngine.WiredSequence.IndexOf(reflectedValue);

            PositionFrom = position;
            PositionTo = outputPosition;
            ValueFrom = reflectedValue;
            ValueTo = _rotorEngine.BaseSequence[outputPosition];

            return outputPosition;
        }

        private void ReconfigureTurnOver(){
            if(_rotorEngine.TurnOverNotch.Contains(_rotorEngine.BaseSequence[0])){
                IsTurnedOver = true;
            }
            else
                IsTurnedOver = false;
        }
    }
}