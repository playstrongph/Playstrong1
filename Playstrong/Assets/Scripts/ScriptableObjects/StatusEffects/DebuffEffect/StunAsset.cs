using Interfaces;
using UnityEngine;

namespace ScriptableObjects.StatusEffects.DebuffEffect
{
    [CreateAssetMenu(fileName = "Stun", menuName = "SO's/Status Effects/Debuffs/Stun")]
    public class StunAsset : StatusEffectAsset
    {
        [SerializeField]
        private int _chanceIncrease = 150;

        public override void ApplyStatusEffect(IHero hero) {
       

            var logicTree = hero.CoroutineTreesAsset.MainLogicTree;
            logicTree.AddCurrent(SkillActionAsset.StartAction(hero, _chanceIncrease));
        }
        
        public override void UnapplyStatusEffect(IHero hero)
        {
            var logicTree = hero.CoroutineTreesAsset.MainLogicTree;
            logicTree.AddCurrent(SkillActionAsset.StartAction(hero, -_chanceIncrease));
        }

       





    }
}
