using System.Collections;
using Interfaces;
using Logic;
using ScriptableObjects.Actions.BaseClassScripts;
using ScriptableObjects.StatusEffects;
using UnityEngine;
using Utilities;

namespace ScriptableObjects.Actions
{
    [CreateAssetMenu(fileName = "CriticalStrikeSkill", menuName = "SO's/SkillActions/CriticalStrikeSkill")]
    
    public class CriticalStrikeSkillAction : SkillActionAsset
    {

        [SerializeField] [RequireInterface(typeof(IHeroAction))]
        private Object _criticalStrikeActionAsset;

        public IHeroAction CriticalStrikeActionAsset => _criticalStrikeActionAsset as IHeroAction;

        public override IEnumerator ActionTarget(IHero thisHero, IHero targetHero)
        {
            InitializeValues(thisHero, targetHero);
            
            //LogicTree.AddCurrent(AddBuffCoroutine(BuffAsset, BuffCounters));
           
            LogicTree.EndSequence();
           yield return null;

        }

        private void RegisterActions()
        {
            ThisHero.HeroLogic.HeroEvents.EBeforeAttacking += AddCriticalStrikeAsset;
            ThisHero.HeroLogic.HeroEvents.EAfterAttacking += RemoveCriticalStrikeAsset;
        }
        
        private void UnregisterActions()
        {
            ThisHero.HeroLogic.HeroEvents.EBeforeAttacking -= AddCriticalStrikeAsset;
            ThisHero.HeroLogic.HeroEvents.EAfterAttacking -= RemoveCriticalStrikeAsset;
        }

        private void AddCriticalStrikeAsset(IHero thisHero, IHero targetHero)
        {
            ThisHero.HeroLogic.BasicAttack.AddToAttackActions(CriticalStrikeActionAsset);
        }

        private void RemoveCriticalStrikeAsset(IHero thisHero, IHero targetHero)
        {
            ThisHero.HeroLogic.BasicAttack.RemoveFromAttackActions(CriticalStrikeActionAsset);
        }










    }
}
