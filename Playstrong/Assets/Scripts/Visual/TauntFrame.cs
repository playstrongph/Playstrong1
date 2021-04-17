using System.Runtime.CompilerServices;
using UnityEngine;

namespace Assets.Scripts.Visual
{
    public class TauntFrame : MonoBehaviour
    {
        public GameObject _allyGlowFrame;
        public GameObject _enemyGlowFrame;
        public GameObject _actionGlowFrame;
        public GameObject _frame;

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

        public GameObject Frame
        {
            get { return _frame; }
        }

    }
}
