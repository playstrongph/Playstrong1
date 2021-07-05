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

       
        
        private IHero _hero;
        private ICoroutineTree _logicTree;
        private ICoroutineTree _visualTree;
        
        public override IEnumerator ActionTarget(IHero thisHero, IHero targetHero)
        {
           _logicTree = targetHero.CoroutineTreesAsset.MainLogicTree;
           _visualTree = targetHero.CoroutineTreesAsset.MainVisualTree;
            
           _hero = targetHero;
            
           _logicTree.AddCurrent(HealCoroutine());
           
           _logicTree.EndSequence();
           yield return null;

        }

        private IEnumerator HealCoroutine()
        {
            _visualTree.AddCurrent(HealVisual());
        
            var newHealth = _hero.HeroLogic.HeroAttributes.Health + (int)HealAmount.ModValue;
            _hero.HeroLogic.SetHeroHealth.SetHealth(newHealth);
            
            _logicTree.EndSequence();
            yield return null;
        }
        
        
        //TEMP
        private IEnumerator HealVisual()
        {
            _hero.DamageEffect.ShowDamage((int)HealAmount.ModValue);
            
            _visualTree.EndSequence();
            yield return null;
        }



      


    }
}
