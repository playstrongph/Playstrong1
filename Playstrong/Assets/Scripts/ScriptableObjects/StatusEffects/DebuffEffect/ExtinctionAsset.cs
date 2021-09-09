using System.Collections;
using Interfaces;
using Logic;
using ScriptableObjects.StatusEffects.StatusEffectType;
using UnityEngine;
using Utilities;

namespace ScriptableObjects.StatusEffects.BuffEffects
{
    [CreateAssetMenu(fileName = "Extinction", menuName = "SO's/Status Effects/Debuffs/Extinction")]
    public class ExtinctionAsset : StatusEffectAsset
    {
        private float dummyValue = 0f;
        private float resurrectResistance = 200f;

        public override void ApplyStatusEffect(IHero hero)
        {
            //TODO: IncreaseResurrect Chance Action
            hero.HeroLogic.OtherAttributes.ResurrectResistance += resurrectResistance;
            hero.HeroLogic.HeroEvents.EPostHeroDeath += ExtinctionAction;
        }
        
        public override void UnapplyStatusEffect(IHero hero)
        {
            hero.HeroLogic.OtherAttributes.ResurrectResistance -= resurrectResistance;
            hero.HeroLogic.HeroEvents.EPostHeroDeath -= ExtinctionAction;
        }


        //This will call UnapplyStatusEffect of this debuff
        private void ExtinctionAction(IHero hero)
        {
            Debug.Log("Extinction Action");
       
            var buffs = hero.HeroStatusEffects.HeroBuffEffects.HeroBuffs;
            var debuffs = hero.HeroStatusEffects.HeroDebuffEffects.HeroDebuffs;
            var logicTree = hero.CoroutineTreesAsset.MainLogicTree;
            
            

            foreach (var buff in buffs)
            {
                buff.RemoveStatusEffect.RemoveEffect(hero);
            }
            
            foreach (var debuff in debuffs)
            {
                debuff.RemoveStatusEffect.RemoveEffect(hero);
            }
       
        }


       
        
        //TEST
        public override void RemoveStatusEffect(IHero hero)
        {
           
        }
        
        










    }
}
