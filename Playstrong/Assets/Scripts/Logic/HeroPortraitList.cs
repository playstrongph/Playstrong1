using System.Collections.Generic;
using UnityEngine;

namespace Logic
{
    public class HeroPortraitList : MonoBehaviour, IHeroPortraitList
    {
        [SerializeField] private List<GameObject> _heroList = new List<GameObject>();
    
        public List<GameObject> HeroList => _heroList;

        public List<GameObject> GetList()
        {
            return HeroList;
        }
    }
}
