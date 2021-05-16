namespace Enigma.Core.Interfaces
{
    public interface IReflector
    {
        string BaseSequence { get; }
        string WiredSequence { get; }
        int PositionFrom { get; }
        int PositionTo { get; }
        char ValueFrom { get; }
        char ValueTo { get; }
        int Reflect(int inputPosition);
    }
}