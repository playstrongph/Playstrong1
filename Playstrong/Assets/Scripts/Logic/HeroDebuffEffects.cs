using System.Collections.Generic;
using ScriptableObjects.StatusEffects;
using UnityEngine;
using Utilities;

namespace Logic
{
    public class HeroDebuffEffects : MonoBehaviour, IHeroDebuffEffects
    {
        [SerializeField]
        [RequireInterface(typeof(IHeroStatusEffect))]
        private List<Object> _heroDebuffs = new List<Object>();

        public List<IHeroStatusEffect> HeroDebuffs
        {
            get
            {
                var heroDebuffs = new List<IHeroStatusEffect>();
                foreach (var heroDebuff in _heroDebuffs)
                {
                    var debuff = heroDebuff as IHeroStatusEffect;
                    heroDebuffs.Add(debuff);
                }

                return heroDebuffs;
            }
        }
        
        /// <summary>
        /// For Inspector Display Purposes
        /// </summary>

        public List<Object> HeroDebuffObjects
        {
            get => _heroDebuffs;
        }
    }
}
