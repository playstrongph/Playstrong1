using Interfaces;
using References;
using ScriptableObjects.StatusEffects;

namespace Logic
{
    public interface IBasicConditionAsset
    {
        //Reference
        IHeroStatusEffect StatusEffectReference { get; set; }
        
        ISkill SkillReference { get; set; }
        
        
        /// <summary>
        /// Returns a value of 1 if basic condition is met, 0 otherwise;
        /// Default value is zero
        /// </summary>
        int GetValue(IHero thisHero);
        int GetValue(IHero thisHero, IHero targetHero);
        int GetValue(IHero thisHero, float amount);
        int GetValue(IStatusEffectAsset statusEffect);
    }
}