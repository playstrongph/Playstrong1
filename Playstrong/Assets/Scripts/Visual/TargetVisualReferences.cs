using UnityEngine;
using UnityEngine.UI;

namespace Visual
{
    public class TargetVisualReferences : MonoBehaviour, ITargetVisualReferences
    {
        [SerializeField] private Canvas _targetCanvas;
        public Canvas TargetCanvas => _targetCanvas;

        [SerializeField] private GameObject _targetCrossHair;
        public GameObject TargetCrossHair => _targetCrossHair;

        [SerializeField] private GameObject _targetTriangle;
        public GameObject TargetTriangle => _targetTriangle;

        [SerializeField] private LineRenderer _targetLineR;
        public LineRenderer TargetLineR => _targetLineR;
    
    

    }
}
