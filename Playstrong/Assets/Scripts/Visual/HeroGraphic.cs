using UnityEngine;
using UnityEngine.UI;

namespace Visual
{
   public class HeroGraphic : MonoBehaviour
   {
      [SerializeField] 
      private Image heroGraphic;

      public Sprite HeroGraphicSprite
      {
         set => heroGraphic.sprite = value;
      }



   }
}
