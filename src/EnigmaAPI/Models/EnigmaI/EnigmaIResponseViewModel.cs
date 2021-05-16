using Enigma.Core.Interfaces;
using Enigma.MachineEnigmaI;
using EnigmaAPI.Enums;
using System.Collections.Generic;

namespace EnigmaAPI.Models.EnigmaI
{
    public class EnigmaIResponseViewModel
    {
        public ResponseStatus Status { get; set; }
        public string Text { get; set; }
        public string ConvertedText { get; set; }
        //public MachineState LastMachineState { get; set; }

        public IReadOnlyCollection<IEnigmaLog> Logs { get; set; }

        public EnigmaIResponseViewModel() { }
        public EnigmaIResponseViewModel(ResponseStatus status, string text, string convertedText, IReadOnlyCollection<IEnigmaLog> logs)
        {
            Status = status;
            Text = text;
            ConvertedText = convertedText;
            Logs = logs;
        }
    }
}
