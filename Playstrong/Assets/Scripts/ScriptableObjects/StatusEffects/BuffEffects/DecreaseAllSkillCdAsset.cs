using Interfaces;
using UnityEngine;

namespace ScriptableObjects.StatusEffects.BuffEffects
{
    [CreateAssetMenu(fileName = "DecreaseAllSkillCd", menuName = "SO's/Status Effects/Buffs/DecreaseAllSkillCd")]
    public class DecreaseAllSkillCdAsset : StatusEffectAsset
    {
        [SerializeField]
        private float decreaseValue = 1f;

        public override void ApplyStatusEffect(IHero hero)
        {
            var logicTree = hero.CoroutineTreesAsset.MainLogicTree;
            //logicTree.AddCurrent(SkillActionAsset.StartAction(hero, decreaseValue));
        }
        
        public override void UnapplyStatusEffect(IHero hero)
        {
            
           
        }

       





    }
}
