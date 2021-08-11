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
    [CreateAssetMenu(fileName = "AddDebuffSkillActionAsset", menuName = "SO's/SkillActions/AddDebuffSkillActionAsset")]
    
    public class AddDebuffSkillActionAsset : SkillActionAsset, IAddDebuffSkillActionAsset
    {

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
        public override IEnumerator ActionTarget(IHero thisHero, IHero targetHero)
        {
            InitializeValues(thisHero, targetHero);
            
            LogicTree.AddCurrent(AddDebuffCoroutine(DebuffAsset, DebuffCounters));
           
            LogicTree.EndSequence();
            yield return null;

        }

        private IEnumerator AddDebuffCoroutine(IStatusEffectAsset statusEffectAsset, int statusEffectCounters)
        {
            
            //Check BuffResistances Here
            var debuffResistance = TargetHero.HeroLogic.OtherAttributes.DebuffResistance;
            var debuffChance = TargetHero.HeroLogic.OtherAttributes.DebuffChance;
            var debuffSuccess = debuffChance - debuffResistance;
            var randomChance = Random.Range(0f, 100f);
            
            debuffSuccess = Mathf.Clamp(debuffSuccess, 0f, 100f);
            
            if(randomChance<= debuffSuccess)
                DebuffAsset.StatusEffectInstance.AddStatusEffect(TargetHero, statusEffectAsset, statusEffectCounters);
       
            
            LogicTree.EndSequence();
            yield return null;
        }



      


    }
}
