using System.Collections.Generic;
using ScriptableObjects.StatusEffects;
using UnityEngine;
using Utilities;

namespace Logic
{
    public class HeroSkillBuffEffects : MonoBehaviour, IHeroSkillBuffEffects
    {
        [SerializeField]
        [RequireInterface(typeof(IHeroStatusEffect))]
        private List<Object> _heroSkillBuffs = new List<Object>();

        public List<IHeroStatusEffect> HeroSkillBuffs
        {
            get
            {
                var heroBuffs = new List<IHeroStatusEffect>();
                foreach (var heroSkillBuff in _heroSkillBuffs)
                {
                    var skillBuff = heroSkillBuff as IHeroStatusEffect;
                    heroBuffs.Add(skillBuff);
                }

                return heroBuffs;
            }
        }

        public void AddToList(IHeroStatusEffect skillBuffEffect)
        {
            var skillBuffEffectObject = skillBuffEffect as Object;
            
            HeroSkillBuffs.Add(skillBuffEffect);
            _heroSkillBuffs.Add(skillBuffEffectObject);

        }
        
        public void RemoveFromList(IHeroStatusEffect skillBuffEffect)
        {
            var skillBuffEffectObject = skillBuffEffect as Object;
            
            HeroSkillBuffs.Remove(skillBuffEffect);
            _heroSkillBuffs.Remove(skillBuffEffectObject);

        }
        
        
    }
}
