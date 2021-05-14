using Enigma.Core.Interfaces;
using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace Enigma.Core
{
    public class PlugBoard : IPlugBoard
    {
        private readonly string _baseSequence = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        private string _wiredSequence = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        public string Jumpers { get; private set; }
        public string BaseSequence => _baseSequence;
        public string WiredSequence => _wiredSequence;

        public PlugBoard() { }
        public PlugBoard(string jumpers) 
        {
            PlugJumpers(jumpers);
        }

        public void Reset()
        {
            _wiredSequence = _baseSequence;
        }

        public int Process(char inputValue)
        {
            int position = _wiredSequence.IndexOf(inputValue);
            return position;
        }

        public char ProcessReflection(int position)
        {
            return _wiredSequence[position];
        }

        public void PlugJumpers(string jumpers)
        {
            Reset();
            ValidateJumpers(jumpers);
            Jumpers = jumpers;

            if (jumpers == "") return;

            var jumperList = Jumpers.Split(' ');
            foreach (var jumper in jumperList)
            {
                PlugJumper(jumper);
            }
        }

        private void PlugJumper(string jumper)
        {
            char leftChar = jumper[0];
            char rightChar = jumper[1];
            int positionLeftChar = _baseSequence.IndexOf(leftChar);
            int positionRightChar = _baseSequence.IndexOf(rightChar);

            ReplaceCharInWiredSequence(positionLeftChar, rightChar);
            ReplaceCharInWiredSequence(positionRightChar, leftChar);
        }
        private void ReplaceCharInWiredSequence(int position, char value)
        {
            _wiredSequence = _wiredSequence.Remove(position, 1);
            _wiredSequence = _wiredSequence.Insert(position, value.ToString());
        }

        private static void ValidateJumpers(string jumpers)
        {
            ValidateIfJumpersHasInvalidCharacters(jumpers);
            ValidateIfJumpersHasDuplicatedCharacters(jumpers);
        }
        private static void ValidateIfJumpersHasInvalidCharacters(string jumpers)
        {
            var regex = new Regex(@"^([a-zA-Z]{2}(\s?))+$");
            if (!regex.IsMatch(jumpers) && !string.IsNullOrEmpty(jumpers))
                throw new Exception($"Invalid input of jumpers");
        }
        private static void ValidateIfJumpersHasDuplicatedCharacters(string jumpers)
        {
            jumpers = jumpers.Replace(" ", "");
            var duplicates = jumpers.ToCharArray()
                                        .GroupBy(p => p)
                                        .Where(g => g.Count() > 1)
                                        .Select(g => g.Key)
                                        .ToList();
            if (duplicates.Count > 0)
                throw new Exception($"Cannot use the same character more than 1 time");
        }
    }
}