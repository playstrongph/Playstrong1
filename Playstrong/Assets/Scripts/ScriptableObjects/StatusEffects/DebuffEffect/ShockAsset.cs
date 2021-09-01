using Interfaces;
using UnityEngine;

namespace ScriptableObjects.StatusEffects.DebuffEffect
{
    [CreateAssetMenu(fileName = "Shock", menuName = "SO's/Status Effects/Debuffs/Shock")]
    public class ShockAsset : StatusEffectAsset
    {   
        //Stun can't be prevented, even by skill can't be stunned
        [SerializeField]
        private int _inabilityChanceIncrease = 10000;

        public override void ApplyStatusEffect(IHero hero) 
        {
            var logicTree = hero.CoroutineTreesAsset.MainLogicTree;
            logicTree.AddCurrent(SkillActionAsset.StartAction(hero, _inabilityChanceIncrease));
        }
        
        public override void UnapplyStatusEffect(IHero hero)
        {
            var logicTree = hero.CoroutineTreesAsset.MainLogicTree;
            logicTree.AddCurrent(SkillActionAsset.StartAction(hero, -_inabilityChanceIncrease));
        }

       





    }
}
