using System;
using System.Collections;
using System.Collections.Generic;
using Interfaces;
using UnityEngine;

namespace Logic
{
    public class DealDamage : MonoBehaviour, IDealDamage
    {
        private IHeroLogic _heroLogic;

        [SerializeField] private int _normalDamage;

        private int NormalDamage
        {
            get => _normalDamage;
            set => _normalDamage = value;
        }

        [SerializeField]
        private int _otherDamage;

        public int OtherDamage
        {
            get => _otherDamage;
            set => _otherDamage = value;
        }
        
        private void Awake()
        {
            _heroLogic = GetComponent<IHeroLogic>();
        }
        
        public IEnumerator DealAttackDamage(IHero attackerHero, IHero targetHero, int attackPower, float criticalFactor)
        {
            var logicTree = targetHero.CoroutineTreesAsset.MainLogicTree;
            
            NormalDamage = attackPower + OtherDamage;
            
            var criticalDamage = Mathf.CeilToInt(criticalFactor * NormalDamage);
            
            logicTree.AddCurrent(targetHero.HeroLogic.TakeDamage.TakeAllDamage(NormalDamage, criticalDamage));

            logicTree.EndSequence();
            yield return null;
        }
        
        public IEnumerator DealDirectDamage(IHero targetHero, int normalDamage)
        {
            var logicTree = targetHero.CoroutineTreesAsset.MainLogicTree;
            var criticalDamage = 0;
            
            logicTree.AddCurrent(targetHero.HeroLogic.TakeDamage.TakeAllDamage(normalDamage,criticalDamage));
            
            logicTree.EndSequence();
            yield return null;
        }
        
        


       






     




    }
}
