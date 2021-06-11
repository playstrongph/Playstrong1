using System.Collections.Generic;
using ScriptableObjects.SkillActions;
using UnityEngine;

namespace ScriptableObjects.SkillCondition
{
   
    
    public class SkillEffectAsset : ScriptableObject, ISkillEffectAsset
    {

        public virtual void UseSkill()
        {
            
        }

        [SerializeField] private List<Object> _skillConditionAssets = new List<Object>();

        public List<ISkillConditionAsset> SkillActionAssets
        {
            get
            {
                var skillConditions = new List<ISkillConditionAsset>();
                foreach (var skillConditionAssetObject in _skillConditionAssets)
                {
                    var skillCondition = skillConditionAssetObject as ISkillConditionAsset;
                    skillConditions.Add(skillCondition);
                }

                return skillConditions;

            }
            
        }


    }
}
