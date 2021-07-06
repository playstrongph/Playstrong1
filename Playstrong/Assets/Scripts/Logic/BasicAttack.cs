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
        public IHeroAction AttackAction => _attackAction as IHeroAction;

        [SerializeField] private List<int> _finalAttackModifiers;
        public List<int> FinalAttackModifiers => _finalAttackModifiers;

    }
}
