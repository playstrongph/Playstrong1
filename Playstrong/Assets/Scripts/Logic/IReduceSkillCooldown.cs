using System.Collections;

namespace Logic
{
    public interface IReduceSkillCooldown
    {
        IEnumerator UpdateCooldown(int counter);
    }
}