using Interfaces;
using References;
using UnityEngine;
using Utilities;

namespace Logic
{
    public class TargetSkill : MonoBehaviour
    {
        [SerializeField] [RequireInterface(typeof(ISkill))]
        private Object _skill;

        private ISkill Skill => _skill as ISkill;

        private ITargetPreview _skillPreview;
        private ITargetPreview SkillPreview => _skillPreview;
        
        


    }
}
