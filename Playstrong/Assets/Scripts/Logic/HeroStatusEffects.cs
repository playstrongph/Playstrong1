using System;
using Interfaces;
using UnityEngine;
using Utilities;
using Visual;
using Object = UnityEngine.Object;

namespace Logic
{
    public class HeroStatusEffects : MonoBehaviour
    {
        [SerializeField]
        private Canvas _statusEffectsCanvas;
        public Canvas StatusEffectsCanvas => _statusEffectsCanvas;

        [SerializeField]
        [RequireInterface(typeof(IStatusEffectsPanel))]
        private Object _statusEffectsPanel;
        public IStatusEffectsPanel StatusEffectsPanel => _statusEffectsPanel as IStatusEffectsPanel;


        private IStatusEffectsVisual _statusEffectsVisual;
        public IStatusEffectsVisual StatusEffectsVisual => _statusEffectsVisual;


        private void Awake()
        {
            _statusEffectsVisual = GetComponent<IStatusEffectsVisual>();
        }
    }
}
