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
            InitLogicTree();
            InitVisualTree();
           
        }

        private void InitLogicTree()
        {
            LogicTree = new CoroutineTree();
            LogicTree.CoroutineRunner(this);
            LogicTree.Start();
            LogicTree.AddRoot(LogicTreeMain());
            
        }

        private void InitVisualTree()
        {
            VisualTree = new CoroutineTree();
            VisualTree.CoroutineRunner(this);
            VisualTree.Start();
            VisualTree.AddRoot(VisualTreeMain());
        }

        private IEnumerator LogicTreeMain()
        {
            yield return null;
            LogicTree.EndSequence();
        }
        
        private IEnumerator VisualTreeMain()
        {
            yield return null;
            VisualTree.EndSequence();
        }


        public IEnumerator Wait(float seconds)
        {
            yield return new WaitForSeconds(seconds);
            yield return null;

        }
    }
}
