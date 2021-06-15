using Interfaces;
using Logic;
using ScriptableObjects.SkillActions.BaseClassScripts;
using ScriptableObjects.StatusEffects;
using UnityEngine;
using Utilities;

namespace ScriptableObjects.SkillActions
{
    [CreateAssetMenu(fileName = "AddBuffSkillActionAsset", menuName = "SO's/SkillActions/AddBuffSkillActionAsset")]
    
    public class AddBuffSkillActionAsset : SkillActionAsset, IAddBuffSkillActionAsset
    {

        [SerializeField]
        [RequireInterface(typeof(IStatusEffectAsset))]
        private ScriptableObject _buffEffectAsset;
        private IStatusEffectAsset BuffAsset => _buffEffectAsset as IStatusEffectAsset;

        [SerializeField] private int _buffCounters;
        private int BuffCounters => _buffCounters;

        public override void Target(IHero hero)
        {
            AddBuff(hero);
        }

        private void AddBuff(IHero hero)
        {
            Debug.Log("Hero: " +hero.HeroName);

            var buffEffectPrefab = hero.HeroStatusEffects.HeroStatusEffectPrefab;
            
            var statusEffectPanel = hero.HeroStatusEffects.StatusEffectsPanel.Transform;

            var buffEffectObject = Instantiate(buffEffectPrefab, statusEffectPanel);
            buffEffectObject.transform.SetParent(statusEffectPanel);
            
            var heroStatusEffect = buffEffectObject.GetComponent<IHeroStatusEffect>();
            
            //Load StatusEffect
            heroStatusEffect.LoadStatusEffectValues.LoadValues(BuffAsset, BuffCounters);

            //Buff ApplyStatusEffect 
           heroStatusEffect.StatusEffectAsset.ApplyStatusEffect();
        }
        
        

    }
}
