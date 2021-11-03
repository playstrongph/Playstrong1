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

            var debuffChance = thisHero.HeroLogic.OtherAttributes.DebuffChance + defaultSkillAddDebuffChance;
            var debuffResistance = targetHero.HeroLogic.OtherAttributes.DebuffResistance + immunityResistance;
            
            Debug.Log("ThisHero: " +thisHero + " Debuff Chance: " +debuffChance);
            Debug.Log("TargetHero: " +targetHero + " Debuff Resistance: " +debuffResistance);
            
            


            var debuffSuccess = debuffChance - debuffResistance;
            var randomChance = Random.Range(1, 101);
            
            Debug.Log("Success: " +debuffSuccess +" randomChance: " +randomChance);
            
            debuffSuccess = Mathf.Clamp(debuffSuccess, 0, 100);
            
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
