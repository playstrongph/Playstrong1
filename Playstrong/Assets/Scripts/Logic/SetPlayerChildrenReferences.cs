using System;
using Interfaces;
using UnityEngine;

namespace Logic
{
    public class SetPlayerChildrenReferences : MonoBehaviour
    {
        private IPlayer _player;

        private void Awake()
        {
            _player = GetComponent<IPlayer>();
        }

        public void SetReferences()
        {
           
        }
    }
}
