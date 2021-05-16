using Enigma.Core.Interfaces;

namespace Enigma.MachineEnigmaI
{
    public class EnigmaILogStepBuilder : IEnigmaLogStepBuilder
    {
        private IEnigmaLogStep _enigmaLogStep;

        public EnigmaILogStepBuilder()
        {
            Reset();
        }
        public EnigmaILogStepBuilder(IEnigmaLogStep enigmaLogStep)
        {
            _enigmaLogStep = enigmaLogStep;
        }

        public void Reset()
        {
            _enigmaLogStep = new EnigmaILogStep();
        }

        public IEnigmaLogStep Build()
        {
            return _enigmaLogStep;
        }

        public IEnigmaLogStepBuilder WithStep(int step)
        {
            _enigmaLogStep.Step = step;
            return this;
        }

        public IEnigmaLogStepBuilder WithStepDescription(string stepDescription)
        {
            _enigmaLogStep.StepDescription = stepDescription;
            return this;
        }

        public IEnigmaLogStepBuilder WithPositionFrom(int positionFrom)
        {
            _enigmaLogStep.PositionFrom = positionFrom;
            return this;
        }
        public IEnigmaLogStepBuilder WithPositionTo(int positionTo)
        {
            _enigmaLogStep.PositionTo = positionTo;
            return this;
        }
        public IEnigmaLogStepBuilder WithValueFrom(char valueFrom)
        {
            _enigmaLogStep.ValueFrom = valueFrom;
            return this;
        }
        public IEnigmaLogStepBuilder WithValueTo(char valueTo)
        {
            _enigmaLogStep.ValueTo = valueTo;
            return this;
        }
        public IEnigmaLogStepBuilder WithSequence(string sequence)
        {
            _enigmaLogStep.Sequence = sequence;
            return this;
        }
        public IEnigmaLogStepBuilder WithWiredSequence(string wiredSequence)
        {
            _enigmaLogStep.WiredSequence = wiredSequence;
            return this;
        }
        public IEnigmaLogStepBuilder WithTurnOverNotch(char[] turnOverNotch)
        {
            _enigmaLogStep.TurnOverNotch = turnOverNotch;
            return this;
        }
        public IEnigmaLogStepBuilder WithRingSetting(char ringSetting)
        {
            _enigmaLogStep.RingSetting = ringSetting;
            return this;
        }
        public IEnigmaLogStepBuilder WithDisplayWindow(char displayWindow)
        {
            _enigmaLogStep.DisplayWindow = displayWindow;
            return this;
        }
        public IEnigmaLogStepBuilder WithJumpers(string jumpers)
        {
            _enigmaLogStep.Jumpers = jumpers;
            return this;
        }
    }
}
