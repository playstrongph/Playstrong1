using Interfaces;
using UnityEngine;

namespace Visual
{
    public class TauntFrame : MonoBehaviour, ITauntFrameAndGlow
    {
 
        [SerializeField]
        private GameObject _allyGlowFrame;

        [SerializeField]
        private GameObject _enemyGlowFrame;

        [SerializeField]
        private GameObject _actionGlowFrame;
        
        [SerializeField]
        private GameObject _frame;


        public void ShowAllyGlowFrame()
        {
            _allyGlowFrame.SetActive(true);
        }

        public void HideAllyGlowFrame()
        {
            _allyGlowFrame.SetActive(false);
                
        }
        
        public void ShowEnemyGlowFrame()
        {
            _enemyGlowFrame.SetActive(true);
        }

        public void HideEnemyGlowFrame()
        {
            _enemyGlowFrame.SetActive(false);
                
        }
        public void ShowActionGlowFrame()
        {
            _actionGlowFrame.SetActive(true);
        }

        public void HideActionGlowFrame()
        {
            _actionGlowFrame.SetActive(false);
                
        }

        public void ShowFrame()
        {
            _frame.SetActive(true);
            
        }
        
        public void HideFrame()
        {
            _frame.SetActive(false);
            
        }


    }
}
