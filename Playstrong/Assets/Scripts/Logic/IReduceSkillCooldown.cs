using System.Collections;

namespace Logic
{
    public interface IReduceSkillCooldown
    {
        IEnumerator ReduceCd(int counter);
    }
}