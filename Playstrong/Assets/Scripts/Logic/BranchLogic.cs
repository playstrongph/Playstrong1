using System;
using System.Collections;
using Interfaces;
using UnityEngine;
using Utilities;
using Object = UnityEngine.Object;

namespace Logic
{
    public class BranchLogic : MonoBehaviour, IBranchLogic
    {
        public ICoroutineTree LogicTree { get; private set; }

        public ICoroutineTree VisualTree { get; private set; }


        private void Awake()
        {
            LogicTree = new CoroutineTree();
            LogicTree.CoroutineRunner(this);
            
            VisualTree = new CoroutineTree();
            VisualTree.CoroutineRunner(this);

        }


        public IEnumerator Wait(float seconds)
        {
            yield return new WaitForSeconds(seconds);
            yield return null;

        }
    }
}
