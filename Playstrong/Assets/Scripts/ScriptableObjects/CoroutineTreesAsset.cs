using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Interfaces;
using Logic;
using UnityEngine;
using Utilities;
using Object = UnityEngine.Object;

namespace ScriptableObjects
{
    [CreateAssetMenu(fileName = "CoroutineTrees", menuName = "SO's/Coroutine Trees")]
    public class CoroutineTreesAsset : ScriptableObject, ICoroutineTreesAsset
    {
        private ICoroutineTree _logicTree;

        public ICoroutineTree MainLogicTree
        {
            get => _logicTree;
            set => _logicTree = value;
        }
        
        
        private ICoroutineTree _visualTree;

        public ICoroutineTree MainVisualTree
        {
            get => _visualTree;
            set => _visualTree = value;
        }
        
        /*private void Awake()
        {
            //_logicTree= new CoroutineTree();
            //_visualTree = new CoroutineTree();

        }
      
        public void InitTrees(MonoBehaviour mono)
        {
           
            MainLogicTree.CoroutineRunner(mono);
            MainLogicTree.Start();
            MainLogicTree.AddRoot(MainLogicRoot());

            
            MainVisualTree.CoroutineRunner(mono);
            MainVisualTree.Start();
            MainVisualTree.AddRoot(MainVisualRoot());
        }

        private IEnumerator MainLogicRoot()
        {
            yield return null;
            MainLogicTree.EndSequence();
        }

        private IEnumerator MainVisualRoot()
        {
            yield return null;
            MainVisualTree.EndSequence();
        }*/

    }
}
