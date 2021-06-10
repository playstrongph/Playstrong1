using UnityEngine;

namespace SkillConditions
{
    public class ChanceSuccess : MonoBehaviour, IChanceSuccess
    {
        public void SkillTarget()
        {
            Debug.Log("Skill Condition: Chance Success");
        }

        

    }
}
