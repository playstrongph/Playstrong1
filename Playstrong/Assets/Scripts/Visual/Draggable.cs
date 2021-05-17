using System;
using Interfaces;
using UnityEngine;
using Utilities;
using Object = UnityEngine.Object;

namespace Visual
{
    public class Draggable : MonoBehaviour, IDraggable
    {

        // distance from the center of this Game Object to the point where we clicked to start dragging 
        private Vector3 _pointerDisplacement;

        // distance from camera to mouse on Z axis 
        private float _zDisplacement;

        [SerializeField]
        [RequireInterface(typeof(ISelectTargetVisual))]
        private Object _selectTargetVisual;
        public ISelectTargetVisual SelectTargetVisual => _selectTargetVisual as ISelectTargetVisual;


        private void OnEnable()
        {
            _zDisplacement = -Camera.main.transform.position.z + transform.position.z;
            _pointerDisplacement = -transform.position + MouseInWorldCoords();
        }

        private void Update()
        {
            var mousePos = MouseInWorldCoords();    
            
            transform.position = new Vector3(mousePos.x - _pointerDisplacement.x, mousePos.y - _pointerDisplacement.y, transform.position.z);
            
            SelectTargetVisual.ShowLineAndTarget();
        
        }
    
        private Vector3 MouseInWorldCoords()
        {
            var screenMousePos = Input.mousePosition;
            //Debug.Log(screenMousePos);
            screenMousePos.z = _zDisplacement;
            return Camera.main.ScreenToWorldPoint(screenMousePos);
        }

        public void EnableDraggable()
        {
            this.enabled = true;
        }
    
        public void DisableDraggable()
        {
            this.enabled = false;
        }

        
    }
}
