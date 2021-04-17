using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Visual
{
   public class HeroGraphic : MonoBehaviour, ISetHeroGraphic
   {
      [SerializeField] 
      private Image heroGraphic;

      public void SetHeroGraphic(Sprite heroGraphicSprite)
      {
         heroGraphic.sprite = heroGraphicSprite;
      }



   }
}
