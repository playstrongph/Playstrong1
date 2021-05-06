using System.Collections.Generic;
using Interfaces;
using UnityEngine;
using Utilities;

namespace Logic
{
    public class ObjectList : MonoBehaviour, IObjectList
    {
        [SerializeField] private List<GameObject> _thisList = new List<GameObject>();
        public List<GameObject> ThisList => _thisList;

        [SerializeField] private Transform _transform;
        public Transform Transform => _transform;
        
       

       





    }
}
