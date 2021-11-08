using System.Collections;
using Interfaces;
using Logic;
using ScriptableObjects.CalculatedFactorValue;
using ScriptableObjects.SkillActionsScripts.BaseClassScripts;
using UnityEngine;

namespace ScriptableObjects.SkillActionsScripts
{
    [CreateAssetMenu(fileName = "IncreaseFightingSpirit", menuName = "SO's/BasicActions/I/IncreaseFightingSpirit")]
    
    public class IncreaseFightingSpiritBasicActionAsset : BasicActionAsset
    {
        [SerializeField] private int flatFightingSpiritIncrease;

        [SerializeField] private ScriptableObject calculatedFactor;
        private ICalculatedFactorValueAsset CalculatedFactor => calculatedFactor as ICalculatedFactorValueAsset;
        
        public override IEnumerator TargetAction(IHero targetHero)
        {
            var logicTree = targetHero.CoroutineTreesAsset.MainLogicTree;
            var fightingSpirit = targetHero.HeroLogic.OtherAttributes.FightingSpirit;

            var newFightingSpirit =  Mathf.FloorToInt(fightingSpirit + flatFightingSpiritIncrease*CalculatedFactor.GetCalculatedValue()); 

            targetHero.HeroLogic.SetHeroFightingSpirit.SetFightingSpirit(newFightingSpirit);

            logicTree.EndSequence();
            yield return null;
        }
        
        public override IEnumerator TargetAction(IHero thisHero, IHero targetHero)
        {
            var logicTree = targetHero.CoroutineTreesAsset.MainLogicTree;
            var fightingSpirit = targetHero.HeroLogic.OtherAttributes.FightingSpirit;
            
            var newFightingSpirit =  Mathf.FloorToInt(fightingSpirit + flatFightingSpiritIncrease*CalculatedFactor.GetCalculatedValue());

            targetHero.HeroLogic.SetHeroFightingSpirit.SetFightingSpirit(newFightingSpirit);

            logicTree.EndSequence();
            yield return null;
        }

       











    }
}
