using System.Collections;
using Interfaces;
using Logic;
using ScriptableObjects.SkillActionsScripts.BaseClassScripts;
using ScriptableObjects.StatusEffects;
using UnityEngine;
using Utilities;

namespace ScriptableObjects.SkillActionsScripts
{
    [CreateAssetMenu(fileName = "AddBuffAction", menuName = "SO's/BasicActions/AddBuffAction")]
    
    public class AddBuffBasicActionAsset : BasicActionAsset 
    {
        
        [Header("ADD BUFF FACTORS")] [SerializeField]
        private int defaultSkillAddBuffChance;
        
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
        public override IEnumerator TargetAction(IHero thisHero, IHero targetHero)
        {
            var logicTree = thisHero.CoroutineTreesAsset.MainLogicTree;
            
            logicTree.AddCurrent(AddBuffCoroutine(BuffAsset, BuffCounters,thisHero,targetHero));
           
            logicTree.EndSequence();
            yield return null;

        }

        private IEnumerator AddBuffCoroutine(IStatusEffectAsset statusEffectAsset, int statusEffectCounters, IHero thisHero, IHero targetHero)
        {
            var logicTree = thisHero.CoroutineTreesAsset.MainLogicTree;
            //Check BuffResistances Here
            var buffResistance = targetHero.HeroLogic.OtherAttributes.BuffResistance;
            var buffChance = thisHero.HeroLogic.OtherAttributes.BuffChance + defaultSkillAddBuffChance;
            
            
            var buffSuccess = buffChance - buffResistance;
            var randomChance = Random.Range(1, 101);
            
            buffSuccess = Mathf.Clamp(buffSuccess, 0, 100);

            if (randomChance <= buffSuccess)
            {
                BuffAsset.StatusEffectInstance.AddStatusEffect(targetHero, statusEffectAsset, statusEffectCounters,thisHero);
            }

            
       
            
            logicTree.EndSequence();
            yield return null;
        }



      


    }
}
