using Interfaces;

namespace ScriptableObjects.Enums.SkillStatus
{
    public interface ISkillStatus
    {
        void StatusAction(ISkillLogic skillLogic);
    }
}