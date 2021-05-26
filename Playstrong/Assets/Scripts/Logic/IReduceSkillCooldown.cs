namespace Logic
{
    public interface IReduceSkillCooldown
    {
        int ActionIndex { set; }
        void ReduceCd(int counter);
    }
}