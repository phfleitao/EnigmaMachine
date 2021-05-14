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
        public bool IsTurnedOver { get; protected set; } = false;
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

            return outputPosition;
        }

        public int ProcessReflection(int position)
        {
            char reflectedValue = _rotorEngine.BaseSequence[position];
            int outputPosition = _rotorEngine.WiredSequence.IndexOf(reflectedValue);

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