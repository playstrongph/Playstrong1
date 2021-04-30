using UnityEngine;
using Utilities;

namespace Logic
{
    public class HeroSkillsReference : MonoBehaviour, IHeroSkillsReference
    {
        [SerializeField] private GameObject _heroSkills;

        public GameObject HeroSkills
        {
            get { return  _heroSkills;}
            set { _heroSkills = value; }
        }
    }
}
