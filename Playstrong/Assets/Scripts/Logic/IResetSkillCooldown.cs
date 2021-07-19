using System.Collections;

namespace Logic
{
    public interface IResetSkillCooldown
    {
        IEnumerator UpdateCooldown();
    }
}