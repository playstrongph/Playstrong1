using System.Collections;
using System.Collections.Generic;
using Interfaces;
using Logic;
using References;
using ScriptableObjects.Enums.SkillStatus;
using ScriptableObjects.SkillCondition.BaseClassScripts;
using UnityEngine;
using Utilities;

namespace ScriptableObjects.GameEvents
{
    
    /// <summary>
    /// Base class for game event scriptable objects
    /// </summary>
    public class GameEvents : ScriptableObject, IGameEvents
    {
        [SerializeField] [RequireInterface(typeof(ISkillConditionAsset))]
        private List<Object> skillConditionAssets;

        protected List<ISkillConditionAsset> SkillConditionAssets
        {
            get
            {
                var skillConditions = new List<ISkillConditionAsset>();
                foreach (var skillConditionObject in skillConditionAssets)
                {
                    var skillCondition = skillConditionObject as ISkillConditionAsset;
                    skillConditions.Add(skillCondition);
                }

                return skillConditions;
            }
        }

        protected ICoroutineTree LogicTree;

        public void SubscribeToHeroEvents(IHero hero)
        {
            LogicTree = hero.CoroutineTreesAsset.MainLogicTree;
            LogicTree.AddCurrent(SubscribeToHeroEventsCoroutine(hero));

            SetSkillAttributesReference(hero);
        }
        
        /// <summary>
        /// Basic Attack and Passive Skills subscribe here since they'll be using hero events
        /// </summary>
        protected virtual IEnumerator SubscribeToHeroEventsCoroutine(IHero hero)
        {
            LogicTree.EndSequence();  
            yield return null;
            
        }
        
        public void SubscribeToSkillEvents(ISkill skill)
        {
            LogicTree = skill.Hero.CoroutineTreesAsset.MainLogicTree;
            LogicTree.AddCurrent(SubscribeToSkillEventsCoroutine(skill));
            
            SetSkillAttributesReference(skill);
        }
        
        /// <summary>
        /// Active skills shall subscribe here, since DragSkillTarget events should be
        /// unique per skill - not per hero.
        /// </summary>
        /// <param name="skill"></param>
        /// <returns></returns>
        protected virtual IEnumerator SubscribeToSkillEventsCoroutine(ISkill skill)
        {
            LogicTree.EndSequence();  
            yield return null;
            
        }
        
        
        private void SetSkillAttributesReference(ISkill skill)
        {
            foreach (var skillCondition in SkillConditionAssets)
            {
                skillCondition.SkillAttributes = skill.SkillLogic.SkillAttributes;
            }
        }
        
        private void SetSkillAttributesReference(IHero hero)
        {
            foreach (var skillCondition in SkillConditionAssets)
            {
                skillCondition.SkillAttributes = hero.HeroLogic.BasicAttackSkillAttributes;
            }
        }







    }
}
