namespace Enigma.Core.Interfaces
{
    public interface IRotor
    {
        bool IsTurnedOver { get; }
        int Process(int position, bool hasToRotate);
        int ProcessReflection(int position);

        void ConfigureOutterRingSetting(char outterRingSettingCharacter);
        void ConfigureInnerRingSetting(char innerRingSettingCharacter);
    }
}