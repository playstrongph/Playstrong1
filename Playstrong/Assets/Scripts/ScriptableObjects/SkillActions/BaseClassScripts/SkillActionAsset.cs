using Interfaces;
using UnityEngine;

namespace ScriptableObjects.SkillActions.BaseClassScripts
{

    public class SkillActionAsset : ScriptableObject, ISkillActionAsset
    {

        public virtual void Target(IHero hero)
        {
            
        }

    }
}
