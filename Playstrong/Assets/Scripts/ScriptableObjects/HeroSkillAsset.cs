using System;
using Interfaces;
using ScriptableObjects.Enums;
using UnityEngine;
using Utilities;


namespace ScriptableObjects
{
    [CreateAssetMenu(fileName = "New Hero Skill", menuName = "SO's/Hero Skill")]
    public class HeroSkillAsset : ScriptableObject, IHeroSkillAsset
    {

        [Header("Skill Info")] 
        [SerializeField]
        private string _name;

        public String Name => _name;

        [TextArea(2, 3)] 
        [SerializeField] 
        private string _description;
        public String Description => _description;

        [Header("Skill Type")] [SerializeField]
        [RequireInterface(typeof(ISkillType))]
        private ScriptableObject _skillType;

        public ISkillType SkillType => _skillType as ISkillType;

        [Header("Skill Graphic")] 
        [SerializeField]
        private Sprite _skillIcon;

        public Sprite SkillIcon => _skillIcon;

        [Header("Skill Cooldown")]
        [SerializeField]
        private int _cooldown;

        public int Cooldown => _cooldown;
        
        //TODO
        //Skill Logic Asset
        //Other Skill Attributes: SKillType(Active), SkillTarget(Any), DragType(SkillAttack)
        



    }
}
