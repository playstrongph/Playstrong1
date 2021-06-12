using System.Collections.Generic;
using Interfaces;
using ScriptableObjects.SkillActions.BaseClassScripts;
using UnityEngine;

namespace ScriptableObjects.SkillCondition.BaseClassScripts
{
   
    
    public class SkillConditionAsset : ScriptableObject,ISkillConditionAsset
    {
        /// <summary>
        /// Run all skill actions assigned to the skill condition
        /// </summary>
        /// <param name="hero"></param>
       
        public virtual void Target(IHero hero)
        {
            var skillActions = SkillActionAssets;
            foreach (var skillAction in skillActions)
            {
                skillAction.Target(hero);   
            }
                

        }

        [SerializeField] private List<Object> _skillActionAssets = new List<Object>();

        public List<ISkillActionAsset> SkillActionAssets
        {
            get
            {
                var skillActions = new List<ISkillActionAsset>();
                foreach (var skillActionAssetObject in _skillActionAssets)
                {
                    var skillAction = skillActionAssetObject as ISkillActionAsset;
                    skillActions.Add(skillAction);
                }

                return skillActions;

            }
            
        }


    }
}
