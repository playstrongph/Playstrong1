using System.Collections.Generic;
using ScriptableObjects.SkillActions;
using UnityEngine;

namespace ScriptableObjects.SkillCondition
{
   
    
    public class SkillConditionAsset : ScriptableObject,ISkillConditionAsset
    {

        public virtual void Target()
        {
            
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
