namespace Enigma.Core.Interfaces
{
    public interface IPlugBoard
    {
        void Reset();
        int Process(char inputValue);
        char ProcessReflection(int position);
        void PlugJumpers(string jumpers);
    }
}
