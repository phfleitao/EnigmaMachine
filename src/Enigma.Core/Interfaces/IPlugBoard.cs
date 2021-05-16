namespace Enigma.Core.Interfaces
{
    public interface IPlugBoard
    {
        string BaseSequence { get; }
        string WiredSequence { get; }
        int PositionFrom { get; }
        int PositionTo { get; }
        char ValueFrom { get; }
        char ValueTo { get; }
        string Jumpers { get; }

        void Reset();
        int Process(char inputValue);
        char ProcessReflection(int position);
        void PlugJumpers(string jumpers);
    }
}
