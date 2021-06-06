using System.Collections.Generic;
using ScriptableObjects.StatusEffects;
using UnityEngine;
using Utilities;

namespace Logic
{
    public class HeroDebuffEffects : MonoBehaviour
    {
        [SerializeField]
        [RequireInterface(typeof(IDebuffEffect))]
        private List<Object> _heroDebuffs = new List<Object>();

        public List<IDebuffEffect> HeroDebuffs
        {
            get
            {
                var heroDebuffs = new List<IDebuffEffect>();
                foreach (var heroDebuff in _heroDebuffs)
                {
                    var debuff = heroDebuff as IDebuffEffect;
                    heroDebuffs.Add(debuff);
                }

                return heroDebuffs;
            }
        }
    }
}
