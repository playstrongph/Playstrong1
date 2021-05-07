using System;
using Interfaces;
using UnityEngine;
using Utilities;

namespace Visual
{
    public class LoadSkillVisuals : MonoBehaviour, ILoadSkillVisuals
    {
       
        private ISkillVisual _skillVisual;

        private void Awake()
        {
            _skillVisual = GetComponent<ISkillVisual>();
        }


        public void LoadSkillVisualsFromSkillAsset(IHeroSkillAsset heroSkillAsset)
        {
            var skillAttributes = _skillVisual.Skill.SkillLogic.SkillAttributes;
            
            _skillVisual.SkillGraphic.sprite = heroSkillAsset.SkillIcon;
            _skillVisual.CooldownText.text = skillAttributes.Cooldown.ToString();
        }
    }
}
