namespace Enigma.Core.Interfaces
{
    public interface IEnigmaLogStep
    {
        int Step { get; set; }
        string StepDescription { get; set; }
        int PositionFrom { get; set; }
        int PositionTo { get; set; }
        char ValueFrom { get; set; }
        char ValueTo { get; set; }
        string Sequence { get; set; }
        string WiredSequence { get; set; }
        
        //Rotor
        char[] TurnOverNotch { get; set; }
        char? RingSetting { get; set; }
        char? DisplayWindow { get; set; }
        
        //PlugBoard
        string Jumpers { get; set; }
    }
}