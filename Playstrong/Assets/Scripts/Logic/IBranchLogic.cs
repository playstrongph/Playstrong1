using System.Collections;

namespace Logic
{
    public interface IBranchLogic
    {
        IEnumerator Wait(float seconds);

        ICoroutineTree LogicTree { get; }
        
        ICoroutineTree VisualTree { get; }
    }
}