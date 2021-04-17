using UnityEngine;

namespace Assets.Scripts.Visual
{
    public class NormalFrame : MonoBehaviour
    {
       
        [SerializeField]
        private GameObject _allyGlowFrame;
        public GameObject AllyGlowFrame
        {
            get { return _allyGlowFrame; }
        }
        
        [SerializeField]
        private GameObject _enemyGlowFrame;
        public GameObject EnemyGlowFrame
        {
            get { return _enemyGlowFrame; }
        }
        
        [SerializeField]
        private GameObject _actionGlowFrame;
        public GameObject ActionGlowFrame
        {
            get { return _actionGlowFrame; }
        }

       

    }
}
