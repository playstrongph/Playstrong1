using System.Collections;
using Interfaces;
using ScriptableObjects.Actions.BaseClassScripts;
using ScriptableObjects.Modifiers;
using ScriptableObjects.Others;
using UnityEngine;
using Utilities;

namespace ScriptableObjects.Actions
{
    [CreateAssetMenu(fileName = "HealActionAsset", menuName = "SO's/SkillActions/HealActionAsset")]
    
    public class HealActionAsset : SkillActionAsset, IHealActionAsset
    {
        /// <summary>
        /// Heal Amount can be a Fixed Value set in the Modifier SO
        /// or, it can be set in script
        /// </summary>
        [SerializeField] [RequireInterface(typeof(IModifier))]
        private ScriptableObject _healAmount;

        public IModifier HealAmount => _healAmount as IModifier;

        [SerializeField] private int healValue;

        public override IEnumerator ActionTarget(IHero thisHero, IHero targetHero)
        {
           InitializeValues(thisHero, targetHero);
            
           LogicTree.AddCurrent(HealCoroutine());
           
           LogicTree.EndSequence();
           yield return null;

        }

        private IEnumerator HealCoroutine()
        {
            VisualTree.AddCurrent(HealVisual());
        
            var newHealth = TargetHero.HeroLogic.HeroAttributes.Health + (int)HealAmount.ModValue;
            
            //var newHealth = TargetHero.HeroLogic.HeroAttributes.Health + Mathf.FloorToInt(healValue* TargetHero.HeroLogic.HeroAttributes.Health);
            
            TargetHero.HeroLogic.SetHeroHealth.SetHealth(newHealth);
            
            LogicTree.EndSequence();
            yield return null;
        }
        
        
        //TEMP
        private IEnumerator HealVisual()
        {
            TargetHero.DamageEffect.ShowDamage((int)HealAmount.ModValue);
            
            //TargetHero.DamageEffect.ShowDamage(Mathf.FloorToInt(healValue* TargetHero.HeroLogic.HeroAttributes.Health));

            VisualTree.EndSequence();
            yield return null;
        }



      


    }
}
