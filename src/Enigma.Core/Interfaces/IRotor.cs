namespace Enigma.Core.Interfaces
{
    public interface IRotor
    {
        char RingSetting { get; }
        char DisplayWindow { get; }
        string BaseSequence { get; }
        string WiredSequence { get; }
        char[] TurnOverNotch { get; }
        bool IsTurnedOver { get; }
        int PositionFrom { get; }
        int PositionTo { get; }
        char ValueFrom { get; }
        char ValueTo { get; }
        int Process(int position, bool hasToRotate);
        int ProcessReflection(int position);

        void ConfigureOutterRingSetting(char outterRingSettingCharacter);
        void ConfigureInnerRingSetting(char innerRingSettingCharacter);
    }
}