using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Visual
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
