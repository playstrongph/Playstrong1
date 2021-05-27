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
        [SerializeReference]
        private ICoroutineTree _logicTree;

        public ICoroutineTree MainLogicTree
        {
            get => _logicTree;
            set => _logicTree = value;
        }
        
        [SerializeReference]
        private ICoroutineTree _visualTree;

        public ICoroutineTree MainVisualTree
        {
            get => _visualTree;
            set => _visualTree = value;
        }

    }
}
