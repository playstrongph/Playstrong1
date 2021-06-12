using System.Collections.Generic;
using ScriptableObjects.StatusEffects;
using UnityEngine;
using Utilities;

namespace Logic
{
    public class HeroDebuffEffects : MonoBehaviour, IHeroDebuffEffects
    {
        [SerializeField]
        [RequireInterface(typeof(IDebuffEffectAsset))]
        private List<Object> _heroDebuffs = new List<Object>();

        public List<IDebuffEffectAsset> HeroDebuffs
        {
            get
            {
                var heroDebuffs = new List<IDebuffEffectAsset>();
                foreach (var heroDebuff in _heroDebuffs)
                {
                    var debuff = heroDebuff as IDebuffEffectAsset;
                    heroDebuffs.Add(debuff);
                }

                return heroDebuffs;
            }
        }
    }
}
