using System.Collections;
using Interfaces;
using Logic;
using ScriptableObjects.StatusEffects;
using UnityEngine;

namespace ScriptableObjects.BasicActions
{
    
    /// <summary>
    /// This is different from Dispel - removal can't be prevented
    /// </summary>
    [CreateAssetMenu(fileName = "RemoveStatusEffect", menuName = "SO's/BasicActions/RemoveStatusEffect")]
    public class RemoveStatusEffectBasicActionAsset : BasicActionAsset
    {
        [SerializeField] private ScriptableObject _heroStatusEffect;
        private IStatusEffectAsset HeroStatusEffect => _heroStatusEffect as IStatusEffectAsset;
        
        
        public override IEnumerator TargetAction(IHero targetHero)
        {
            var logicTree = targetHero.CoroutineTreesAsset.MainLogicTree;

            RemoveHeroStatusEffect(targetHero);
            
            logicTree.EndSequence();
            yield return null;
        }
        
        public override IEnumerator UndoTargetAction(IHero targetHero)
        {
            var logicTree = targetHero.CoroutineTreesAsset.MainLogicTree;
            
            //There is no UndoAction
            
            logicTree.EndSequence();
            yield return null;
        }

        private void RemoveHeroStatusEffect(IHero targetHero)
        {
            var heroBuffEffects = targetHero.HeroStatusEffects.HeroBuffEffects.HeroBuffs;
            var heroDebuffEffects = targetHero.HeroStatusEffects.HeroDebuffEffects.HeroDebuffs;

            foreach (var buff in heroBuffEffects)
            {
                if (buff.Name == HeroStatusEffect.Name)
                {
                    buff.RemoveStatusEffect.RemoveEffect(targetHero);
                }
            }
            
            foreach (var debuff in heroDebuffEffects)
            {
                if (debuff.Name == HeroStatusEffect.Name)
                {
                    debuff.RemoveStatusEffect.RemoveEffect(targetHero);
                }
            }
        }












    }
}
