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
    [CreateAssetMenu(fileName = "AddDebuffAction", menuName = "SO's/BasicActions/AddDebuffAction")]
    
    public class AddDebuffBasicActionAsset : BasicActionAsset
    {

        [Header("ADD DEBUFF FACTORS")] [SerializeField]
        private int defaultSkillAddDebuffChance;
        
        
        [SerializeField]
        [RequireInterface(typeof(IStatusEffectAsset))]
        private ScriptableObject _debuffEffectAsset;
        private IStatusEffectAsset DebuffAsset => _debuffEffectAsset as IStatusEffectAsset;

        [SerializeField] private int _debuffCounters;
        private int DebuffCounters => _debuffCounters;

        /// <summary>
        /// Logic of AddBuff is in the statuseffect asset Instance
        /// Single, Multiple, Fixed
        /// </summary>
        public override IEnumerator TargetAction(IHero thisHero, IHero targetHero)
        {
            var logicTree = targetHero.CoroutineTreesAsset.MainLogicTree;
            logicTree.AddCurrent(AddDebuffCoroutine(DebuffAsset, DebuffCounters,thisHero,targetHero));
            logicTree.EndSequence();
            yield return null;
        }

        private IEnumerator AddDebuffCoroutine(IStatusEffectAsset statusEffectAsset, int statusEffectCounters, IHero thisHero, IHero targetHero)
        {
            var logicTree = thisHero.CoroutineTreesAsset.MainLogicTree;
            
            //Check BuffResistances Here

            var immunityResistance = GetImmunityResistance(targetHero, statusEffectAsset);
            
            Debug.Log("TargetHero: " +targetHero + " Immunity Resistance: " +immunityResistance);

            var debuffResistance = targetHero.HeroLogic.OtherAttributes.DebuffResistance + immunityResistance;
            var debuffChance = targetHero.HeroLogic.OtherAttributes.DebuffChance + defaultSkillAddDebuffChance;
            
            
            var debuffSuccess = debuffChance - debuffResistance;
            var randomChance = Random.Range(0f, 100f);
            
            debuffSuccess = Mathf.Clamp(debuffSuccess, 0f, 100f);
            
            //Debug.Log("Caster Hero: " +thisHero.HeroName);
            
            if(randomChance<= debuffSuccess)
                DebuffAsset.StatusEffectInstance.AddStatusEffect(targetHero, statusEffectAsset, statusEffectCounters,thisHero);
       
            
            logicTree.EndSequence();
            yield return null;
        }

        private int GetImmunityResistance(IHero targetHero,IStatusEffectAsset statusEffectAsset)
        {
            var heroImmunities = targetHero.HeroLogic.StatusEffectImmunityList.HeroImmunities;
            var immunityResistance = 0;
            
            foreach (var heroImmunity in heroImmunities)
            {
                var statusEffectImmunity = heroImmunity.StatusEffectAsset;

                if (statusEffectAsset.Name == statusEffectImmunity.Name)
                    immunityResistance = heroImmunity.ImmunityPercentage;

            }

            return immunityResistance;

        }






    }
}
