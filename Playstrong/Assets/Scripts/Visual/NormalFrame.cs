using UnityEngine;

namespace Assets.Scripts.Visual
{
    public class NormalFrame : MonoBehaviour
    {
        public GameObject _allyGlowFrame;
        public GameObject _enemyGlowFrame;
        public GameObject _actionGlowFrame;

        public GameObject AllyGlowFrame
        {
            get { return _allyGlowFrame; }
        }

        public GameObject EnemyGlowFrame
        {
            get { return _enemyGlowFrame; }
        }

        public GameObject ActionGlowFrame
        {
            get { return _actionGlowFrame; }
        }

       

    }
}
