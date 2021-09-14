using System;
using Logic;
using ScriptableObjects.StatusEffects;
using UnityEngine;

namespace Visual
{
    public class LoadSkillStatusEffectValues : MonoBehaviour
    {
        private ISkillStatusEffect _skillStatusEffect;

        private void Awake()
        {
            _skillStatusEffect = GetComponent<ISkillStatusEffect>();
        }

        public void LoadValues(ISkillStatusEffectAsset skillStatusEffectAsset, int counters)
        {
            //New instance of SkillStatusEffect asset
            _skillStatusEffect.SkillStatusEffectAsset = CloneStatusEffectAsset(skillStatusEffectAsset);

            //set skillstatuseffect asset reference to Local Component
            _skillStatusEffect.SkillStatusEffectAsset.SkillStatusEffectReference = _skillStatusEffect;
            //TODO: Replace with own SkillStatusEffectType
            _skillStatusEffect.StatusEffectType = skillStatusEffectAsset.StatusEffectType;
            //TODO: Replace with own UdpateTiming
            _skillStatusEffect.StatusEffectCounterUpdate = skillStatusEffectAsset.UpdateTiming;
            
            //TODO: Replace with own Instance
            _skillStatusEffect.StatusEffectInstance = skillStatusEffectAsset.StatusEffectInstance;

            //_heroStatusEffect.Name = statusEffect.Name;
            //_heroStatusEffect.Counters = counters;
            //_heroStatusEffect.Icon.sprite = statusEffect.Icon;
            //_heroStatusEffect.CounterVisual.text = _heroStatusEffect.Counters.ToString();
            
            //Re-assign reference
            //_heroStatusEffect.CasterHero = statusEffect.CasterHero;

        }

        private ISkillStatusEffectAsset CloneStatusEffectAsset(ISkillStatusEffectAsset skillStatusEffectAsset)
        {
            var skillStatusEffectAssetObject = skillStatusEffectAsset as ScriptableObject;
            var skillStatusEffectAssetCloneObject = Instantiate(skillStatusEffectAssetObject);
            var skillStatusEffectAssetClone = skillStatusEffectAssetCloneObject as ISkillStatusEffectAsset;
            
            //Re-assing reference to Scriptable Object Clone
            skillStatusEffectAssetClone.CasterHero = skillStatusEffectAsset.CasterHero;

            return skillStatusEffectAssetClone;
        }
        
      


    }
}
