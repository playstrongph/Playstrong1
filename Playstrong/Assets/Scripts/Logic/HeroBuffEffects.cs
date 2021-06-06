using System.Collections.Generic;
using ScriptableObjects.StatusEffects;
using UnityEngine;
using Utilities;

namespace Logic
{
    public class HeroBuffEffects : MonoBehaviour
    {
        [SerializeField]
        [RequireInterface(typeof(IBuffEffect))]
        private List<Object> _heroBuffs = new List<Object>();

        public List<IBuffEffect> HeroBuffs
        {
            get
            {
                var heroBuffs = new List<IBuffEffect>();
                foreach (var herobuff in _heroBuffs)
                {
                    var buff = herobuff as IBuffEffect;
                    heroBuffs.Add(buff);
                }

                return heroBuffs;
            }
        }
    }
}
