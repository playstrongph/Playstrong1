using System.Collections;
using Interfaces;
using Logic;
using ScriptableObjects.SkillActionsScripts.BaseClassScripts;
using UnityEngine;

namespace ScriptableObjects.SkillActionsScripts
{
    [CreateAssetMenu(fileName = "IncreaseFightingSpirit", menuName = "SO's/BasicActions/IncreaseFightingSpirit")]
    
    public class IncreaseFightingSpiritBasicActionAsset : BasicActionAsset
    {
        [SerializeField] private int fightingSpiritIncrease;
        
        public override IEnumerator TargetAction(IHero targetHero)
        {
            var logicTree = targetHero.CoroutineTreesAsset.MainLogicTree;
            var fightingSpirit = targetHero.HeroLogic.OtherAttributes.FightingSpirit;
            var newFightingSpirit = fightingSpirit + fightingSpiritIncrease;

            targetHero.HeroLogic.SetHeroFightingSpirit.SetFightingSpirit(newFightingSpirit);

            logicTree.EndSequence();
            yield return null;
        }
        
        public override IEnumerator TargetAction(IHero thisHero, IHero targetHero)
        {
            var logicTree = targetHero.CoroutineTreesAsset.MainLogicTree;
            var fightingSpirit = targetHero.HeroLogic.OtherAttributes.FightingSpirit;
            var newFightingSpirit = fightingSpirit + fightingSpiritIncrease;

            targetHero.HeroLogic.SetHeroFightingSpirit.SetFightingSpirit(newFightingSpirit);

            logicTree.EndSequence();
            yield return null;
        }

       











    }
}
