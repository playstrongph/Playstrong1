using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Prefabs : MonoBehaviour
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
