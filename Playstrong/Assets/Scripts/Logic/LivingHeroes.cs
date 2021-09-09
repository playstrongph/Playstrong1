using System;
using System.Collections.Generic;
using Interfaces;
using UnityEngine;
using Utilities;
using Visual;
using Object = UnityEngine.Object;

namespace Logic
{
    public class LivingHeroes : MonoBehaviour, ILivingHeroes
    {
        [SerializeField] private List<GameObject> _heroesList = new List<GameObject>();
        public List<GameObject> HeroesList => _heroesList;
        
        [SerializeField] private Transform _transform;
        public Transform Transform => _transform;

        [SerializeField]
        [RequireInterface(typeof(IPanelPortaitAndSkillDisplay))]
        private Object _panelPortaitAndSkillDisplay;

        public List<IHero> LivingHeroesList
        {
            get
            {
                var herolist = new List<IHero>();
                herolist.Clear();
                foreach (var heroObject in HeroesList)
                {
                    var hero = heroObject.GetComponent<IHero>();
                    herolist.Add(hero);
                }
                return herolist;
            }
        }

        public IPanelPortaitAndSkillDisplay PanelPortaitAndSkillDisplay
        {
            get { return _panelPortaitAndSkillDisplay as IPanelPortaitAndSkillDisplay; }
            private set
            {
                _panelPortaitAndSkillDisplay = value as Object;
            }
        }
        
        private IPlayer _player;
        public IPlayer Player => _player;


        private void Awake()
        {
            _panelPortaitAndSkillDisplay = GetComponent<IPanelPortaitAndSkillDisplay>() as Object;
            _player = GetComponentInParent<IPlayer>();

        }
    }
}
