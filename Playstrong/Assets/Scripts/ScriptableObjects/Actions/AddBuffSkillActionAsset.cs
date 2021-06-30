using System.Collections;
using Interfaces;
using Logic;
using ScriptableObjects.Others;
using ScriptableObjects.SkillActions.BaseClassScripts;
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

        /// <summary>
        /// Logic of AddBuff is in the statuseffect asset Instance
        /// Single, Multiple, Fixed
        /// </summary>
        public override void Target(IHero hero, ICoroutineTreesAsset coroutineTreesAsset)
        {
           LogicTree = coroutineTreesAsset.MainLogicTree;

           LogicTree.AddCurrent(AddBuffCoroutine(hero, BuffAsset, BuffCounters));

        }

        private IEnumerator AddBuffCoroutine(IHero hero, IStatusEffectAsset statusEffectAsset, int statusEffectCounters)
        {
            BuffAsset.StatusEffectInstance.AddStatusEffect(hero, statusEffectAsset, statusEffectCounters);
            
            LogicTree.EndSequence();
            yield return null;
        }



      


    }
}
