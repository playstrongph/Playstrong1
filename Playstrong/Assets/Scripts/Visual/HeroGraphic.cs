using System.Runtime.CompilerServices;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Visual
{
    public class HeroGraphic : MonoBehaviour
    {
        [SerializeField]
        private Image _heroSprite;

        public Sprite HeroSprite
        {
            set { _heroSprite.sprite = value; }
        }

    }
}
