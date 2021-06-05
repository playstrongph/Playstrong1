using System;
using References;
using ScriptableObjects.Enums.SkillTarget;
using UnityEngine;
using Utilities;
using Object = System.Object;

namespace Logic
{
    public class DisablePanelTargetVisual : MonoBehaviour, IDisablePanelTargetVisual
    {
        private IPanelSkills _panelSkills;

        [SerializeField] [RequireInterface(typeof(ISkillTarget))]
        private ScriptableObject _skillTargetNone;
        public ISkillTarget SkillTargetNone => _skillTargetNone as ISkillTarget;

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

                    skill.SkillLogic.SkillAttributes.SkillTarget = SkillTargetNone;

                }
                

            }
        }
    }
}
