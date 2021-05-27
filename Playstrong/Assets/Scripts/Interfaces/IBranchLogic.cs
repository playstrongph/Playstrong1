using System.Collections;

namespace Interfaces
{
    public interface IBranchLogic
    {
        IEnumerator Wait(float seconds, ICoroutineTree tre);

        ICoroutineTree LogicTree { get; }
        
        ICoroutineTree VisualTree { get; }
    }
}