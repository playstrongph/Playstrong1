using Interfaces;
using UnityEngine;

namespace Visual
{
    public class TauntFrame : MonoBehaviour, ITauntFrameAndGlow, IFrameAndGlow
    {
 
        [SerializeField]
        private GameObject _allyGlowFrame;

        public GameObject AllyGlowFrame => _allyGlowFrame;

        [SerializeField]
        private GameObject _enemyGlowFrame;

        public GameObject EnemyGlowFrame => _enemyGlowFrame;

        [SerializeField]
        private GameObject _actionGlowFrame;

        public GameObject ActionGlowFrame => _actionGlowFrame;
        
        [SerializeField]
        private GameObject _frame;

        public GameObject Frame => _frame;


    }
}
