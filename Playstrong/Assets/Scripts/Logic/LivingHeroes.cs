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

        public IPanelPortaitAndSkillDisplay PanelPortaitAndSkillDisplay
        {
            get { return _panelPortaitAndSkillDisplay as IPanelPortaitAndSkillDisplay; }
            private set
            {
                _panelPortaitAndSkillDisplay = value as Object;
            }
        }

        private void Awake()
        {
            _panelPortaitAndSkillDisplay = GetComponent<IPanelPortaitAndSkillDisplay>() as Object;
        }
    }
}
