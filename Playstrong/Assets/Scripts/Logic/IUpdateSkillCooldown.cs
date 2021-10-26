using System.Collections;

namespace Logic
{
    public interface IUpdateSkillCooldown
    {
        IEnumerator ReduceCooldown(int counter);
        IEnumerator IncreaseCooldown(int counter);
        IEnumerator SetSkillCdToValue(int counter);
        IEnumerator ResetCooldownToMax();
        IEnumerator RefreshCooldownToZero();
        
        //void SetCooldownValue(int counter);
    }
    
}