namespace Enigma.Core.Interfaces
{
    public interface IEntryWheel
    {
        int Process(int position);
        int ProcessReflection(int position);
        char GetValueByPosition(int position);
    }
}