using Interfaces;
using ScriptableObjects.SkillActionsScripts;
using UnityEngine;
using Visual;

namespace ScriptableObjects.StatusEffects.DebuffEffect
{
    [CreateAssetMenu(fileName = "Bomb", menuName = "SO's/Status Effects/Debuffs/Bomb")]
    public class BombAsset : StatusEffectAsset
    {
        
        private int _chanceIncrease = 150;

        public override void ApplyStatusEffect(IHero hero) 
        {
            var logicTree = hero.CoroutineTreesAsset.MainLogicTree;
            
            logicTree.AddCurrent(SkillActionAsset.StartAction(hero, _chanceIncrease));
        }
        
        public override void UnapplyStatusEffect(IHero hero)
        {
            var logicTree = hero.CoroutineTreesAsset.MainLogicTree;
            logicTree.AddCurrent(SkillActionAsset.StartAction(hero, -_chanceIncrease));
        }
        
        //TODO: Subscribe to targetHero EndTurn
        private void DamageEffect(IHero targetHero)
        {
            var counters = HeroStatusEffectReference.Counters;
            var bombDamage = CasterHero.HeroLogic.HeroAttributes.Attack;
            
            if (counters <= 0)
            {
                //TODO: Replace with DealDamage SkillActionAsset.StartAction 
                targetHero.HeroLogic.TakeDamage.TakeDirectDamage(bombDamage, 0, 0);    
            }
        }

        private void ShockEffect(IHero targetHero)
        {
            //TODO: AddDebuff ACtion - shock
        }











    }
}
