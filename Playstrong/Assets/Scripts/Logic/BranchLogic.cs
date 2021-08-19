using System;
using System.Collections;
using GameSettings;
using Interfaces;
using ScriptableObjects;
using UnityEngine;
using Utilities;
using Object = UnityEngine.Object;

namespace Logic
{
    public class BranchLogic : MonoBehaviour, IBranchLogic
    {
        public ICoroutineTree LogicTree { get; private set; }

        public ICoroutineTree VisualTree { get; private set; }

        private IBattleSceneSettings _battleSceneSettings;


        private void Awake()
        {
            _battleSceneSettings = GetComponent<IBattleSceneSettings>();
            
            InitGlobalLogicTree();
            InitGlobVisualTree();

        }
        
        
        private void InitGlobalLogicTree()
        {
            LogicTree = new CoroutineTree();
            LogicTree.CoroutineRunner(this);
            LogicTree.Start();
            LogicTree.AddRoot(LogicTreeMain());
            
            //Global Logic Tree
            _battleSceneSettings.CoroutineTreesAsset.MainLogicTree = LogicTree;
        }

        private void InitGlobVisualTree()
        {
            VisualTree = new CoroutineTree();
            VisualTree.CoroutineRunner(this);
            VisualTree.Start();
            VisualTree.AddRoot(VisualTreeMain());
            
            //Global Visual Tree
            _battleSceneSettings.CoroutineTreesAsset.MainVisualTree = VisualTree;
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
        
       
        public IEnumerator Wait(float seconds, ICoroutineTree tree)
        {
            yield return new WaitForSeconds(seconds);
            yield return StartCoroutine(InsertDelay(tree));
            
            yield return null;

        }
        
       
        private IEnumerator InsertDelay(ICoroutineTree tree)
        {
            tree.EndSequence();
            yield return null;
        }

    }
}
