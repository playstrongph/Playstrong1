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
    public class UpdateSkillStatus : MonoBehaviour, IUpdateSkillStatus
    {
        [SerializeField] [RequireInterface(typeof(ISkillStatus))]
        private Object _skillReady;
        public ISkillStatus SkillReady => _skillReady as ISkillStatus;
        
        [SerializeField] [RequireInterface(typeof(ISkillStatus))]
        private Object _skillNotReady;
        public ISkillStatus SkillNotReady => _skillNotReady as ISkillStatus;

        private ISkillLogic _skillLogic;

        private List<Action> _setStatus = new List<Action>();

        private void Awake()
        {
            _skillLogic = GetComponent<ISkillLogic>();
            
            _setStatus.Add(SetSkillReady);     //index is 0
            _setStatus.Add(SetSkillNotReady);  //index is 1 
        }


        //Note: if cooldown is 0, set to: SKillStatusReady
        // if cooldown is >0, set to SkillStatusNotReady
        public void SetStatus(int cooldown)
        {
            var index = Mathf.Clamp(cooldown, 0, 1);
            _setStatus[index]();

        }

        private void SetSkillReady()
        {
            var skillStatus = _skillLogic.SkillAttributes.SkillStatus;
            skillStatus = SkillReady;
        }

        private void SetSkillNotReady()
        {
            var skillStatus = _skillLogic.SkillAttributes.SkillStatus;
            skillStatus = SkillNotReady;
        }

    }
}
