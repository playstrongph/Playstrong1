using System.Collections.Generic;
using System.Runtime.InteropServices.ComTypes;
using Assets.Scripts.Utilities;
using UnityEngine;
using Object = System.Object;


namespace Assets.Scripts.ScriptableObjects
{
    [CreateAssetMenu(fileName = "New Hero", menuName = "SO's/New Hero")]
    public class HeroAsset : ScriptableObject
    {

        [SerializeField] [RequireInterface(typeof(IRarityEnum))]
        private ScriptableObject _rarity;
        public IRarityEnum Rarity => _rarity as IRarityEnum;

        [Header("Hero Name")] [SerializeField] private string _name;
        public string Name { get => _name; set => _name = value; }

        [Header("Hero Stats")] 
        [SerializeField]
        private int _health;
        public int Health { get => _health; set => _health = value; }
        
        [SerializeField]
        private int _attack;
        public int Attack { get => _attack; set => _attack = value; }
        
        [SerializeField]
        private int _speed;
        public int Speed { get => _speed; set => _speed = value; }
        
        [SerializeField]
        private int _chance;
        public int Chance { get => _chance; set => _chance = value; }
        
        [SerializeField]
        private int _armor;
        public int Armor { get => _armor; set => _armor = value; }

              








    }
}
