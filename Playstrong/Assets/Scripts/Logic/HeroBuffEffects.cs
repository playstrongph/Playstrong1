using System.Collections.Generic;
using ScriptableObjects.StatusEffects;
using UnityEngine;
using Utilities;

namespace Logic
{
    public class HeroBuffEffects : MonoBehaviour, IHeroBuffEffects
    {
        [SerializeField]
        [RequireInterface(typeof(IHeroStatusEffect))]
        private List<Object> _heroBuffs = new List<Object>();

        public List<IHeroStatusEffect> HeroBuffs
        {
            get
            {
                var heroBuffs = new List<IHeroStatusEffect>();
                foreach (var herobuff in _heroBuffs)
                {
                    var buff = herobuff as IHeroStatusEffect;
                    heroBuffs.Add(buff);
                }

                return heroBuffs;
            }
        }

        public void AddToList(IHeroStatusEffect buffEffect)
        {
            var buffEffectObject = buffEffect as Object;
            
            HeroBuffs.Add(buffEffect);
            _heroBuffs.Add(buffEffectObject);

        }
        
        public void RemoveFromList(IHeroStatusEffect buffEffect)
        {
            var buffEffectObject = buffEffect as Object;
            
            HeroBuffs.Remove(buffEffect);
            _heroBuffs.Remove(buffEffectObject);

        }
        
        
    }
}
