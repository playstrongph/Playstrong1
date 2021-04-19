using UnityEngine;

namespace Assets.Scripts.Visual
{
    public class NormalFrame : MonoBehaviour, INormalFrameAndGlow
    {
       
        [SerializeField]
        private GameObject _enemyGlowFrame;
        
        [SerializeField]
        private GameObject _allyGlowFrame;
       
        [SerializeField]
        private GameObject _actionGlowFrame;
       
       

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

       

    }
}
