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
        /// Note: Don't forget to remove buffs from this list as well
        /// </summary>

        public List<Object> HeroDebuffObjects
        {
            get => _heroDebuffs;
        }
    }
}
