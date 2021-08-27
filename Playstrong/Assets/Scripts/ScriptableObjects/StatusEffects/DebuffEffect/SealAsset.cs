using Interfaces;
using Logic;
using References;
using UnityEngine;

namespace ScriptableObjects.StatusEffects.DebuffEffect
{
    [CreateAssetMenu(fileName = "Seal", menuName = "SO's/Status Effects/Debuffs/Seal")]
    public class SealAsset : StatusEffectAsset
    {

        [SerializeField] private ScriptableObject _enablePassiveSkillsAction;
        private IHeroAction EnablePassiveSkillsAction => _enablePassiveSkillsAction as IHeroAction;
        
        
        public override void ApplyStatusEffect(IHero targetHero)
        {
            targetHero.HeroLogic.HeroEvents.EHeroStartTurn += ApplySealEffect;
        }
        
        public override void UnapplyStatusEffect(IHero targetHero)
        {
            var logicTree = targetHero.CoroutineTreesAsset.MainLogicTree;
            var dummyValue = 0f;
            
            targetHero.HeroLogic.HeroEvents.EHeroStartTurn -= ApplySealEffect;
            
            EnablePassiveSkillsAction.StartAction(targetHero, dummyValue);
        }

        private void ApplySealEffect(IHero targetHero)
        {
            var logicTree = targetHero.CoroutineTreesAsset.MainLogicTree;
            var dummyValue = 0f;
            
            logicTree.AddCurrent(SkillActionAsset.StartAction(targetHero,dummyValue));
        }
       








    }
}
