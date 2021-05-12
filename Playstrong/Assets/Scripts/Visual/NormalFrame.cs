using Interfaces;
using UnityEngine;

namespace Visual
{
    public class NormalFrame : MonoBehaviour, INormalFrameAndGlow
    {
       
        [SerializeField]
        private GameObject _enemyGlowFrame;

        public GameObject EnemyGlowFrame => _enemyGlowFrame;
        
        [SerializeField]
        private GameObject _allyGlowFrame;

        public GameObject AllyGlowFrame => _allyGlowFrame;
       
        [SerializeField]
        private GameObject _actionGlowFrame;

        public GameObject ActionGlowFrame => _actionGlowFrame;







    }
}
