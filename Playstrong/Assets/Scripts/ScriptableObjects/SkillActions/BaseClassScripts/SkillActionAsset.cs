using Interfaces;
using UnityEngine;

namespace ScriptableObjects.SkillActions
{

    public class SkillActionAsset : ScriptableObject, ISkillActionAsset
    {

        public virtual void Target(IHero hero)
        {
            
        }

    }
}
