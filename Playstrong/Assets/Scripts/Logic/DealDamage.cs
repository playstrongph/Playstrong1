using System;
using System.Collections;
using Interfaces;
using UnityEngine;

namespace Logic
{
    public class DealDamage : MonoBehaviour, IDealDamage
    {
        private IHeroLogic _heroLogic;

        public int FinalDamageDealt { get; set; }

        private void Awake()
        {
            _heroLogic = GetComponent<IHeroLogic>();
        }

        public IEnumerator DealDamageHero(IHero targetHero, int finalAttackValue)
        {
            var logicTree = targetHero.CoroutineTreesAsset.MainLogicTree;
            
            logicTree.AddCurrent(targetHero.HeroLogic.TakeDamage.DamageHero(finalAttackValue));
            
            logicTree.EndSequence();
            yield return null;
        }


    }
}
