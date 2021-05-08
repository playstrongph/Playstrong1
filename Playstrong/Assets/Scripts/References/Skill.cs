using System;
using Interfaces;
using Logic;
using UnityEngine;
using Utilities;
using Visual;
using Object = UnityEngine.Object;


namespace References
{
    public class Skill : MonoBehaviour, ISkill
    {

        [SerializeField] [RequireInterface(typeof(ISkillLogic))]
        private Object _skillLogic;
        public ISkillLogic SkillLogic => _skillLogic as ISkillLogic;
        
        [SerializeField] [RequireInterface(typeof(ISkillVisual))]
        private Object _skillVisual;
        public ISkillVisual SkillVisual => _skillVisual as ISkillVisual;
        
        [SerializeField] [RequireInterface(typeof(ISkillPreviewVisual))]
        private Object _skillPreviewVisual;
        public ISkillPreviewVisual SkillPreviewVisual => _skillPreviewVisual as ISkillPreviewVisual;
        
          
        [SerializeField] [RequireInterface(typeof(ITargetPreview))]
        private Object _targetSkillPreview;
        public ITargetPreview TargetSkillPreview => _targetSkillPreview as ITargetPreview;
        
       
        
    }
}
