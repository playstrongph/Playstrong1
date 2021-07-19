using System.Collections;

namespace Logic
{
    public interface IReduceSkillCooldown
    {
        IEnumerator ChangeCooldown(int counter);
    }
}