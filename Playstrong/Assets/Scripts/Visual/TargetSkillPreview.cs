using System;
using System.Collections;
using Interfaces;
using References;
using UnityEngine;
using Utilities;
using Object = UnityEngine.Object;

namespace Visual
{
   public class TargetSkillPreview : MonoBehaviour, ITargetPreview
   {
      [SerializeField]
      [RequireInterface(typeof(ISkillObjectReferences))]
      private Object _skillObjectReferences;
      public ISkillObjectReferences SkillObjectReferences => _skillObjectReferences as ISkillObjectReferences;
      
      [SerializeField] [RequireInterface(typeof(ITargetVisual))]
      private Object _targetVisual;
      public ITargetVisual TargetVisual => _targetVisual as ITargetVisual;

      //Variables initialized at Awake or Start
      private ISkillPreviewVisual _skillPreviewVisual;
      private Coroutine _showPreview;
      private float _displayDelay;
     

      private void Awake()
      {
         _skillPreviewVisual = SkillObjectReferences.SkillPreviewVisual;
         _displayDelay = 0.5f;
         
         //prevents null reference error for _showPreview
         _showPreview = StartCoroutine(NullAction());
      }

      private void OnMouseDown()
      {
         ShowPreview();
      }

      private void OnMouseUp()
      {
         HidePreview();
      }
      private void ShowPreview()
      {
         _showPreview = StartCoroutine(ShowPreviewCoroutine());
      }

      public void HidePreview()
      {
         StopCoroutine(_showPreview);
         _skillPreviewVisual.PreviewCanvas.gameObject.SetActive(false);  
      }

      private IEnumerator ShowPreviewCoroutine()
      {
         yield return new WaitForSeconds(_displayDelay);
        _skillPreviewVisual.PreviewCanvas.gameObject.SetActive(true);
        yield return null;

      }

      private IEnumerator NullAction()
      {
         yield return null;
      }

   }
}
