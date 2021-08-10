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

        /// <summary>
        /// Logic of AddBuff is in the statuseffect asset Instance
        /// Single, Multiple, Fixed
        /// </summary>
        public override IEnumerator ActionTarget(IHero thisHero, IHero targetHero)
        {
            InitializeValues(thisHero, targetHero);
            
            LogicTree.AddCurrent(AddBuffCoroutine(BuffAsset, BuffCounters));
           
            LogicTree.EndSequence();
           yield return null;

        }

        private IEnumerator AddBuffCoroutine(IStatusEffectAsset statusEffectAsset, int statusEffectCounters)
        {
            
            //Check BuffResistances Here
            var buffResistance = TargetHero.HeroLogic.OtherAttributes.BuffResistance;
            var buffChance = TargetHero.HeroLogic.OtherAttributes.BuffChance;
            var buffSuccess = buffChance - buffResistance;
            var randomChance = Random.Range(0f, 100f);
            
            buffSuccess = Mathf.Clamp(buffSuccess, 0f, 100f);
            
            if(randomChance<= buffSuccess)
                BuffAsset.StatusEffectInstance.AddStatusEffect(TargetHero, statusEffectAsset, statusEffectCounters);
       
            
            LogicTree.EndSequence();
            yield return null;
        }



      


    }
}
