using System;
using UnityEngine;
using Utilities;
using Object = UnityEngine.Object;

namespace Visual
{
    public class ShowTargetVisual : MonoBehaviour
    {
        [SerializeField] [RequireInterface(typeof(ITargetVisualReferences))]
        private Object _targetVisualReferences;
        public ITargetVisualReferences TargetVisualReferences => _targetVisualReferences as ITargetVisualReferences;

        private Canvas _targetVisualCanvas;
        private GameObject _targetCrossHair;
        private GameObject _targetTriangle;
        private LineRenderer _targetLine;

        private void Awake()
        {
            _targetVisualCanvas = TargetVisualReferences.TargetCanvas;
            _targetCrossHair = TargetVisualReferences.TargetCrossHair;
            _targetTriangle = TargetVisualReferences.TargetTriangle;
            _targetLine = TargetVisualReferences.TargetLineR;
            
        }

        private void OnMouseDrag()
        {
            SetTargetVisuals(true);
        }
        
        private void OnMouseUp()
        {
            SetTargetVisuals(false);
        }
        
        
        private void OnMouseOver()
        {
            SetTargetVisuals(false);
        }

        private void SetTargetVisuals(bool status)
        {
            _targetCrossHair.SetActive(status);
            _targetTriangle.SetActive(status);
            _targetLine.gameObject.SetActive(status);
        }














    }
    
    
    
}
