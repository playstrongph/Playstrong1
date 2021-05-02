using UnityEngine;

namespace Visual
{
    public class HeroPortrait : MonoBehaviour, IHeroPortrait
    {
        [SerializeField] private GameObject _heroPortrait;

        public GameObject PortraitReference
        {
            get { return  _heroPortrait;}
            set { _heroPortrait = value; }
        }
    }
}
