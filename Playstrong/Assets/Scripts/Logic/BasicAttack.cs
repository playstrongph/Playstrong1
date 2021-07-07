using System;
using System.Collections;
using System.Collections.Generic;
using Interfaces;
using UnityEngine;
using DG.Tweening;
using Utilities;
using Object = UnityEngine.Object;

namespace Logic
{
    public class BasicAttack : MonoBehaviour, IBasicAttack
    {

        [SerializeField]
        [RequireInterface(typeof(IHeroAction))]
        private Object _attackAction;
        private IHeroAction AttackAction => _attackAction as IHeroAction;

        /// <summary>
        /// This is a list of other possible attack modifiers that are 'unique' - i.e.
        /// they only have 1 value and could not vary. Default setting is a value of 1.
        /// </summary>
        [SerializeField] private List<float> uniqueAttackModifiers;
        public List<float> UniqueAttackModifiers => uniqueAttackModifiers;
        
        
        private IHeroLogic _heroLogic;
        private ICoroutineTree _logicTree;
        private IHero _thisHero;
        private IHero _targetHero;
        
       

        private void Awake()
        {
            _heroLogic = GetComponent<IHeroLogic>();
            _logicTree = _heroLogic.Hero.CoroutineTreesAsset.MainLogicTree;
        }

        public IEnumerator StartAttack(IHero thisHero, IHero targetHero)
        {
            _thisHero = thisHero;
            _targetHero = targetHero;
            
            _logicTree.AddCurrent(PreAttackEvents());
            _logicTree.AddCurrent(AttackAction.StartAction(_thisHero, _targetHero));
            _logicTree.AddCurrent(PostAttackEvents());
            
            _logicTree.EndSequence();
            yield return null;


        }


        private IEnumerator PreAttackEvents()
        {
            //Pre-Attack Events
            _thisHero.HeroLogic.HeroEvents.PreAttack(_thisHero,_targetHero);
            //if criticalFactor > 1, Pre Critical Strike Event
            _targetHero.HeroLogic.HeroEvents.BeforeAttack(_thisHero, _targetHero);

            _logicTree.EndSequence();
            yield return null;
        }
        
        private IEnumerator PostAttackEvents()
        {
            //Pre-Attack Events
            _thisHero.HeroLogic.HeroEvents.PostAttack(_thisHero,_targetHero);
            //if criticalFactor > 1, Pre Critical Strike Event
            _targetHero.HeroLogic.HeroEvents.AfterAttack(_thisHero, _targetHero);

            _logicTree.EndSequence();
            yield return null;
        }
        
    }
}
