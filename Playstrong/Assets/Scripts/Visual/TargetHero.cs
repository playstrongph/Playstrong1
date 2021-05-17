using System;
using System.Collections;
using Interfaces;
using UnityEngine;
using Utilities;
using Object = UnityEngine.Object;

namespace Visual
{
   public class TargetHero : MonoBehaviour, ITargetHero
   {
      [SerializeField]
      [RequireInterface(typeof(IHero))]
      private Object _hero;
      public IHero Hero => _hero as IHero;

   }
}
