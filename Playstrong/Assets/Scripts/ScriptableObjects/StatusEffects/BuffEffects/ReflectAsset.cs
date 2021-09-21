using System.Collections;
using Interfaces;
using Logic;
using ScriptableObjects.StatusEffects.StatusEffectType;
using UnityEngine;
using Utilities;

namespace ScriptableObjects.StatusEffects.BuffEffects
{
    [CreateAssetMenu(fileName = "Reflect", menuName = "SO's/Status Effects/Buffs/Reflect")]
    public class ReflectAsset : StatusEffectAsset
    {
        [SerializeField]
        private float reflectFactor = 30f;

        public override void ApplyStatusEffect(IHero hero)
        {
            hero.HeroLogic.HeroEvents.EPostAttack += DealReflectDamage;
        }
        
        public override void UnapplyStatusEffect(IHero hero)
        {
            hero.HeroLogic.HeroEvents.EPostAttack -= DealReflectDamage;
        }


        private void DealReflectDamage(IHero thisHero, IHero targetHero)
        {
            var logicTree = thisHero.CoroutineTreesAsset.MainLogicTree;
            
           logicTree.AddCurrent(DealDamage(thisHero,targetHero));
            
        }

        private IEnumerator DealDamage(IHero thisHero, IHero targetHero)
        {
            var logicTree = thisHero.CoroutineTreesAsset.MainLogicTree;
            
            var finalDamage = thisHero.HeroLogic.TakeDamage.FinalDamage;
            
            var reflectDamage = Mathf.CeilToInt(finalDamage * reflectFactor / 100f);

            logicTree.AddCurrent(SkillActionAsset.StartAction(targetHero,reflectDamage));

            logicTree.EndSequence();
            yield return null;
            
        }











    }
}
