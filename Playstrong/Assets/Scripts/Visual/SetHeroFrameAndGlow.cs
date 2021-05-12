using Interfaces;
using UnityEngine;
using Utilities;

namespace Visual
{
    public class SetHeroFrameAndGlow : MonoBehaviour, ISetHeroFrameAndGlow
    {
        [SerializeField]
        [RequireInterface(typeof(IFrameAndGlow))]
        private Object _heroFrameAndGlow;

        public IFrameAndGlow HeroFrameAndGlow
        {
            get { return _heroFrameAndGlow as IFrameAndGlow;}
            set { _heroFrameAndGlow = value as Object;}
        }

    }
}
