using System;
using System.Collections;
using Interfaces;
using Logic;
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

      private ITargetPreview _heroPreview;
      public ITargetPreview HeroPreview => _heroPreview;

      private IDragHeroAttack _dragHeroAttack;
      public IDragHeroAttack DragHeroAttack => _dragHeroAttack;

      private IGetAttackTargets _getAttackTargets;
      public IGetAttackTargets GetAttackTargets => _getAttackTargets;

      private BoxCollider _heroBoxCollider;
      public BoxCollider HeroBoxCollider => _heroBoxCollider;

      private ITargetVisual _targetVisual;
      public ITargetVisual TargetVisual => _targetVisual;
      
      private void Awake()
      {
         _heroPreview = GetComponent<ITargetPreview>();
         _dragHeroAttack = GetComponent<IDragHeroAttack>();
         _getAttackTargets = GetComponent<IGetAttackTargets>();
         _heroBoxCollider = GetComponent<BoxCollider>();
         _targetVisual = GetComponentInChildren<ITargetVisual>();

      }
   }
}
