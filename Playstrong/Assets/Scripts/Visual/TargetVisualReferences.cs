using UnityEngine;
using UnityEngine.UI;

namespace Visual
{
    public class TargetVisualReferences : MonoBehaviour, ITargetVisualReferences
    {
        [SerializeField] private Canvas _targetCanvas;
        public Canvas TargetCanvas => _targetCanvas;

        [SerializeField] private Image _targetCrossHair;
        public Image TargetCrossHair => _targetCrossHair;

        [SerializeField] private Image _targetTriangle;
        public Image TargetTriangle => _targetTriangle;

        [SerializeField] private LineRenderer _targetLineR;
        public LineRenderer TargetLineR => _targetLineR;
    
    

    }
}
