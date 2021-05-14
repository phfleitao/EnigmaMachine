namespace Enigma.Core.Interfaces
{
    public interface IRotorEngine
    {
        char RingSettings { get; }
        string BaseSequence { get; }
        string WiredSequence { get; }
        char[] TurnOverNotch { get; }
        void ConfigureOutterRingSetting(char outterRingSettingCharacter);
        void ConfigureInnerRingSetting(char innerRingSettingCharacter);
        void RotateLeft();
        void RotateRight();
    }
}