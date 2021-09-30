using Interfaces;
using Logic;
using UnityEngine;

namespace ScriptableObjects.StatusEffects.DebuffEffect
{
    [CreateAssetMenu(fileName = "Cripple", menuName = "SO's/Status Effects/Debuffs/Cripple")]
    public class CrippleAsset : StatusEffectAsset
    {

        /*
        [SerializeField] private int decreaseCriticalChance = 1000;
        [SerializeField] private int decreaseOtherDamageMultiplier = 25;
        [SerializeField] private ScriptableObject decreaseOtherDamageAction;
        private IHeroAction DecreaseOtherDamageAction => decreaseOtherDamageAction as IHeroAction;*/
        
        public override void ApplyStatusEffect(IHero hero)
        {
          base.ApplyStatusEffect(hero);
        }

        public override void UnapplyStatusEffect(IHero hero)
        {
          base.UnapplyStatusEffect(hero);
        }

        
    }
}
