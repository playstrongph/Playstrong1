using System.Collections;

namespace Logic
{
    public interface IUpdateSkillCooldown
    {
        IEnumerator TurnReduceCooldown(int counter);
        IEnumerator IncreaseCooldown(int counter);
        IEnumerator SetSkillCdToValue(int counter);
        IEnumerator TurnResetCooldownToMax();
        IEnumerator RefreshCooldownToZero();
        
        //void SetCooldownValue(int counter);
    }
    
}