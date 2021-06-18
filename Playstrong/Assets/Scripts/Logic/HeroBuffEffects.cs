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
        
        /// <summary>
        /// For Inspector Display Purposes
        /// </summary>

        public List<Object> HeroBuffObjects
        {
            get => _heroBuffs;
        }
    }
}
