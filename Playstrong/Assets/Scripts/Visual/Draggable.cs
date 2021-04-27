using UnityEngine;

namespace Visual
{
    public class Draggable : MonoBehaviour, IDraggable
    {

        // distance from the center of this Game Object to the point where we clicked to start dragging 
        private Vector3 _pointerDisplacement;

        // distance from camera to mouse on Z axis 
        private float _zDisplacement;


        public void SetDsiplacement(float zDisplacement, Vector3 pointerDisplacement)
        {
            _zDisplacement = zDisplacement;
            _pointerDisplacement = pointerDisplacement;
        }

        private void Update()
        {
            var mousePos = MouseInWorldCoords();            
            transform.position = new Vector3(mousePos.x - _pointerDisplacement.x, mousePos.y - _pointerDisplacement.y, transform.position.z);
        
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
