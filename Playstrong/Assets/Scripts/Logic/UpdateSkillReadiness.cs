using System;
using System.CodeDom;
using System.Collections.Generic;
using Interfaces;
using ScriptableObjects.Enums.SkillStatus;
using UnityEngine;
using Utilities;
using Object = UnityEngine.Object;

namespace Logic
{
    public class UpdateSkillReadiness : MonoBehaviour, IUpdateSkillReadiness
    {
        [SerializeField] [RequireInterface(typeof(ISkillReadiness))]
        private ScriptableObject skillReady;
        public ISkillReadiness SkillReady => skillReady as ISkillReadiness;
        
        [SerializeField] [RequireInterface(typeof(ISkillReadiness))]
        private ScriptableObject skillNotReady;
        public ISkillReadiness SkillNotReady => skillNotReady as ISkillReadiness;

        private ISkillLogic _skillLogic;
        
        private void Awake()
        {
            _skillLogic = GetComponent<ISkillLogic>();
        }

        public void SetSkillReady()
        {      
            //TODO: if Skill is enabled: SkillStatus.SetSkillReady
            
            _skillLogic.SkillAttributes.SkillReadiness = SkillReady;
            _skillLogic.SkillAttributes.SkillReadiness.StatusAction(_skillLogic);
        }

        public void SetSkillNotReady()
        {
            _skillLogic.SkillAttributes.SkillReadiness = SkillNotReady;
            _skillLogic.SkillAttributes.SkillReadiness.StatusAction(_skillLogic);
        }

    }
}
