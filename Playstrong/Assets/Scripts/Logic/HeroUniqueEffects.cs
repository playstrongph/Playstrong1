using System.Collections.Generic;
using ScriptableObjects.StatusEffects;
using UnityEngine;
using Utilities;

namespace Logic
{
    public class HeroUniqueEffects : MonoBehaviour, IHeroUniqueEffects
    {
        [SerializeField]
        [RequireInterface(typeof(IHeroStatusEffect))]
        private List<Object> _uniqueEffects = new List<Object>();

        public List<IHeroStatusEffect> UniqueEffects
        {
            get
            {
                var uniqueEffects = new List<IHeroStatusEffect>();
                foreach (var uniqueEffectObject in _uniqueEffects)
                {
                    var uniqueEffect = uniqueEffectObject as IHeroStatusEffect;
                    uniqueEffects.Add(uniqueEffect);
                }
                return uniqueEffects;
            }
        }

        public void AddToList(IHeroStatusEffect uniqueEffect)
        {
            var uniqueEffectObject = uniqueEffect as Object;
            
            UniqueEffects.Add(uniqueEffect);
            _uniqueEffects.Add(uniqueEffectObject);
        }
        
        public void RemoveFromList(IHeroStatusEffect uniqueEffect)
        {
            var uniqueEffectObject = uniqueEffect as Object;
            
            UniqueEffects.Remove(uniqueEffect);
            _uniqueEffects.Remove(uniqueEffectObject);
        }
        
        
    }
}
