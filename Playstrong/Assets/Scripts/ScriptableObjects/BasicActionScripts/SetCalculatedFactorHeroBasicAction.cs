using System.Collections;
using Interfaces;
using Logic;
using ScriptableObjects.CalculatedFactorValue;
using UnityEngine;

namespace ScriptableObjects.BasicActions
{
    [CreateAssetMenu(fileName = "SetCalculatedFactorHero", menuName = "SO's/BasicActions/SetCalculatedFactorHero")]
    
    public class SetCalculatedFactorHeroBasicAction : BasicActionAsset
    {
        
        [SerializeField] private ScriptableObject damageFactor;
        
        private ICalculatedFactorValueAsset DamageFactor  => damageFactor as ICalculatedFactorValueAsset;
        
        public override IEnumerator TargetAction(IHero targetHero)
        {
            var logicTree = targetHero.CoroutineTreesAsset.MainLogicTree;
            
            DamageFactor.SetHeroBasis(targetHero);
            //Debug.Log("HeroBasis: " +targetHero.HeroName);
            
            logicTree.EndSequence();
            yield return null;
        }
        
        public override IEnumerator TargetAction(IHero thisHero, IHero targetHero)
        {
            var logicTree = targetHero.CoroutineTreesAsset.MainLogicTree;
            
            DamageFactor.SetHeroBasis(targetHero);
            //Debug.Log("HeroBasis: " +targetHero.HeroName);
            
            logicTree.EndSequence();
            yield return null;
        }
        
       
      










    }
}
