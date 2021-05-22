using System.Collections.Generic;
using Interfaces;
using Logic;
using UnityEngine;
using Utilities;


namespace ScriptableObjects
{
    [CreateAssetMenu(fileName = "New Hero", menuName = "SO's/New Hero")]
    public class HeroAsset : ScriptableObject, IHeroAsset
    {

        
        
        [Header("Hero Info")] 
        [SerializeField]
        private string _name;
        public string Name => _name;
        
        [SerializeField]
        private string _description;
        public string Description => _description;

        [Header("Hero Graphic")] 
        [SerializeField]
        private Sprite _heroSprite;
        public Sprite HeroSprite => _heroSprite;

        [Header("Hero Stats")] 
        [SerializeField]
        private int _health;
        public int Health => _health; 
        
        [SerializeField]
        private int _attack;
        public int Attack => _attack;
        
        [SerializeField]
        private int _speed;
        public int Speed  => _speed; 
        
        [SerializeField]
        private int _chance;
        public int Chance => _chance; 
        
        [SerializeField]
        private int _armor;
        public int Armor => _armor;
        
        [Header("Other Hero Attributes")]
        [SerializeField] [RequireInterface(typeof(IRarityEnumAsset))]
        private ScriptableObject _rarity;
        public IRarityEnumAsset Rarity => _rarity as IRarityEnumAsset;
        
        [SerializeField] [RequireInterface(typeof(IFactionEnumAsset))]
        private ScriptableObject _faction;
        public IFactionEnumAsset Faction => _faction as IFactionEnumAsset;
        
        [SerializeField] [RequireInterface(typeof(ICreatureTypeEnumAsset))]
        private ScriptableObject _creatureType;
        public ICreatureTypeEnumAsset CreatureType => _creatureType as ICreatureTypeEnumAsset;
        
        [SerializeField] [RequireInterface(typeof(ITargetStatus))]
        private ScriptableObject _targetStatus;
        public ITargetStatus TargetStatus => _targetStatus as ITargetStatus;

        [Header("Skills")] 
        [SerializeField]
        [RequireInterface(typeof(IHeroSkillAsset))]
        private List<ScriptableObject> _heroSkills = new List<ScriptableObject>();
        public IHeroSkillAsset HeroSkills => _heroSkills as IHeroSkillAsset;

        private List<ScriptableObject> _getHeroSkills;
        public List<ScriptableObject> GetHeroSkills()
        {
            _getHeroSkills = _heroSkills;
            return _getHeroSkills;
        }








    }
}
