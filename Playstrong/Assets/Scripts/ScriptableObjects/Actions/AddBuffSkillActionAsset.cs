using System.Collections;
using Interfaces;
using Logic;
using ScriptableObjects.Actions.BaseClassScripts;
using ScriptableObjects.Others;
using ScriptableObjects.StatusEffects;
using UnityEngine;
using Utilities;

namespace ScriptableObjects.SkillActions
{
    [CreateAssetMenu(fileName = "AddBuffSkillActionAsset", menuName = "SO's/SkillActions/AddBuffSkillActionAsset")]
    
    public class AddBuffSkillActionAsset : SkillActionAsset, IAddBuffSkillActionAsset
    {

        [SerializeField]
        [RequireInterface(typeof(IStatusEffectAsset))]
        private ScriptableObject _buffEffectAsset;
        private IStatusEffectAsset BuffAsset => _buffEffectAsset as IStatusEffectAsset;

        [SerializeField] private int _buffCounters;
        private int BuffCounters => _buffCounters;
        
        
        private IHero _hero;
        private ICoroutineTree _logicTree;
        private ICoroutineTree _visualTree;

        /// <summary>
        /// Logic of AddBuff is in the statuseffect asset Instance
        /// Single, Multiple, Fixed
        /// </summary>
        public override IEnumerator ActionTarget(IHero thisHero, IHero targetHero)
        {
            _logicTree = targetHero.CoroutineTreesAsset.MainLogicTree;
            _visualTree = targetHero.CoroutineTreesAsset.MainVisualTree;

            _logicTree.AddCurrent(AddBuffCoroutine(targetHero, BuffAsset, BuffCounters));
           
            _logicTree.EndSequence();
           yield return null;

        }
        
        //TODO: Insert StartAction Here

        private IEnumerator AddBuffCoroutine(IHero hero, IStatusEffectAsset statusEffectAsset, int statusEffectCounters)
        {
             BuffAsset.StatusEffectInstance.AddStatusEffect(hero, statusEffectAsset, statusEffectCounters);
            
             _logicTree.EndSequence();
            yield return null;
        }



      


    }
}
