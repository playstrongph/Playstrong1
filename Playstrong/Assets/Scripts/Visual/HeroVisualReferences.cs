using Assets.Scripts.Visual;
using References;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace Visual
{
    public class HeroVisualReferences : MonoBehaviour
    {
        [SerializeField]
        private HeroObjectReferences heroObjectReferences;   
        
        [SerializeField]
        private Canvas heroCanvas;
        public Canvas HeroCanvas => heroCanvas;
        
        

    }
}
