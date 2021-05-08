﻿using System.Collections.Generic;
using UnityEngine;

namespace Logic
{
    public class PanelSkills : MonoBehaviour, IPanelSkills
    {
        [SerializeField] private List<GameObject> _list = new List<GameObject>();
        public List<GameObject> List => _list;

        [SerializeField] private Transform _transform;
        public Transform Transform => _transform;
    }
}
