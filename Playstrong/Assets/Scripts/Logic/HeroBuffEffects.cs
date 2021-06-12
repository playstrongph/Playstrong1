using System.Collections.Generic;
using ScriptableObjects.StatusEffects;
using UnityEngine;
using Utilities;

namespace Logic
{
    public class HeroBuffEffects : MonoBehaviour, IHeroBuffEffects
    {
        [SerializeField]
        [RequireInterface(typeof(IBuffEffectAsset))]
        private List<Object> _heroBuffs = new List<Object>();

        public List<IBuffEffectAsset> HeroBuffs
        {
            get
            {
                var heroBuffs = new List<IBuffEffectAsset>();
                foreach (var herobuff in _heroBuffs)
                {
                    var buff = herobuff as IBuffEffectAsset;
                    heroBuffs.Add(buff);
                }

                return heroBuffs;
            }
        }
    }
}
