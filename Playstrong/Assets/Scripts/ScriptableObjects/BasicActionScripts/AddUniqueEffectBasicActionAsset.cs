using System.Collections;
using Interfaces;
using Logic;
using ScriptableObjects.SkillActionsScripts.BaseClassScripts;
using ScriptableObjects.StatusEffects;
using UnityEngine;
using Utilities;
using Visual;

namespace ScriptableObjects.SkillActionsScripts
{
    [CreateAssetMenu(fileName = "AddUniqueEffect", menuName = "SO's/BasicActions/A/AddUniqueEffect")]
    
    public class AddUniqueEffectBasicActionAsset : BasicActionAsset
    {

        [SerializeField]
        [RequireInterface(typeof(IStatusEffectAsset))]
        private ScriptableObject _uniqueEffectAsset;
        private IStatusEffectAsset UniqueEffectAsset => _uniqueEffectAsset as IStatusEffectAsset;

        [SerializeField] private int _uniqueEffectCounters;
        private int UniqueEffectCounters => _uniqueEffectCounters;

        
        public override IEnumerator TargetAction(IHero thisHero, IHero targetHero)
        {
            Debug.Log("Add Unique Effect");
            
            var logicTree = thisHero.CoroutineTreesAsset.MainLogicTree;
            
            logicTree.AddCurrent(AddUniqueEffectCoroutine(UniqueEffectAsset, UniqueEffectCounters,thisHero,targetHero));
            
            logicTree.EndSequence();
            yield return null;
        }
        
        public override IEnumerator TargetAction(IHero targetHero)
        {
            Debug.Log("Add Unique Effect");
            
            var logicTree = targetHero.CoroutineTreesAsset.MainLogicTree;
            
            logicTree.AddCurrent(AddUniqueEffectCoroutine(UniqueEffectAsset, UniqueEffectCounters,targetHero,targetHero));
            
            logicTree.EndSequence();
            yield return null;
        }

        private IEnumerator AddUniqueEffectCoroutine(IStatusEffectAsset statusEffectAsset, int statusEffectCounters, IHero thisHero, IHero targetHero)
        {
            
            Debug.Log("Add Unique Effect Coroutine");
            
            var logicTree = thisHero.CoroutineTreesAsset.MainLogicTree;
            
            //Note: No need to check for resistances and chances for uniqueEffect - can't be prevented
            
            UniqueEffectAsset.StatusEffectInstance.AddStatusEffect(targetHero, statusEffectAsset, statusEffectCounters,thisHero);
            
            logicTree.EndSequence();
            yield return null;
        }



      


    }
}
