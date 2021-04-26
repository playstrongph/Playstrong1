using UnityEngine;

namespace Logic
{
   public class PrefabsController : MonoBehaviour
   {
      private void Awake()
      {
         this.gameObject.SetActive(false);
      }

      private void OnApplicationQuit()
      {
         this.gameObject.SetActive(true);
      }
   }
}
