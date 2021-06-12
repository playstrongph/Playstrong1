using Interfaces;
using Logic;
using ScriptableObjects.StatusEffects;
using UnityEngine;

namespace ScriptableObjects.SkillActions
{
    [CreateAssetMenu(fileName = "AddBuffSkillActionAsset", menuName = "SO's/SkillActions/AddBuffSkillActionAsset")]
    
    public class AddBuffSkillActionAsset : SkillActionAsset, IAddBuffSkillActionAsset
    {

        [SerializeField] private ScriptableObject _buffEffectAsset;
        private IBuffEffectAsset BuffAsset => _buffEffectAsset as IBuffEffectAsset;

        [SerializeField] private int _buffCounters;
        private int BuffCounters => _buffCounters;

        public override void Target(IHero hero)
        {
            AddBuff(hero);
        }

        private void AddBuff(IHero hero)
        {
            var buffEffectPrefab = hero.HeroStatusEffects.HeroStatusEffectPrefab;
            var statusEffectPanel = hero.HeroStatusEffects.StatusEffectsPanel.Transform;

            var buffEffectObject = Instantiate(buffEffectPrefab, statusEffectPanel);
            var heroStatusEffect = buffEffectObject.GetComponent<IHeroStatusEffect>();
            
            //Load StatusEffect
            heroStatusEffect.LoadStatusEffectValues.LoadValues(BuffAsset, BuffCounters);

            //Buff ApplyStatusEffect 
            heroStatusEffect.StatusEffectAsset.ApplyStatusEffect();
        }
        
        

    }
}
