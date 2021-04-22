using System.Collections;
using UnityEngine;

namespace Logic
{
    public class BranchLogic : MonoBehaviour, IBranchLogic
    {
        public IEnumerator Wait(float seconds)
        {
            yield return new WaitForSeconds(seconds);
            yield return null;

        }
    }
}
