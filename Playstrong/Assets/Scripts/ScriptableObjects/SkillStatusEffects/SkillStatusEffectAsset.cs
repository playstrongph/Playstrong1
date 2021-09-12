using System.Collections;
using Interfaces;
using Logic;
using References;
using ScriptableObjects.StandardActions;
using ScriptableObjects.StatusEffects.Instance;
using ScriptableObjects.StatusEffects.StatusEffectCounter;
using ScriptableObjects.StatusEffects.StatusEffectType;
using UnityEngine;
using UnityEngine.UI;
using Utilities;

namespace ScriptableObjects.StatusEffects
{
    public class SkillStatusEffectAsset : ScriptableObject
    {
        [SerializeField] private string _name;
        public string Name => _name;

        [TextArea(1,2)]
        [SerializeField] private string _description;
        public string Description => _description;
        
        //TODO: Create SkillStatusEffectType - types are SkillBuffs and SkillDebuffs
        /*[SerializeField] 
        [RequireInterface(typeof(IStatusEffectType))]
        private ScriptableObject _statusEffectType;        
        public IStatusEffectType StatusEffectType => _statusEffectType as IStatusEffectType;*/
        
        //TODO: Create SkillStatusEffectCounterUpdate - event based
        /*[SerializeField] [RequireInterface(typeof(IStatusEffectCounterUpdate))]
        private ScriptableObject updateTiming;
        public IStatusEffectCounterUpdate UpdateTiming => updateTiming as IStatusEffectCounterUpdate;*/

        //TODO: Create SKillStatus Effect Instance - Single, Multiple 
        /*[SerializeField] [RequireInterface(typeof(IStatusEffectInstance))]
        private ScriptableObject _statusEffectInstance;
        public IStatusEffectInstance StatusEffectInstance => _statusEffectInstance as IStatusEffectInstance;*/

        [SerializeField] private ScriptableObject _standardAction;
        public IStandardActionAsset StandardAction => _standardAction as IStandardActionAsset;

        public IHero CasterHero { get; set; }
        public IHeroStatusEffect LocalSkillStatusEffectReference { get; set; }

        
        public virtual void ApplyStatusEffect(IHero hero)
        {
        }

        public virtual void UnapplyStatusEffect(IHero hero)
        {
            
        }
        public virtual IEnumerator StartStandardAction(IHero hero)
        {
            var logicTree = hero.CoroutineTreesAsset.MainLogicTree;
            
            logicTree.EndSequence();
            yield return null;
        }
        
        
        //TODO: Check if this is still required
        public virtual void StartEventStatusEffect(IHero hero)
        {
            
        }
        
        //TODO: Check if this is still required
        public virtual void RemoveStatusEffect(IHero hero)
        {
          
        }





    }
}
