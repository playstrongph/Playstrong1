using System.Collections.Generic;
using ScriptableObjects.SkillActions;
using UnityEngine;

namespace ScriptableObjects.SkillCondition
{
   
    [CreateAssetMenu(fileName = "SkillEffectAsset", menuName = "SO's/SkillEffect/SkillEffectAsset")]
    public class SkillEffectAsset : ScriptableObject, ISkillEffectAsset
    {

        public void UseSkill()
        {
            foreach (var skillCondition in SkillConditionAssets )
            {
                skillCondition.Target();
            }
        }

        [SerializeField] private List<Object> _skillConditionAssets = new List<Object>();

        public List<ISkillConditionAsset> SkillConditionAssets
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
