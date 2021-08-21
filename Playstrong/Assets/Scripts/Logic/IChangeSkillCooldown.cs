using System.Collections;

namespace Logic
{
    public interface IChangeSkillCooldown
    {
        IEnumerator ReduceCooldown(int counter);
        IEnumerator IncreaseCooldown(int counter);


        void SetCooldownValue(int counter);
        
        //For Exclusive use by SkillType
        IEnumerator SetSkillCdValue(int counter);
        
        
        IEnumerator ResetCooldown();
        IEnumerator RefreshCooldown();
    }
}