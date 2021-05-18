using System;
using System.Runtime.CompilerServices;
using Interfaces;
using UnityEngine;

namespace Visual
{
    public class DragHeroAttack : MonoBehaviour
    {
        private ITargetHero _targetHero;

        private Action _attackTarget;

        private void Awake()
        {
            _targetHero = GetComponent<ITargetHero>();
            _attackTarget = NoAction;
        }

        private void OnMouseUp()
        {
            GetTarget();
            
            _attackTarget();


        }

        private void OnMouseDown()
        {
            _attackTarget = NoAction;
        }

        private void GetTarget()
        {
            RaycastHit[] hits;
            
            hits = Physics.RaycastAll(origin: Camera.main.transform.position, 
                direction: (-Camera.main.transform.position + this.transform.position).normalized, 
                maxDistance: 30f) ;

            foreach (var hit in hits)
            {
                if (hit.transform.GetComponent<ITargetHero>() != null)
                    if (hit.transform.gameObject != this.gameObject)
                        //if(isValidTarget)
                    {
                        _targetHero = hit.transform.GetComponent<ITargetHero>();
                        _attackTarget = AttackTarget;
                    }

               
            }
        }

        private void AttackTarget()
        {
            
        }



        private void NoAction() { }
    }
}
