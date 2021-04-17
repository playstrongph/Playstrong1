using UnityEngine;

namespace Visual
{
    public class NormalFrame : MonoBehaviour
    {
       
        [SerializeField]
        private GameObject enemyGlowFrame;
        
        [SerializeField]
        private GameObject allyGlowFrame;
       
        [SerializeField]
        private GameObject actionGlowFrame;
       
       

        public void ShowAllyGlowFrame()
        {
            allyGlowFrame.SetActive(true);
        }

        public void HideAllyGlowFrame()
        {
            allyGlowFrame.SetActive(false);
                
        }
        
        public void ShowEnemyGlowFrame()
        {
            enemyGlowFrame.SetActive(true);
        }

        public void HideEnemyGlowFrame()
        {
            enemyGlowFrame.SetActive(false);
                
        }
        public void ShowActionGlowFrame()
        {
            actionGlowFrame.SetActive(true);
        }

        public void HideActionGlowFrame()
        {
            actionGlowFrame.SetActive(false);
                
        }

       

    }
}
