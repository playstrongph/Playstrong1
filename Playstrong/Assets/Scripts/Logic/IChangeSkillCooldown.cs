using System.Collections;

namespace Logic
{
    public interface IChangeSkillCooldown
    {
        IEnumerator ReduceCooldown(int counter);
        IEnumerator IncreaseCooldown(int counter);
        IEnumerator SetCooldownValue(int counter);
        IEnumerator ResetCooldown();
        IEnumerator RefreshCooldown();
    }
}