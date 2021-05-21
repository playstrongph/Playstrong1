using ScriptableObjects.Enums;
using UnityEngine;
using Utilities;

namespace Logic
{
    public class TargetStatusOptions : MonoBehaviour, ITargetStatusOptions
    {
        [SerializeField] [RequireInterface(typeof(ITauntTargetAsset))]
        private ScriptableObject _tauntTarget;
        public ITargetStatus TauntTarget => _tauntTarget as ITargetStatus;

        [SerializeField] [RequireInterface(typeof(INormalTargetAsset))]
        private ScriptableObject _normalTarget;
        public ITargetStatus NormalTarget => _normalTarget as ITargetStatus;

        [SerializeField] [RequireInterface(typeof(IStealthTargetAsset))]
        private ScriptableObject _stealthTarget;
        public ITargetStatus StealthTarget => _stealthTarget as ITargetStatus;


    }
}
