using System;
using UnityEngine;
using UnityEngine.UI;
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

       
        private void OnEnable()
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
            
            var notNormalized = transform.position - transform.parent.position;
            var direction = notNormalized.normalized;
            float distanceFromHero = (direction*50f).magnitude;
            
            //Hide Triangle and Line while target is close to HeroObject
            _targetTriangle.SetActive(false);
            _targetLine.enabled = false;

            if (notNormalized.magnitude > distanceFromHero)
            {
                _targetLine.enabled = true;
                _targetTriangle.SetActive(true);
                
                _targetLine.SetPositions(new Vector3[]{ transform.parent.position, transform.position - direction*20f});
                _targetTriangle.transform.position = transform.position - 15f*direction;
                
                float rotZ = Mathf.Atan2(notNormalized.y, notNormalized.x) * Mathf.Rad2Deg;
                _targetTriangle.transform.rotation = Quaternion.Euler(0f, 0f, rotZ - 90);
                
                //Disable Hero Preview Here

            }
            

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
