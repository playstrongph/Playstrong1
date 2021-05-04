using UnityEngine;
using Utilities;

namespace Logic
{
    public class HeroSkills : MonoBehaviour, IHeroSkills
    {
        [SerializeField] private GameObject _skills;

        public GameObject Skills
        {
            get { return  _skills;}
            set { _skills = value; }
        }
    }
}
