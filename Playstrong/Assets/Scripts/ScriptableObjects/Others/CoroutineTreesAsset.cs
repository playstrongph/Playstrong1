using Interfaces;
using UnityEngine;

namespace ScriptableObjects.Others
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
