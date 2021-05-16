using System;
using System.Collections.Generic;

namespace Enigma.Core.Interfaces
{
    public interface IEnigmaLog
    {
        Guid Id { get; }
        int IterationNumber { get; }
        DateTime CreateDate { get; }
        public IReadOnlyCollection<IEnigmaLogStep> Steps { get; }
        void AddStep(IEnigmaLogStep step);
    }
}