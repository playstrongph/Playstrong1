using System;
using Interfaces;
using Logic;
using ScriptableObjects.SkillEffects;
using TMPro.EditorUtilities;
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
            skillAttributes.SkillReadiness = skillAsset.SkillReadiness;
            
            //Unique instances of skills to solve the problem of duplicate heroes
            var uniqueSkillEffect = Instantiate(skillAsset.SkillEffect as ScriptableObject);
            var skillEffect = uniqueSkillEffect as ISkillEffectAsset;
            
            //skillAttributes.SkillEffect = skillAsset.SkillEffect;
            skillAttributes.SkillEffect = skillEffect;

            skillAttributes.SkillReference = _skillLogic.Skill;

        }
        
        
        


    }
}
