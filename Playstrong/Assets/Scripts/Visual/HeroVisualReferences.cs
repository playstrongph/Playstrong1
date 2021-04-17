using Assets.Scripts.References;
using UnityEngine;

namespace Assets.Scripts.Visual
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
