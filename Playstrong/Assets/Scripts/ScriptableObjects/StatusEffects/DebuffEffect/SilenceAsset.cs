using Interfaces;
using Logic;
using References;
using UnityEngine;

namespace ScriptableObjects.StatusEffects.DebuffEffect
{
    [CreateAssetMenu(fileName = "Silence", menuName = "SO's/Status Effects/Debuffs/Silence")]
    public class SilenceAsset : StatusEffectAsset
    {

        [SerializeField] private ScriptableObject _enableActiveSkillsAction;
        private IHeroAction EnableActiveSkillsAction => _enableActiveSkillsAction as IHeroAction;
        
        
        public override void ApplyStatusEffect(IHero targetHero)
        {
            targetHero.HeroLogic.HeroEvents.EHeroStartTurn += ApplySilenceEffect;
        }
        
        public override void UnapplyStatusEffect(IHero targetHero)
        {
            var logicTree = targetHero.CoroutineTreesAsset.MainLogicTree;
            var dummyValue = 0f;
            
            targetHero.HeroLogic.HeroEvents.EHeroStartTurn -= ApplySilenceEffect;
            
            logicTree.AddCurrent(EnableActiveSkillsAction.StartAction(targetHero,dummyValue));
            
        }

        private void ApplySilenceEffect(IHero targetHero)
        {
            var logicTree = targetHero.CoroutineTreesAsset.MainLogicTree;
            var dummyValue = 0f;
            
            logicTree.AddCurrent(SkillActionAsset.StartAction(targetHero,dummyValue));
        }
       








    }
}
