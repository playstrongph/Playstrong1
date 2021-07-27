using System;
using System.Collections;
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
            
            //TEST
            //targetHero.HeroLogic.TakeDamage.DamageHeroTest(finalAttackValue, attackerHero);

            logicTree.EndSequence();
            yield return null;
        }

        


    }
}
