using Logic;
using TMPro;
using UnityEngine;

namespace SkillActions
{
    public class AttackTarget : MonoBehaviour, IAttackTarget
    {
        public void SkillTarget()
        {
            Debug.Log("Skill Action: Attack Target");
        }

        
    }
}
