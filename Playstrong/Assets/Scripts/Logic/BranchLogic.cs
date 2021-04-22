using System;
using System.Collections;
using UnityEngine;
using Utilities;
using Object = UnityEngine.Object;

namespace Logic
{
    public class BranchLogic : MonoBehaviour, IBranchLogic
    {
        public ICoroutineTree LogicTree { get; set; }

        public ICoroutineTree VisualTree { get; set; }


        private void Awake()
        {
            LogicTree = new CoroutineTree();
            VisualTree = new CoroutineTree();
        }


        public IEnumerator Wait(float seconds)
        {
            yield return new WaitForSeconds(seconds);
            yield return null;

        }
    }
}
