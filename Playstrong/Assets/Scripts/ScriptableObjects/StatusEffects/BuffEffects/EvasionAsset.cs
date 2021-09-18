using Interfaces;
using ScriptableObjects.Modifiers;
using UnityEngine;
using Utilities;

namespace ScriptableObjects.StatusEffects.BuffEffects
{
    [CreateAssetMenu(fileName = "Evasion", menuName = "SO's/Status Effects/Buffs/Evasion")]
    public class EvasionAsset : StatusEffectAsset
    {
        [SerializeField] private float resistanceValue = 200f;
        public override void ApplyStatusEffect(IHero hero)
        {
            //var logicTree = hero.CoroutineTreesAsset.MainLogicTree;
            //logicTree.AddCurrent(SkillActionAsset.StartAction(hero, resistanceValue));
            
            StandardAction.StartAction(hero,resistanceValue);
        }
        
        public override void UnapplyStatusEffect(IHero hero)
        {
            //var logicTree = hero.CoroutineTreesAsset.MainLogicTree;
            //logicTree.AddCurrent(SkillActionAsset.StartAction(hero, -resistanceValue));
            
            StandardAction.StartAction(hero,-resistanceValue);
        }

       





    }
}
