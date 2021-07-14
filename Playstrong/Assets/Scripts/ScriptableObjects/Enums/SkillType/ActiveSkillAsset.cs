using Interfaces;
using Logic;
using TMPro;
using UnityEngine;
using Visual;

namespace ScriptableObjects.Enums.SkillType
{
    [CreateAssetMenu(fileName = "Active Skill", menuName = "SO's/Scriptable Enums/Active Skill")]
    public class ActiveSkillAsset : ScriptableObject, IActiveSkillAsset, ISkillType
    {
        [SerializeField] private int _skillCdIndex = 0;
        public int SkillCdIndex => _skillCdIndex;

        public void SkillCooldownDisplay(TextMeshProUGUI cooldown)
        {
            cooldown.enabled = true;
        }

        public void UseActiveSkill(ITargetSkill targetSkill, IHero thisHero, IHero targetHero)
        {
            //TODO: Replace will specific skill event
            //targetSkill.Skill.Hero.HeroLogic.HeroEvents.DragSkillTarget(thisHero, targetHero);
            targetSkill.Skill.SkillLogic.SkillEvents.DragSkillTarget(thisHero, targetHero);
        }
        
        public void UsePassiveSkill(ITargetSkill targetSkill, IHero thisHero, IHero targetHero)
        { }

        

    }
}
