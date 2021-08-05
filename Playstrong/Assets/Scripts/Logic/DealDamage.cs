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
        
        //TEST START - NEW DEAL DAMAGE

        [Header("TEST FIELDS")]
        
        [SerializeField] private int _normalDamage;
        public int NormalDamage => _normalDamage;

        [SerializeField] private int _criticalDamage;
        public int CriticalDamage => _criticalDamage;

        private int _otherDamage;

        public int OtherDamage
        {
            get => _otherDamage;
            set => _otherDamage = value;
        }


        [SerializeField] private List<float> _criticalFactor = new List<float>();
        public List<float> CriticalFactor => _criticalFactor;


       






        //TEST END




    }
}
