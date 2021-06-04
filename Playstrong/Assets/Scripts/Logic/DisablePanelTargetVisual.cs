using System;
using References;
using UnityEngine;

namespace Logic
{
    public class DisablePanelTargetVisual : MonoBehaviour, IDisablePanelTargetVisual
    {
        private IPanelSkills _panelSkills;

        private void Awake()
        {
            _panelSkills = GetComponent<IPanelSkills>();
        }
        
        
        public void DisableTarget()
        {
            foreach (var skillsPanelObject in _panelSkills.List)
            {
                var skillsList = skillsPanelObject.GetComponent<ISkillsPanel>().SkillList;

                foreach (var skillObject in skillsList)
                {
                    var skill = skillObject.GetComponent<ISkill>();

                    var targetCanvas = skill.TargetSkill.SkillPreview.TargetVisual.TargetCanvas;

                    targetCanvas.gameObject.SetActive(false);

                }
                

            }
        }
    }
}
