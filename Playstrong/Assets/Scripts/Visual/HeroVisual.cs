using Assets.Scripts.References;
using Assets.Scripts.Visual;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace Visual
{
    public class HeroVisual : MonoBehaviour
    {
        [SerializeField]
        private HeroObjectReferences heroObjectReferences;   
        
        [SerializeField]
        private Canvas heroCanvas;
        public Canvas HeroCanvas => heroCanvas;

    }
}
