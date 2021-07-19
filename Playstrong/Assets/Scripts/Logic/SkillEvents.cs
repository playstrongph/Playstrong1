using System;
using Interfaces;
using UnityEngine;

namespace Logic
{
    public class SkillEvents : MonoBehaviour, ISkillEvents
    {
        public delegate void SkillEvent(IHero initiatorHero, IHero targetHero);
        public event SkillEvent EDragSkillTarget;

        private ISkillLogic _skillLogic;

        private void Awake()
        {
            _skillLogic = GetComponent<ISkillLogic>();
        }


        public void DragSkillTarget(IHero initiatorHero, IHero targetHero)
        {
            EDragSkillTarget?.Invoke(initiatorHero, targetHero);
           
        }
        
        private void UnsubscribeDragSkillTargetClients()
        {
            var clients = EDragSkillTarget?.GetInvocationList();
            if (clients != null)
                foreach (var client in clients)
                {
                    EDragSkillTarget -= client as SkillEvent;
                }
        }
        
        private void OnDestroy()
        {
            UnsubscribeAllClients();           
        }

        private void UnsubscribeAllClients()
        {
          
            UnsubscribeDragSkillTargetClients();
        }
    }
}
