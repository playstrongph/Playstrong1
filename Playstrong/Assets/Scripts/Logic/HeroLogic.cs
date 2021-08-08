using System;
using System.Runtime.Remoting.Messaging;
using Interfaces;
using ScriptableObjects;
using ScriptableObjects.HeroLivingStatus;
using ScriptableObjects.Others;
using UnityEngine;
using Utilities;
using Object = UnityEngine.Object;

namespace Logic
{
    
    /// <summary>
    /// HeroLogic Reference Scripts
    /// Objects are set in the Inspector
    /// </summary>
    public class HeroLogic : MonoBehaviour, IHeroLogic
    {
        [SerializeField] [RequireInterface(typeof(IHeroStatusAsset))]
        private ScriptableObject _heroStatus;
       
        public IHeroStatusAsset HeroStatus
        {
            get { return _heroStatus as IHeroStatusAsset;}
            set { _heroStatus = value as ScriptableObject;}
        }

        [SerializeField] [RequireInterface(typeof(ITargetStatus))]
        private ScriptableObject _targetStatus;

        public ITargetStatus TargetStatus
        {
            get => _targetStatus as ITargetStatus;
            set => _targetStatus = value as ScriptableObject;
        }

        [SerializeField] [RequireInterface(typeof(IHeroLivingStatusAsset))]
        private Object _heroLivingStatus;

        public IHeroLivingStatusAsset HeroLivingStatus
        {
            get => _heroLivingStatus as IHeroLivingStatusAsset;
            set => _heroLivingStatus = value as Object;
        }


        [SerializeField] [RequireInterface(typeof(IHero))]
        private Object _hero;

        public IHero Hero
        {
            get => _hero as IHero;
           
        }

        [SerializeField]
        [RequireInterface(typeof(IHeroAttributes))]
        private Object _heroAttributes;

        public IHeroAttributes HeroAttributes
        {
            get => _heroAttributes as IHeroAttributes;
           
        }

        [SerializeField] [RequireInterface(typeof(IHeroTimer))]
        private Object _heroTimer;

        public IHeroTimer HeroTimer => _heroTimer as IHeroTimer;

        [SerializeField]
        [RequireInterface(typeof(ILoadHeroAttributes))]
        private Object _loadHeroAttributes;

        public ILoadHeroAttributes LoadHeroAttributes => _loadHeroAttributes as ILoadHeroAttributes;

        private IBasicAttack _basicAttack;
        public IBasicAttack BasicAttack => _basicAttack;

        private ITakeDamage _takeDamage;
        public ITakeDamage TakeDamage => _takeDamage;

        private IEndHeroTurn _endHeroTurn;
        public IEndHeroTurn EndHeroTurn => _endHeroTurn;

        private ISetHeroAttack _setHeroAttack;
        public ISetHeroAttack SetHeroAttack => _setHeroAttack;

        private ISetHeroSpeed _setHeroSpeed;
        public ISetHeroSpeed SetHeroSpeed => _setHeroSpeed;

        private ISetHeroHealth _setHeroHealth;
        public ISetHeroHealth SetHeroHealth => _setHeroHealth;

        private ISetHeroArmor _setHeroArmor;
        public ISetHeroArmor SetHeroArmor => _setHeroArmor;

        private IHeroEvents _heroEvents;

        public IHeroEvents HeroEvents => _heroEvents;

        private ISkillAttributes _basicAttackSkillAttributes;
        public ISkillAttributes BasicAttackSkillAttributes => _basicAttackSkillAttributes;

        private IDealDamage _dealDamage;
        public IDealDamage DealDamage => _dealDamage;

        private IHeroDies _heroDies;
        public IHeroDies HeroDies => _heroDies;

        private IOtherAttributes _otherAttributes;

        public IOtherAttributes OtherAttributes => _otherAttributes;

        private void Awake()
        {
            _basicAttack = GetComponent<IBasicAttack>();
            _takeDamage = GetComponent<ITakeDamage>();
            _endHeroTurn = GetComponent<IEndHeroTurn>();
            _setHeroAttack = GetComponent<ISetHeroAttack>();
            _setHeroSpeed = GetComponent<ISetHeroSpeed>();
            _setHeroHealth = GetComponent<ISetHeroHealth>();
            _setHeroArmor = GetComponent<ISetHeroArmor>();
            _heroEvents = GetComponent<IHeroEvents>();
            _basicAttackSkillAttributes = GetComponent<ISkillAttributes>();
            _dealDamage = GetComponent<IDealDamage>();
            _heroDies = GetComponent<IHeroDies>();
            _otherAttributes = GetComponent<IOtherAttributes>();
        }
    }
}
