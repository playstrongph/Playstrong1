using System.Collections;
using Interfaces;
using ScriptableObjects.Modifiers;
using ScriptableObjects.Others;
using ScriptableObjects.SkillActions.BaseClassScripts;
using UnityEngine;
using Utilities;

namespace ScriptableObjects.Actions
{
    [CreateAssetMenu(fileName = "HealActionAsset", menuName = "SO's/SkillActions/HealActionAsset")]
    
    public class HealActionAsset : SkillActionAsset, IHealActionAsset
    {
        [SerializeField] [RequireInterface(typeof(IModifier))]
        private ScriptableObject _healAmount;

        public IModifier HealAmount => _healAmount as IModifier;
        
        private IHero _hero;
        public override void Target(IHero hero, ICoroutineTreesAsset coroutineTreesAsset)
        {
           LogicTree = coroutineTreesAsset.MainLogicTree;
           VisualTree = coroutineTreesAsset.MainVisualTree;
           _hero = hero;
            
           LogicTree.AddCurrent(HealCoroutine());

        }

        private IEnumerator HealCoroutine()
        {
            VisualTree.AddCurrent(HealVisual());
        
            var newHealth = _hero.HeroLogic.HeroAttributes.Health + (int)HealAmount.ModValue;
            _hero.HeroLogic.SetHeroHealth.SetHealth(newHealth);
            
            LogicTree.EndSequence();
            yield return null;
        }
        
        private IEnumerator HealVisual()
        {
            _hero.DamageEffect.ShowDamage((int)HealAmount.ModValue);
            
            VisualTree.EndSequence();
            yield return null;
        }



      


    }
}
