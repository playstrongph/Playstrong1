using System.Collections;
using References;
using UnityEngine;

namespace ScriptableObjects.Scriptable_Enums.SkillEnabledStatus
{
    [CreateAssetMenu(fileName = "NotDisplayedSkill", menuName = "SO's/Scriptable Enums/SkillDisplayType/NotDisplayedSkill")]
    public class NotDisplayedSkillType : SkillDisplayTypeAsset
    {
        public override void ApplySkillDisplay(ISkill skill)
        {
            var skillVisualCanvas = skill.SkillVisual.SkillCanvas;
            var targetSkillVisual = skill.TargetSkill;
        

            skillVisualCanvas.enabled = false;
            targetSkillVisual.TargetSkillGameObject.SetActive(false);
            
            
        }
        
    }
}
