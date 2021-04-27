using System;
using UnityEngine;
using Utilities;
using Object = UnityEngine.Object;

namespace Visual
{
    public class SelectTargetVisual : MonoBehaviour, ISelectTargetVisual
    {
        [SerializeField] [RequireInterface(typeof(ITargetVisualReferences))]
        private Object _targetVisualReferences;
        public ITargetVisualReferences TargetVisualReferences => _targetVisualReferences as ITargetVisualReferences;

        private Canvas _targetVisualCanvas;
        private GameObject _targetCrossHair;
        private GameObject _targetTriangle;
        private LineRenderer _targetLine;
        private IDraggable _draggable;

      

        private void Awake()
        {
            _targetVisualCanvas = TargetVisualReferences.TargetCanvas;
            _targetCrossHair = TargetVisualReferences.TargetCrossHair;
            _targetTriangle = TargetVisualReferences.TargetTriangle;
            _targetLine = TargetVisualReferences.TargetLineR;
            _draggable = GetComponent<IDraggable>();
            _draggable.DisableDraggable();

        }

        private void OnMouseDown()
        {
            transform.localPosition = Vector3.zero;
            EnableTargetVisuals();
            _draggable.EnableDraggable();
            ShowLineAndTarget();
            
        }
        
        private void OnMouseUp()
        {
            transform.localPosition = Vector3.zero;
            DisableTargetVisuals();
            _draggable.DisableDraggable();
        }

        public void ShowLineAndTarget()
        {
            _targetLine.SetPositions(new Vector3[]{ transform.parent.position, transform.position});
            _targetTriangle.transform.position = transform.position;
            
            var notNormalized = transform.position - transform.parent.position;
            var direction = notNormalized.normalized;

            float rotZ = Mathf.Atan2(notNormalized.y, notNormalized.x) * Mathf.Rad2Deg;
            _targetLine.transform.rotation = Quaternion.Euler(0f, 0f, rotZ - 90);
        }
        
        private void EnableTargetVisuals()
        {
            _targetCrossHair.SetActive(true);
            _targetTriangle.SetActive(true);
            _targetLine.gameObject.SetActive(true);
        }
        
        private void DisableTargetVisuals()
        {
            _targetCrossHair.SetActive(false);
            _targetTriangle.SetActive(false);
            _targetLine.gameObject.SetActive(false);
        }

    }
    
    
    
}
