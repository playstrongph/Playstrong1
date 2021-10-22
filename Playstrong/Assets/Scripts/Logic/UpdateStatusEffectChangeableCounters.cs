using System;
using ScriptableObjects.StatusEffects.Instance;
using UnityEngine;

namespace Logic
{
    public class UpdateStatusEffectChangeableCounters : MonoBehaviour, IUpdateStatusEffectChangeableCounters
    {
        [SerializeField] private ScriptableObject tempNoDecreaseAsset;
        private IStatusEffectChangeCountersAsset TempNoDecreaseAsset => tempNoDecreaseAsset as IStatusEffectChangeCountersAsset;

        [SerializeField] private ScriptableObject changeableCountersAsset;

        private IStatusEffectChangeCountersAsset ChangeableCountersAsset => changeableCountersAsset as IStatusEffectChangeCountersAsset;
    
        [SerializeField] private ScriptableObject notChangeableCountersAsset;

        private IStatusEffectChangeCountersAsset NotChangeableCountersAsset => notChangeableCountersAsset as IStatusEffectChangeCountersAsset;

        private IHeroStatusEffect _heroStatusEffect;

        private void Awake()
        {
            _heroStatusEffect = GetComponent<IHeroStatusEffect>();
        }

        public void SetToChangeableCounters()
        {
            _heroStatusEffect.StatusEffectChangeCounters = ChangeableCountersAsset;
        }
        
        public void SetToNotChangeableCounters()
        {
            _heroStatusEffect.StatusEffectChangeCounters = NotChangeableCountersAsset;
        }
        
        public void SetToTempNoDecreaseCounters()
        {
            _heroStatusEffect.StatusEffectChangeCounters = TempNoDecreaseAsset;
        }
        
        


    }
}
