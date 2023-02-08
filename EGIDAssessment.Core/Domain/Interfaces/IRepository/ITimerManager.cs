using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EGIDAssessment.Core.Domain.Interfaces.IRepository
{
    public interface ITimerManager
    {
         DateTime TimerStarted { get; set; }
         bool IsTimerStarted { get; set; }
        void PrepareTimer(Action action);
        void Execute(object? stateInfo);
    }
}
