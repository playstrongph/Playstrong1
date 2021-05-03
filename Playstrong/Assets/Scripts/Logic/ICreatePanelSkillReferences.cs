using System.Collections;
using Interfaces;

namespace Logic
{
    public interface ICreatePanelSkillReferences
    {
        IEnumerator CreateReferences(ICoroutineTree tree);
    }
}