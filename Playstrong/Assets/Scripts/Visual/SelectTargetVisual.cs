using System;
using System.Collections.Generic;
using Interfaces;
using UnityEngine;
using UnityEngine.UI;
using Utilities;
using Object = UnityEngine.Object;

namespace Visual
{
    public class SelectTargetVisual : MonoBehaviour, ISelectTargetVisual
    {
        [SerializeField] [RequireInterface(typeof(ITargetPreview))]
        private Object _targetPreview;
        public ITargetPreview TargetPreview => _targetPreview as ITargetPreview;

        private Canvas _targetVisualCanvas;
        private GameObject _targetCrossHair;
        private GameObject _targetTriangle;
        private LineRenderer _targetLine;
        private IDraggable _draggable;
        private ITargetPreview _targetHeroPreview;

        private delegate void DisplayAction(Vector3 x, Vector3 y);

        private List<DisplayAction> _displayActions = new List<DisplayAction>();

        private void Start()
        {   
             _displayActions.Add(NoAction);
            _displayActions.Add(DisplayLineAndTriangle);
        }


        private void OnEnable()
        {
            _targetVisualCanvas = TargetPreview.TargetVisual.TargetCanvas;
            _targetCrossHair = TargetPreview.TargetVisual.TargetCrossHair;
            _targetTriangle = TargetPreview.TargetVisual.TargetTriangle;
            _targetLine = TargetPreview.TargetVisual.TargetLineR;
            _draggable = GetComponent<IDraggable>();
            _targetHeroPreview = GetComponent<ITargetPreview>();
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

            var difference = notNormalized.magnitude - distanceFromHero;
            var intDifference = Mathf.RoundToInt(difference);
            var index = Mathf.Clamp(intDifference, 0, 1);


            _displayActions[index](notNormalized, direction);

        }

        private void DisplayLineAndTriangle(Vector3 notNormalized, Vector3 direction)
        {
            _targetLine.enabled = true;
            _targetTriangle.SetActive(true);
                
            _targetLine.SetPositions(new Vector3[]{ transform.parent.position, transform.position - direction*20f});
            _targetTriangle.transform.position = transform.position - 15f*direction;
                
            float rotZ = Mathf.Atan2(notNormalized.y, notNormalized.x) * Mathf.Rad2Deg;
            _targetTriangle.transform.rotation = Quaternion.Euler(0f, 0f, rotZ - 90);
                
            //Disable Hero Preview Here
            _targetHeroPreview.HidePreview();
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

        private void NoAction(Vector3 notNormalized, Vector3 direction){}


    }
    
    
    
}
