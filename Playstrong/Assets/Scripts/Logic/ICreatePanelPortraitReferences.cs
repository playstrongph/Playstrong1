using System.Collections;
using Interfaces;

namespace Logic
{
    public interface ICreatePanelPortraitReferences
    {
        IEnumerator CreateReferences(ICoroutineTree tree);
    }
}