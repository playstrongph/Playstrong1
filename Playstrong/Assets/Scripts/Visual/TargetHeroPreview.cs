using System;
using System.Collections;
using Interfaces;
using UnityEngine;
using Utilities;
using Object = UnityEngine.Object;

namespace Visual
{
   public class TargetHeroPreview : MonoBehaviour, ITargetHeroPreview
   {
      [SerializeField]
      [RequireInterface(typeof(IHeroObjectReferences))]
      private Object _heroObjectReferences;
      public IHeroObjectReferences HeroObjectReferences => _heroObjectReferences as IHeroObjectReferences;

      //Variables initialized at Awake or Start
      private IHeroPreviewVisual _heroPreviewVisual;
      private Coroutine _showPreview;
      private float _displayDelay;
     

      private void Awake()
      {
         _heroPreviewVisual = HeroObjectReferences.HeroPreviewVisual;
         _displayDelay = 0.5f;
         
         //prevents null reference error for _showPreview
         _showPreview = StartCoroutine(NullAction());
      }

      private void OnMouseDown()
      {
         ShowHeroPreview();
      }

      private void OnMouseUp()
      {
         StopCoroutine(_showPreview);
         _heroPreviewVisual.PreviewCanvas.gameObject.SetActive(false);
      }

      private void OnMouseExit()
      {
         StopCoroutine(_showPreview);
         _heroPreviewVisual.PreviewCanvas.gameObject.SetActive(false);
      }

      private void ShowHeroPreview()
      {
         _showPreview = StartCoroutine(ShowHeroPreviewCoroutine());
      }

      private IEnumerator ShowHeroPreviewCoroutine()
      {
         yield return new WaitForSeconds(_displayDelay);
         _heroPreviewVisual.LoadHeroPreviewVisuals.UpdateHeroPreviewAttributes();
         _heroPreviewVisual.PreviewCanvas.gameObject.SetActive(true);
         yield return null;

      }

      private IEnumerator NullAction()
      {
         yield return null;
      }

   }
}
