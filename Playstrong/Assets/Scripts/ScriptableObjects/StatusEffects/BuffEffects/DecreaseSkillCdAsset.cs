using Interfaces;
using UnityEngine;

namespace ScriptableObjects.StatusEffects.BuffEffects
{
    [CreateAssetMenu(fileName = "DecreaseSkillCd", menuName = "SO's/Status Effects/Buffs/DecreaseSkillCd")]
    public class DecreaseSkillCdAsset : StatusEffectAsset
    {
        [SerializeField]
        private float decreaseValue = 1f;

        public override void ApplyStatusEffect(IHero hero)
        {
            var logicTree = hero.CoroutineTreesAsset.MainLogicTree;
            logicTree.AddCurrent(SkillActionAsset.StartAction(hero, decreaseValue));
        }
        
        public override void UnapplyStatusEffect(IHero hero)
        {
            
           
        }

       





    }
}
