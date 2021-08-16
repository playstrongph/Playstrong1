using Interfaces;
using ScriptableObjects.Modifiers;
using UnityEngine;
using Utilities;

namespace ScriptableObjects.StatusEffects.BuffEffects
{
    [CreateAssetMenu(fileName = "IncreaseCriticalDamage", menuName = "SO's/Status Effects/Buffs/IncreaseCriticalDamage")]
    public class IncreaseCriticalDamageAsset : StatusEffectAsset
    {

        [SerializeField] private float ciritcalDamageValue = 50f;
        public override void ApplyStatusEffect(IHero hero)
        {
            var logicTree = hero.CoroutineTreesAsset.MainLogicTree;
            logicTree.AddCurrent(SkillActionAsset.StartAction(hero, ciritcalDamageValue));
        }
        
        public override void UnapplyStatusEffect(IHero hero)
        {
            var logicTree = hero.CoroutineTreesAsset.MainLogicTree;
            logicTree.AddCurrent(SkillActionAsset.StartAction(hero, -ciritcalDamageValue));
        }

       





    }
}
