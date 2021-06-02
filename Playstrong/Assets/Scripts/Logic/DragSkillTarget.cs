using System;
using System.Collections.Generic;
using Interfaces;
using UnityEngine;

namespace Logic
{
    public class DragSkillTarget : MonoBehaviour, IDragSkillTarget
    {
        private ITargetSkill _targetSkill;
        private IHero _thisHero;
        private IHero _targetHero;

        private Action _skillTargetHero;

        private List<IHero> _validTargets = new List<IHero>();

        private ICoroutineTree _logicTree;

        private IGetSkillTargets _getSkillTargets;
        private IEndHeroTurn _endHeroTurn;

        private void Awake()
        {
            _targetSkill = GetComponent<ITargetSkill>();
            _getSkillTargets = GetComponent<IGetSkillTargets>();

            _skillTargetHero = NoAction;
        }
        
        
        

        public void NoAction() { }

    }
}
