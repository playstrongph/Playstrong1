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


        private IDisablePanelTargetVisual _disablePanelTargetVisual;

        private void Awake()
        {
            _disablePanelTargetVisual = GetComponent<IDisablePanelTargetVisual>();
            
        }
        public IEnumerator DisablePanelSkillTargetVisual(ICoroutineTree tree)
        {
            _disablePanelTargetVisual.DisableTarget();

            yield return null;
            tree.EndSequence();
        }
    }
}
