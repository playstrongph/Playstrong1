using System;
using System.Runtime.CompilerServices;
using UnityEngine;

namespace Visual
{
    public class StatusEffectsPanel : MonoBehaviour, IStatusEffectsPanel
    {
        private Transform _transform;
        public Transform Transform => _transform;

        private void Awake()
        {
            _transform = this.Transform;
        }
    }
}
