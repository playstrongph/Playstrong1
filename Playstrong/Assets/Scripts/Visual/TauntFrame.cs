using UnityEngine;

namespace Visual
{
    public class TauntFrame : MonoBehaviour 
    {
       
        [SerializeField]
        private GameObject allyGlowFrame;
       
        
        [SerializeField]
        private GameObject enemyGlowFrame;
       

        [SerializeField]
        private GameObject actionGlowFrame;
       
        
        [SerializeField]
        private GameObject frame;
       

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

        public void ShowFrame()
        {
            frame.SetActive(true);
            
        }
        
        public void HideFrame()
        {
            frame.SetActive(false);
            
        }






    }
}
