using System;
using UnityEngine;
using Utilities;
using Object = UnityEngine.Object;

namespace Visual
{
    public class SelectTargetVisual : MonoBehaviour
    {
        [SerializeField] [RequireInterface(typeof(ITargetVisualReferences))]
        private Object _targetVisualReferences;
        public ITargetVisualReferences TargetVisualReferences => _targetVisualReferences as ITargetVisualReferences;

        private Canvas _targetVisualCanvas;
        private GameObject _targetCrossHair;
        private GameObject _targetTriangle;
        private LineRenderer _targetLine;
        private IDraggable _draggable;

        private float _zDisplacement;
        private Vector3 _pointerDisplacement;

        private void Awake()
        {
            _targetVisualCanvas = TargetVisualReferences.TargetCanvas;
            _targetCrossHair = TargetVisualReferences.TargetCrossHair;
            _targetTriangle = TargetVisualReferences.TargetTriangle;
            _targetLine = TargetVisualReferences.TargetLineR;
            _draggable = GetComponent<IDraggable>();
            _draggable.DisableDraggable();
            
          

        }

        private void OnMouseDrag()
        {
            transform.localPosition = Vector3.zero;
            SetTargetVisuals(true);
            _draggable.EnableDraggable();
            ShowLineAndTarget();
        }
        
        private void OnMouseUp()
        {
            transform.localPosition = Vector3.zero;
            SetTargetVisuals(false);
            _draggable.DisableDraggable();
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

        private void ShowLineAndTarget()
        {
            _zDisplacement = -Camera.main.transform.position.z + transform.position.z;
            _pointerDisplacement = -transform.position + MouseInWorldCoords();
            _draggable.SetDsiplacement(_zDisplacement, _pointerDisplacement);
            
            var notNormalized = transform.position - transform.parent.position;
            var direction = notNormalized.normalized;
            
            //enable draggable script for Update
            
            _targetLine.SetPositions(new Vector3[]{ transform.parent.position, transform.position});
            
            _targetTriangle.transform.position = transform.position;
            
            float rotZ = Mathf.Atan2(notNormalized.y, notNormalized.x) * Mathf.Rad2Deg;
            _targetLine.transform.rotation = Quaternion.Euler(0f, 0f, rotZ - 90);
        }
        
        private Vector3 MouseInWorldCoords()
        {
            var screenMousePos = Input.mousePosition;
            //Debug.Log(screenMousePos);
            screenMousePos.z = _zDisplacement;
            return Camera.main.ScreenToWorldPoint(screenMousePos);
        }

    }
    
    
    
}
