namespace Enigma.Core.Interfaces
{
    public interface IRotorEngine
    {
        char RingSetting { get; }
        char DisplayWindow { get; }
        string BaseSequence { get; }
        string WiredSequence { get; }
        char[] TurnOverNotch { get; }
        void ConfigureOutterRingSetting(char outterRingSettingCharacter);
        void ConfigureInnerRingSetting(char innerRingSettingCharacter);
        void RotateLeft();
        void RotateRight();
    }
}