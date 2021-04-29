using System.Collections.Generic;
using Interfaces;
using UnityEngine;
using Utilities;

namespace Logic
{
    public class SkillsList : MonoBehaviour, ISkillsList
    {
        [SerializeField] private List<GameObject> _skillList = new List<GameObject>();
        public List<GameObject> SkillList => _skillList;
    }
}
