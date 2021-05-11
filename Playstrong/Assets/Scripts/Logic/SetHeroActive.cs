using System.Collections;
using Interfaces;
using UnityEngine;

namespace Logic
{
    public class SetHeroActive : MonoBehaviour, ISetHeroActive
    {
        public IEnumerator SetActive(ICoroutineTree logicTree)
        {
            
            
            yield return null;
            logicTree.EndSequence();
        }

    }
}
