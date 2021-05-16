using System.Collections.Generic;

namespace Enigma.Core.Interfaces
{
    public interface IEnigma
    {
        IReadOnlyCollection<IEnigmaLog> Logs { get; }
        void ConfigureOutterRingSetting(char slowRotorSetting, char middleRotorSetting, char fastRotorSetting);
        void ConfigureInnerRingSetting(char slowRotorSetting, char middleRotorSetting, char fastRotorSetting);
        void ConfigurePlugBoard(string plugBoardJumpers);
        char Write(char input);
        string WriteText(string inputText);
    }
}