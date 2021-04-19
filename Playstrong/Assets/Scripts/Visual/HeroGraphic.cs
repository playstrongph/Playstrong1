using Interfaces;
using UnityEngine;
using UnityEngine.UI;

namespace Visual
{
   public class HeroGraphic : MonoBehaviour, ISetHeroGraphic
   {
      [SerializeField] 
      private Image _heroGraphic;

      public void SetHeroGraphic(Sprite heroGraphicSprite)
      {
         _heroGraphic.sprite = heroGraphicSprite;
      }



   }
}
