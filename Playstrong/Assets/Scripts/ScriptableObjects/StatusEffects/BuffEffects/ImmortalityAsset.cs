using System.Collections;
using Interfaces;
using UnityEngine;

namespace ScriptableObjects.StatusEffects.BuffEffects
{
    [CreateAssetMenu(fileName = "Immortality", menuName = "SO's/Status Effects/Buffs/Immortality")]
    public class ImmortalityAsset : StatusEffectAsset
    {

        [SerializeField] private int setLife = 1;
        
        public override void ApplyStatusEffect(IHero hero)
        {
            EffectValue = setLife;
            base.ApplyStatusEffect(hero);
        }

        public override void UnapplyStatusEffect(IHero hero)
        {
            //hero.HeroLogic.HeroEvents.EHeroTakesFatalDamage -= ImmortalityEffect;
            //var logicTree = hero.CoroutineTreesAsset.MainLogicTree;
            //logicTree.AddCurrent(StandardAction.UnregisterStandardAction(hero));
            base.UnapplyStatusEffect(hero);
        }

      
    }
}
