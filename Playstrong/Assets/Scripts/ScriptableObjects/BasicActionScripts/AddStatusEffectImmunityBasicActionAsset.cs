using System.Collections;
using System.Collections.Generic;
using Interfaces;
using Logic;
using ScriptableObjects.StatusEffects;
using UnityEngine;
using Utilities;

namespace ScriptableObjects.BasicActionScripts
{
    [CreateAssetMenu(fileName = "AddStatusEffectImmunity", menuName = "SO's/BasicActions/AddStatusEffectImmunity")]
    
    public class AddStatusEffectImmunityBasicActionAsset : BasicActionAsset
    {

        [SerializeField] private List<ScriptableObject> statusEffectImmunities;

        public override IEnumerator TargetAction(IHero thisHero, IHero targetHero)
        {
            var logicTree = targetHero.CoroutineTreesAsset.MainLogicTree;

            AddImmunity(targetHero);

            logicTree.EndSequence();
            yield return null;
        }
        
        public override IEnumerator TargetAction(IHero targetHero)
        {
            var logicTree = targetHero.CoroutineTreesAsset.MainLogicTree;

            AddImmunity(targetHero);

            logicTree.EndSequence();
            yield return null;
        }

        private void AddImmunity(IHero targetHero)
        {
            var heroImmunitiesList = targetHero.HeroLogic.StatusEffectImmunityList;

            foreach (var statusEffectImmunityObject in statusEffectImmunities)
            {
                var statusEffectImmunity = statusEffectImmunityObject as IHeroStatusEffectImmunity;
                heroImmunitiesList.AddToStatusEffectImmunityList(statusEffectImmunity);
            }
        }


    }
}
