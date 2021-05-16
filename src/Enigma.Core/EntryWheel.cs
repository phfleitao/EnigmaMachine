using Enigma.Core.Interfaces;

namespace Enigma.Core
{
    public class EntryWheel : IEntryWheel
    {
        private readonly string _sequence = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";

        public string BaseSequence { get; private set; }

        public string WiredSequence { get; private set; }

        public int PositionFrom { get; private set; }

        public int PositionTo { get; private set; }

        public char ValueFrom { get; private set; }

        public char ValueTo { get; private set; }

        public int Process(int position)
        {
            PositionFrom = position;
            PositionTo = position;
            ValueFrom = _sequence[position];
            ValueTo = _sequence[position];

            return position;
        }

        public int ProcessReflection(int position)
        {
            PositionFrom = position;
            PositionTo = position;
            ValueFrom = _sequence[position];
            ValueTo = _sequence[position];

            return position;
        }

        public char GetValueByPosition(int position)
        {
            return _sequence[position];
        }
    }
}