using System;
using Interfaces;
using References;
using UnityEngine;
using Utilities;
using Object = UnityEngine.Object;

namespace Logic
{
    public class TargetSkill : MonoBehaviour, ITargetSkill
    {
        [SerializeField] [RequireInterface(typeof(ISkill))]
        private Object _skill;

        public ISkill Skill => _skill as ISkill;

        private ITargetPreview _skillPreview;
        public ITargetPreview SkillPreview => _skillPreview;
        
       
        private IDragSkillTarget _dragSkillTarget;
        public IDragSkillTarget DragSkillTarget => _dragSkillTarget;

       
        private IGetSkillTargets _getSkillTargets;
        public IGetSkillTargets GetSkillTargets => _getSkillTargets;
        
        //TEST
        public GameObject TargetSkillGameObject { get; set; }


        private void Awake()
        {
            _skillPreview = GetComponent<ITargetPreview>();
            _dragSkillTarget = GetComponent<IDragSkillTarget>();
            _getSkillTargets = GetComponent<IGetSkillTargets>();
            
            //TEST
            TargetSkillGameObject = this.gameObject;
        }
    }
}
