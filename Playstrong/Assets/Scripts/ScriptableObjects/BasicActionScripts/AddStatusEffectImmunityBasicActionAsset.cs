using System.Collections;
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

        [SerializeField]
        private ScriptableObject statusEffectImmunityAsset;
        
        private IHeroStatusEffectImmunity StatusEffectImmunityAsset => statusEffectImmunityAsset as IHeroStatusEffectImmunity;

        public override IEnumerator TargetAction(IHero thisHero, IHero targetHero)
        {
            var logicTree = targetHero.CoroutineTreesAsset.MainLogicTree;
            
            
            
            
           
            logicTree.EndSequence();
            yield return null;

        }


    }
}
