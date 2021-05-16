namespace Enigma.Core.Interfaces
{
    public interface IEnigmaLogStepBuilder
    {
        void Reset();
        IEnigmaLogStep Build();
        IEnigmaLogStepBuilder WithStep(int step);
        IEnigmaLogStepBuilder WithStepDescription(string stepDescription);
        IEnigmaLogStepBuilder WithPositionFrom(int positionFrom);
        IEnigmaLogStepBuilder WithPositionTo(int positionTo);
        IEnigmaLogStepBuilder WithValueFrom(char valueFrom);
        IEnigmaLogStepBuilder WithValueTo(char valueTo);
        IEnigmaLogStepBuilder WithSequence(string sequence);
        IEnigmaLogStepBuilder WithWiredSequence(string wiredSequence);
        IEnigmaLogStepBuilder WithTurnOverNotch(char[] turnOverNotch);
        IEnigmaLogStepBuilder WithRingSetting(char ringSetting);
        IEnigmaLogStepBuilder WithDisplayWindow(char displayWindow);
        IEnigmaLogStepBuilder WithJumpers(string jumpers);
    }
}