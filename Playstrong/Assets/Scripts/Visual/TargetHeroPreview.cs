using System;
using System.Collections;
using Interfaces;
using UnityEngine;
using Utilities;
using Object = UnityEngine.Object;

namespace Visual
{
   public class TargetHeroPreview : MonoBehaviour, ITargetPreview, ITargetHeroPreview
   {
      [SerializeField]
      [RequireInterface(typeof(IHero))]
      private Object _hero;
      public IHero Hero => _hero as IHero;
      
      [SerializeField] [RequireInterface(typeof(ITargetVisual))]
      private Object _targetVisual;
      public ITargetVisual TargetVisual => _targetVisual as ITargetVisual;

      //Variables initialized at Awake or Start
      private IHeroPreviewVisual _heroPreviewVisual;
      private Coroutine _showPreview;
      private float _displayDelay;
     

      private void Awake()
      {
         _heroPreviewVisual = Hero.HeroPreviewVisual;
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
         HidePreview();
      }
      private void ShowHeroPreview()
      {
         _showPreview = StartCoroutine(ShowHeroPreviewCoroutine());
      }

      public void HidePreview()
      {
         StopCoroutine(_showPreview);
         _heroPreviewVisual.PreviewCanvas.gameObject.SetActive(false);  
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
