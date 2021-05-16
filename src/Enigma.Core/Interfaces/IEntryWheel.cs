namespace Enigma.Core.Interfaces
{
    public interface IEntryWheel
    {
        string BaseSequence { get; }
        string WiredSequence { get; }
        int PositionFrom { get; }
        int PositionTo { get; }
        char ValueFrom { get; }
        char ValueTo { get; }
        int Process(int position);
        int ProcessReflection(int position);
        char GetValueByPosition(int position);
    }
}