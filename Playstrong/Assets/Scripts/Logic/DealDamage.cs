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

        [SerializeField] private int finalDamageDealt;

        public int FinalDamageDealt
        {
            get => finalDamageDealt;
            set => finalDamageDealt = value;
        }

        [Header("TEST FIELDS")]
        
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


        [SerializeField] private List<float> _criticalFactor = new List<float>();
        public List<float> CriticalFactor => _criticalFactor;
        
        private void Awake()
        {
            _heroLogic = GetComponent<IHeroLogic>();
        }

        public IEnumerator DealDamageHero(IHero attackerHero, IHero targetHero, int finalAttackValue)
        {
            var logicTree = targetHero.CoroutineTreesAsset.MainLogicTree;
            
            logicTree.AddCurrent(targetHero.HeroLogic.TakeDamage.DamageHero(finalAttackValue, attackerHero));

            logicTree.EndSequence();
            yield return null;
        }
        
        //TEST START - DEALDAMAGEHEROTEST
        public IEnumerator DealDamageHeroTest(IHero attackerHero, IHero targetHero, int attackPower, float criticalFactor)
        {
            var logicTree = targetHero.CoroutineTreesAsset.MainLogicTree;
            

            NormalDamage = attackPower + OtherDamage;
            var criticalDamage = Mathf.FloorToInt(criticalFactor * NormalDamage);
            
            logicTree.AddCurrent(targetHero.HeroLogic.TakeDamage.DamageHeroTest(NormalDamage, criticalDamage, attackerHero));

            logicTree.EndSequence();
            yield return null;
        }
        
        //TEST END


       






     




    }
}
