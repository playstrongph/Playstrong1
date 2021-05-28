using System;
using System.Collections;
using System.Collections.Generic;
using Interfaces;
using UnityEngine;

namespace Logic
{
    public class PanelSkills : MonoBehaviour, IPanelSkills
    {
        [SerializeField] private List<GameObject> _list = new List<GameObject>();
        public List<GameObject> List => _list;

        [SerializeField] private Transform _transform;
        public Transform Transform => _transform;
        
        private IPlayer _player;
        public IPlayer Player => _player;
        
        private ICoroutineTree _logicTree;
        private ICoroutineTree _visualTree;

        private IReferenceHeroesSkills _referenceHeroesSkills;
       



        private IDisablePanelTargetVisual _disablePanelTargetVisual;

        private void Awake()
        {
            _player = GetComponentInParent<IPlayer>();
            _disablePanelTargetVisual = GetComponent<IDisablePanelTargetVisual>();
            _referenceHeroesSkills = GetComponent<IReferenceHeroesSkills>();

        }
        private void Start()
        {
            _logicTree = _player.GlobalTrees.MainLogicTree;
            _visualTree = _player.GlobalTrees.MainVisualTree;
        }
        
        public IEnumerator DisablePanelSkillTargetVisual( )
        {
            _disablePanelTargetVisual.DisableTarget();

            _logicTree.EndSequence();
            yield return null;
            
        }

        public IEnumerator ReferenceHeroesSkills()
        {
            _referenceHeroesSkills.ReferenceSkills();
            
            _logicTree.EndSequence();
            yield return null;
        }



    }
}
