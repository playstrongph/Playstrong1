using Interfaces;
using UnityEngine;
using UnityEngine.UI;

namespace Visual
{
   public class HeroGraphic : MonoBehaviour, ISetHeroGraphic
   {
      [SerializeField] 
      private Image _heroImage;

      public Image HeroImage => _heroImage;

     



   }
}
