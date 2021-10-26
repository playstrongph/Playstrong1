using System;
using Interfaces;
using ScriptableObjects.Enums;
using ScriptableObjects.Enums.SkillStatus;
using ScriptableObjects.Enums.SkillTarget;
using ScriptableObjects.Enums.SkillType;
using ScriptableObjects.ScriptableEnumScripts.SkillCooldownType;
using ScriptableObjects.SkillEffects;
using UnityEngine;
using Utilities;
using Object = UnityEngine.Object;

namespace ScriptableObjects.Others
{
    [CreateAssetMenu(fileName = "New Hero Skill", menuName = "SO's/Hero Skill")]
    public class HeroSkillAsset : ScriptableObject, IHeroSkillAsset
    {

        [Header("Skill Info")] 
        [SerializeField]
        private string skillName;

        public String SkillName => skillName;

        [TextArea(2, 3)] 
        [SerializeField] 
        private string _description;
        public String Description => _description;

        [Header("Skill Effect")]
        [SerializeField]
        [RequireInterface(typeof(ISkillEffectAsset))]
        private ScriptableObject _skillEffect;
        public ISkillEffectAsset SkillEffect => _skillEffect as ISkillEffectAsset;

        [Header("Skill Type")] [SerializeField]
        [RequireInterface(typeof(ISkillType))]
        private ScriptableObject _skillType;
        public ISkillType SkillType => _skillType as ISkillType;
        
        [Header("Skill Target")] [SerializeField] [RequireInterface(typeof(ISkillTarget))]
        private ScriptableObject _skillTarget;
        
        public ISkillTarget SkillTarget => _skillTarget as ISkillTarget;

        [Header("Skill Cooldown Type")] [SerializeField]
        private ScriptableObject _skillCooldownType;

        public ISkillCooldownTypeAsset SkillCooldownType => _skillCooldownType as ISkillCooldownTypeAsset;

        [Header("Skill Graphic")] 
        [SerializeField]
        private Sprite _skillIcon;

        public Sprite SkillIcon => _skillIcon;

        [Header("Base Cooldown")]
        [SerializeField]
        private int baseCooldown;

        public int BaseCooldown => baseCooldown;

        [Header("Default Settings")] [SerializeField]
        [RequireInterface(typeof(ISkillReadiness))]
        private Object _skillStatus;
        public ISkillReadiness SkillReadiness => _skillStatus as ISkillReadiness;
        






    }
}
