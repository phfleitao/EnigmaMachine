using Enigma.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Enigma.MachineEnigmaI
{
    public class EnigmaILog : IEnigmaLog
    {
        public Guid Id { get; private set; }
        public int IterationNumber { get; private set; }
        public DateTime CreateDate { get; set; }

        private IList<IEnigmaLogStep> _steps;
        public IReadOnlyCollection<IEnigmaLogStep> Steps => _steps.ToList().AsReadOnly();

        public EnigmaILog(int iterationNumber = 0)
        {
            _steps = new List<EnigmaILogStep>().ToList<IEnigmaLogStep>();

            Id = Guid.NewGuid();
            IterationNumber = iterationNumber;
            CreateDate = DateTime.UtcNow;
        }

        public void AddStep(IEnigmaLogStep step)
        {
            _steps.Add(step);
        }
    }
}
