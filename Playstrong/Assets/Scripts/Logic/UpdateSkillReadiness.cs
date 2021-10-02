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
        private Object _skillReady;
        public ISkillReadiness SkillReady => _skillReady as ISkillReadiness;
        
        [SerializeField] [RequireInterface(typeof(ISkillReadiness))]
        private Object _skillNotReady;
        public ISkillReadiness SkillNotReady => _skillNotReady as ISkillReadiness;

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
            
            //Sets SkillReady or SkillNotReady
            _setStatus[index]();
            
            //Runs Status Action inside SkillReady or SkillNotReady
            SkillStatusAction();
        }

        private void SkillStatusAction()
        {
            _skillLogic.SkillAttributes.SkillReadiness.StatusAction(_skillLogic);
        }

        private void SetSkillReady()
        {
            _skillLogic.SkillAttributes.SkillReadiness = SkillReady;
          
        }

        private void SetSkillNotReady()
        {
            _skillLogic.SkillAttributes.SkillReadiness = SkillNotReady;
        }

    }
}
