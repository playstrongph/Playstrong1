using References;
using UnityEngine;

namespace ScriptableObjects.Scriptable_Enums.SkillEnabledStatus
{
    public class SkillDisplayTypeAsset : ScriptableObject, ISkillDisplayTypeAsset
    {
        public virtual void HideSkillAndTargetVisual(ISkill skill)
        {
            var skillVisualCanvas = skill.SkillVisual.SkillCanvas;
            var targetSkillVisual = skill.TargetSkill as Object as GameObject;

            skillVisualCanvas.enabled = false;
            targetSkillVisual.SetActive(false);
            
        }
        
        public virtual void ShowSkillAndTargetVisual(ISkill skill)
        {
            var skillVisualCanvas = skill.SkillVisual.SkillCanvas;
            var targetSkillVisual = skill.TargetSkill as Object as GameObject;

            skillVisualCanvas.enabled = true;
            targetSkillVisual.SetActive(true);
            
        }
        
       

        



    }
}
