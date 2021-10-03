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
        public void SetStatusBasedOnSkillCooldown(int cooldown)
        {
            if(cooldown<=0)
                SetSkillReady();
            else 
                SetSkillNotReady();
            
            //SkillStatusAction();
        }

        /*private void SkillStatusAction()
        {
            _skillLogic.SkillAttributes.SkillReadiness.StatusAction(_skillLogic);
        }*/

        private void SetSkillReady()
        {
            _skillLogic.SkillAttributes.SkillReadiness = SkillReady;
            _skillLogic.SkillAttributes.SkillReadiness.StatusAction(_skillLogic);
        }

        private void SetSkillNotReady()
        {
            _skillLogic.SkillAttributes.SkillReadiness = SkillNotReady;
            _skillLogic.SkillAttributes.SkillReadiness.StatusAction(_skillLogic);
        }

    }
}
