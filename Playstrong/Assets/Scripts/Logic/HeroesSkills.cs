using System.Collections.Generic;
using UnityEngine;

namespace Logic
{
    public class HeroesSkills : MonoBehaviour, IHeroesSkills
    {
        [SerializeField] private List<GameObject> _list = new List<GameObject>();
        public List<GameObject> List => _list;

        [SerializeField] private Transform _transform;
        public Transform Transform => _transform;
    }
}
