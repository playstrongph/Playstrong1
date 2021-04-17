using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Visual
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
