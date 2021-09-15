using System.Collections.Generic;
using ScriptableObjects.StatusEffects;
using UnityEngine;
using Utilities;

namespace Logic
{
    public class HeroSkillDebuffEffects : MonoBehaviour, IHeroSkillDebuffEffects
    {
        [SerializeField]
        [RequireInterface(typeof(IHeroStatusEffect))]
        private List<Object> _heroSkillDebuffs = new List<Object>();

        public List<IHeroStatusEffect> HeroSkillDebuffs
        {
            get
            {
                var heroSkillDebuffs = new List<IHeroStatusEffect>();
                foreach (var heroSkillDebuff in _heroSkillDebuffs)
                {
                    var skillDebuff = heroSkillDebuff as IHeroStatusEffect;
                    heroSkillDebuffs.Add(skillDebuff);
                }

                return heroSkillDebuffs;
            }
        }

        public void AddToList(IHeroStatusEffect skillDebuffEffect)
        {
            var skillDebuffEffectObject = skillDebuffEffect as Object;
            
            HeroSkillDebuffs.Add(skillDebuffEffect);
            _heroSkillDebuffs.Add(skillDebuffEffectObject);

        }
        
        public void RemoveFromList(IHeroStatusEffect skillDebuffEffect)
        {
            var skillDebuffEffectObject = skillDebuffEffect as Object;
            
            HeroSkillDebuffs.Remove(skillDebuffEffect);
            _heroSkillDebuffs.Remove(skillDebuffEffectObject);

        }
        
        
    }
}
