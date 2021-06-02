using System;
using System.Collections;
using System.Collections.Generic;
using Interfaces;
using UnityEngine;
using Visual;

namespace Logic
{
    public class DragSkillTarget : MonoBehaviour, IDragSkillTarget
    {
        private ITargetSkill _targetSkill;
        
        private ITargetHero _thisHero;
        private ITargetHero _targetHero;

        private Action _skillTargetHero;

        private List<IHero> _validTargets = new List<IHero>();

        

        private IGetSkillTargets _getSkillTargets;
        private IEndHeroTurn _endHeroTurn;

        private void Awake()
        {
            _targetSkill = GetComponent<ITargetSkill>();
            _getSkillTargets = GetComponent<IGetSkillTargets>();

            _skillTargetHero = NoAction;
        }

        private void Start()
        {
            
        }

        private IEnumerator GetValidTargets()
        {
            var logicTree = _targetSkill.Skill.CoroutineTreesAsset.MainLogicTree;

            _validTargets = _getSkillTargets.GetValidTargets();
            
            yield return null;
            logicTree.EndSequence();
        }

        private void SetTarget()
        {
            var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            
            var hits = Physics.RaycastAll(ray);
            foreach (var hit in hits)
            {
                if (hit.transform.GetComponent<ITargetHero>() != null)
                {
                    var targetHero = hit.transform.GetComponent<ITargetHero>();

                    if (_validTargets.Contains(targetHero.Hero))
                    {
                        _targetHero = targetHero;
                        
                        //_basicAttackTarget = BasicAttackTarget;
                    }
                }
            }
            
        }


        public void NoAction() { }

    }
}
