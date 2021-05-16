using System;
using System.Linq;
using Enigma.Core.Interfaces;

namespace Enigma.Core
{
    public class RotorEngine : IRotorEngine
    {
        private readonly char defaultInnerRingSettingCharacter;
        private readonly string defaultBaseSequence;
        private readonly string defaultWiredSequence;
        public char RingSetting { get; private set; }
        public char DisplayWindow => BaseSequence[0];
        public string BaseSequence { get; private set; }
        public string WiredSequence { get; private set; }
        public char[] TurnOverNotch { get; private set; }

        public RotorEngine(char innerRingSettingCharacter, string baseSequence, string wiredSequence, string turnOverNotch)
        {
            defaultInnerRingSettingCharacter = innerRingSettingCharacter;
            defaultBaseSequence = baseSequence;
            defaultWiredSequence = wiredSequence;
            RingSetting = defaultInnerRingSettingCharacter;
            BaseSequence = defaultBaseSequence;
            WiredSequence = defaultWiredSequence;
            ConvertStringToTurnOverNotchArray(turnOverNotch);
        }
        public void ConfigureOutterRingSetting(char outterRingSettingCharacter)
        {
            char actualValue = BaseSequence[0];
            while(actualValue != outterRingSettingCharacter){
                RotateLeft();
                actualValue = BaseSequence[0];
            }
        }
        public void ConfigureInnerRingSetting(char innerRingSettingCharacter)
        {
            innerRingSettingCharacter = Char.ToUpper(innerRingSettingCharacter);

            ResetRingSettings();

            var innerRingSettingCharacterIndex = BaseSequence.IndexOf(innerRingSettingCharacter);
            var dotPosition = WiredSequence.IndexOf(RingSetting);
                            
            for (var i = 0; i < innerRingSettingCharacterIndex; i++)
            {
                WiredSequence = ShiftUp(WiredSequence, 1);

                // Add one to dot position, make sure we don't exceed the lenght of the alphabet
                dotPosition = (dotPosition + 1) % BaseSequence.Length;
            }
            // While the letter at the dot position doesn't match with the ringstellung
            while(WiredSequence[dotPosition] != BaseSequence[innerRingSettingCharacterIndex])
            {
                WiredSequence = RotateRight(WiredSequence, 1);
            }
        }       
        public void RotateRight()
        {
            BaseSequence = RotateRight(BaseSequence, 1);
            WiredSequence = RotateRight(WiredSequence, 1);
        }

        public void RotateLeft()
        {
            BaseSequence = RotateLeft(BaseSequence, 1);
            WiredSequence = RotateLeft(WiredSequence, 1);
        }

        private void ResetRingSettings(){
            RingSetting = defaultInnerRingSettingCharacter;
            BaseSequence = defaultBaseSequence;
            WiredSequence = defaultWiredSequence;
        }
        private static string RotateLeft(string sequence, int count)
        {
            return sequence[count..] + sequence[..count];
        }
        private static string RotateRight(string sequence, int count)
        {
            return sequence[^count..] + sequence[..^count];
        }
        private string ShiftUp(string sequence, int count)
        {
            string shiftedSequence = "";
            foreach (var character in sequence)
            {
                int characterIndex = BaseSequence.IndexOf(character);
                int shiftedCharacterIndex = (characterIndex+count) % BaseSequence.Length;
                char shiftedCharacter = BaseSequence[shiftedCharacterIndex];

                shiftedSequence += shiftedCharacter.ToString();
            }                
            return shiftedSequence;
        }

        private void ConvertStringToTurnOverNotchArray(string value){
            var characters = value.Split('+');
            TurnOverNotch = String.Join("", characters).ToCharArray();
        }
    }
}