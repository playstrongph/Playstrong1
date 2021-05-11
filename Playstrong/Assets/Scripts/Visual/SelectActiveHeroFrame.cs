using Interfaces;
using UnityEngine;
using Utilities;

namespace Visual
{
    public class SelectActiveHeroFrame : MonoBehaviour, ISelectActiveHeroFrame
    {
        [SerializeField]
        [RequireInterface(typeof(IFrameAndGlow))]
        private Object _activeHeroFrame;

        public IFrameAndGlow ActiveHeroFrame
        {
            get => _activeHeroFrame as IFrameAndGlow;
            set => _activeHeroFrame = value as Object;
        }

        
            

    }
}
