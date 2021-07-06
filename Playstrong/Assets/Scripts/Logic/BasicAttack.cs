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
        private ICoroutineTree _logicTree;
        private ICoroutineTree _visualTree;

        private IHeroLogic _thisHeroLogic;
        
        private int _attackModifier = 1;
        private int _finalAttackValue;
        
        private IHero _thisHero;
       
        
        private void Awake()
        {
            _thisHeroLogic = GetComponent<IHeroLogic>();
            _thisHero = _thisHeroLogic.Hero;
       
        }

        private void Start()
        {
            _logicTree = _thisHero.CoroutineTreesAsset.MainLogicTree;
            _visualTree = _thisHero.CoroutineTreesAsset.MainVisualTree;
        }

        [SerializeField]
        [RequireInterface(typeof(IHeroAction))]
        private Object _attackAction;
        public IHeroAction AttackAction => _attackAction as IHeroAction;

        [SerializeField] private List<int> _finalAttackModifiers;
        public List<int> FinalAttackModifiers => _finalAttackModifiers;











    }
}
