using System.Collections;
using Interfaces;
using Logic;
using ScriptableObjects.Enums.SkillStatus;
using ScriptableObjects.StatusEffects;
using UnityEngine;

namespace ScriptableObjects.BasicActions
{
    [CreateAssetMenu(fileName = "CheckSkillReadiness", menuName = "SO's/BasicConditions/CheckSkillReadiness")]
    
    public class CheckSkillReadinessBasicConditionAsset : BasicConditionAsset
    {

        [Header("Skill Ready Reference")]
        [SerializeField] private ScriptableObject skillReadyAsset;
        private ISkillReadiness SkillReadyAsset => skillReadyAsset as ISkillReadiness;


        protected override int CheckBasicCondition(IHero thisHero)
        {
            var skillReadiness = SkillReference.SkillLogic.SkillAttributes.SkillReadiness;
            return skillReadiness == SkillReadyAsset ? 1 : 0;
        }
        
        protected override int CheckBasicCondition(IHero thisHero,IHero targetHero)
        {
            var skillReadiness = SkillReference.SkillLogic.SkillAttributes.SkillReadiness;
            return skillReadiness == SkillReadyAsset ? 1 : 0;
        }
   



    }
}
