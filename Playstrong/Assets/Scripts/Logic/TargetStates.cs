using ScriptableObjects.Enums;
using UnityEngine;
using Utilities;

namespace Logic
{
    public class TargetStates : MonoBehaviour, ITargetStates
    {
        [SerializeField] [RequireInterface(typeof(ITauntTargetAsset))]
        private ScriptableObject _tauntTarget;
        public ITargetStates TauntTarget => _tauntTarget as ITargetStates;

        [SerializeField] [RequireInterface(typeof(INormalTargetAsset))]
        private ScriptableObject _normalTarget;
        public ITargetStates NormalTarget => _normalTarget as ITargetStates;

        [SerializeField] [RequireInterface(typeof(IStealthTargetAsset))]
        private ScriptableObject _stealthTarget;
        public ITargetStates StealthTarget => _stealthTarget as ITargetStates;


    }
}
