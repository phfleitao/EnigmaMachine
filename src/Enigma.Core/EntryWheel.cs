using Enigma.Core.Interfaces;

namespace Enigma.Core
{
    public class EntryWheel : IEntryWheel
    {
        private readonly string _sequence = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";

        public int Process(int position)
        {
            return position;
        }

        public int ProcessReflection(int position)
        {
            return position;
        }

        public char GetValueByPosition(int position)
        {
            return _sequence[position];
        }
    }
}