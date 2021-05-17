using System;
using System.Runtime.CompilerServices;
using Interfaces;
using UnityEngine;

namespace Visual
{
    public class DragHeroAttack : MonoBehaviour
    {
        /*private ITargetHeroPreview _target;*/
        
        private void OnMouseUp()
        {
            GetTarget();
            
        }

        private void GetTarget()
        {
            RaycastHit[] hits;
            
            hits = Physics.RaycastAll(origin: Camera.main.transform.position, 
                direction: (-Camera.main.transform.position + this.transform.position).normalized, 
                maxDistance: 30f) ;

            foreach (var hit in hits)
            {
                /*if (hit.transform.GetComponent<ITargetHeroPreview>() != null)
                    if (hit.transform.gameObject != this.gameObject)
                        _target = hit.transform.GetComponent<ITargetHeroPreview>();*/
            }
        }
    }
}
