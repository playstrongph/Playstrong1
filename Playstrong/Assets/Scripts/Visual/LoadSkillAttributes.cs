using System;
using Interfaces;
using UnityEngine;
using Utilities;
using Object = UnityEngine.Object;

namespace Visual
{
    public class LoadSkillAttributes : MonoBehaviour, ILoadSkillAttributes
    {
       
        private ISkillLogic _skillLogic;

        private void Awake()
        {
            _skillLogic = GetComponent<ISkillLogic>();
        }

        public void LoadSkillAttributesFromAsset(IHeroSkillAsset skillAsset)
        {
            var skillAttributes = _skillLogic.SkillAttributes;
            
            skillAttributes.Cooldown = skillAsset.Cooldown;
            skillAttributes.BaseCooldown = skillAsset.Cooldown;
            
            skillAttributes.SkillType = skillAsset.SkillType;
            skillAttributes.SkillTarget = skillAsset.SkillTarget;
            skillAttributes.SkillStatus = skillAsset.SkillStatus;


        }
        
        
    }
}
