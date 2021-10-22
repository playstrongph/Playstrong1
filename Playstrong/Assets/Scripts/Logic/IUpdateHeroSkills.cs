using System.Collections;

namespace Logic
{
    public interface IUpdateHeroSkills
    {
        IEnumerator UpdateSkills();

        IEnumerator UpdateSkillReadinessStatus();
    }
}