using Interfaces;
using UnityEngine;

namespace ScriptableObjects.StatusEffects.BuffEffects
{
    [CreateAssetMenu(fileName = "ArmorUp", menuName = "SO's/Status Effects/Buffs/ArmorUp")]
    public class ArmorUpAsset : StatusEffectAsset
    {
        [SerializeField]
        private float armorIncrease = 10f;

        public override void ApplyStatusEffect(IHero hero)
        {
            var logicTree = hero.CoroutineTreesAsset.MainLogicTree;
            //logicTree.AddCurrent(SkillActionAsset.StartAction(hero, armorIncrease));
        }
        
        public override void UnapplyStatusEffect(IHero hero)
        {
            
           
        }

       





    }
}
