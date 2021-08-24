using Interfaces;
using UnityEngine;

namespace ScriptableObjects.StatusEffects.DebuffEffect
{
    [CreateAssetMenu(fileName = "Burn", menuName = "SO's/Status Effects/Debuffs/Burn")]
    public class BurnAsset : StatusEffectAsset
    {
        [SerializeField] private float burnDamage = 0;
        [SerializeField] private float percentFactor = 60f;

        public override void ApplyStatusEffect(IHero hero)
        {
            hero.HeroLogic.HeroEvents.EHeroStartTurn += BurnHeroEffect;
        }
        
        public override void UnapplyStatusEffect(IHero hero)
        {
            hero.HeroLogic.HeroEvents.EHeroStartTurn -= BurnHeroEffect;
        }

        private void BurnHeroEffect(IHero hero)
        {
            var logicTree = hero.CoroutineTreesAsset.MainLogicTree;
            
            burnDamage = percentFactor * CasterHero.HeroLogic.HeroAttributes.Attack / 100;
            burnDamage = Mathf.CeilToInt(burnDamage);

            logicTree.AddCurrent(SkillActionAsset.StartAction(hero, burnDamage));
            
        }








    }
}
