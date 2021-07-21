using System;
using System.Collections;
using System.Collections.Generic;
using Interfaces;
using UnityEngine;
using DG.Tweening;
using ScriptableObjects.Enums.SkillStatus;
using ScriptableObjects.Enums.SkillTarget;
using ScriptableObjects.Enums.SkillType;
using ScriptableObjects.GameEvents;
using ScriptableObjects.SkillEffects;
using Utilities;
using Object = UnityEngine.Object;

namespace Logic
{
    public class BasicAttack : MonoBehaviour, IBasicAttack, ISkillAttributes
    {
        [SerializeField] private int cooldown;

        public int Cooldown
        {
            get => cooldown;
            set => cooldown = value;

        }
        
        [SerializeField] private int baseCooldown;

        public int BaseCooldown
        {
            get => baseCooldown;
            set => baseCooldown = value;

        }

        [SerializeField] [RequireInterface(typeof(ISkillType))]
        private Object skillType;

        public ISkillType SkillType{
            get => skillType as ISkillType;
            set => skillType = value as Object;
        }
        
        [SerializeField] [RequireInterface(typeof(ISkillTarget))]
        private Object skillTarget;

        public ISkillTarget SkillTarget{
            get => skillTarget as ISkillTarget;
            set => skillTarget = value as Object;
        }
        
        [SerializeField] [RequireInterface(typeof(ISkillStatus))]
        private Object skillStatus;

        public ISkillStatus SkillStatus{
            get => skillStatus as ISkillStatus;
            set => skillStatus = value as Object;
        }
        
        [SerializeField] [RequireInterface(typeof(ISkillEffectAsset))]
        private Object skillEffect;

        public ISkillEffectAsset SkillEffect{
            get => skillEffect as ISkillEffectAsset;
            set => skillEffect = value as Object;
        }



        [SerializeField]
        private int attackIndex;
        
        /// <summary>
        /// value of 0 = Normal Attack
        /// value of 1 = Critical Strike
        /// </summary>
        public int SetAttackIndex
        {
            get => attackIndex;
            set => attackIndex = value;
        }


        [SerializeField] [RequireInterface(typeof(IHeroAction))]
        private List<Object> _attackActions = new List<Object>();

        private List<IHeroAction> AttackActions
        {
            get
            {
                var attackActions = new List<IHeroAction>();
                foreach (var attackAction in _attackActions)
                {
                    attackActions.Add(attackAction as IHeroAction);
                }
                return attackActions;
            }
        }

        public void AddToAttackActions(IHeroAction heroAction)
        {
            var heroActionObject = heroAction as Object;
            _attackActions.Add(heroActionObject);
            
        }

        public void RemoveFromAttackActions(IHeroAction heroAction)
        {
            var heroActionObject = heroAction as Object;
            _attackActions.Remove(heroActionObject);
        }


        /// <summary>
        /// This is a list of other possible critical attack modifiers apart from default
        /// value of 2.  Examples are skills that set the multiplier to 3, or equipment that increase
        /// the critical damage.  An alternative way to implement this is to create a component
        /// 'other attributes' attached and accessed via HeroLogic
        /// </summary>
        [SerializeField] private List<float> criticalAttackModifiers;
        public List<float> CriticalAttackModifiers => criticalAttackModifiers;
        
        
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

        private void Start()
        {
            SkillEffect.RegisterSkillEffect(_heroLogic.Hero);
            SkillEffect.SkillAttributes = this;
        }


        public IEnumerator StartAttack(IHero thisHero, IHero targetHero)
        {
            _thisHero = thisHero;
            _targetHero = targetHero;
           
            _logicTree.AddCurrent(ResetAttackIndex());
            
            _logicTree.AddCurrent(PreAttackEvents());

            _logicTree.AddCurrent(StartAttackActions(thisHero, targetHero));
            
            _logicTree.AddCurrent(PostAttackEvents());

            _logicTree.EndSequence();
            yield return null;
        }

        private IEnumerator StartAttackActions(IHero thisHero, IHero targetHero)
        {
            _logicTree.AddCurrent(AttackActions[SetAttackIndex].StartAction(thisHero, targetHero));
            
            _logicTree.EndSequence();
            yield return null;
        }


        private IEnumerator PreAttackEvents()
        {
            _thisHero.HeroLogic.HeroEvents.BeforeAttacking(_thisHero, _targetHero);
            _targetHero.HeroLogic.HeroEvents.PreAttack(_thisHero,_targetHero);
            
            _logicTree.EndSequence();
            yield return null;
        }
        
        private IEnumerator PostAttackEvents()
        {
            _thisHero.HeroLogic.HeroEvents.AfterAttacking(_thisHero, _targetHero);
            _targetHero.HeroLogic.HeroEvents.PostAttack(_thisHero,_targetHero);
         

            _logicTree.EndSequence();
            yield return null;
        }
        
        /// <summary>
        /// Set the attack back to normal attack
        /// </summary>
        /// <returns></returns>
        private IEnumerator ResetAttackIndex()
        {
            var normalAttackIndex = 0;
            SetAttackIndex = normalAttackIndex;

            _logicTree.EndSequence();
            yield return null;
        }

    }
}
