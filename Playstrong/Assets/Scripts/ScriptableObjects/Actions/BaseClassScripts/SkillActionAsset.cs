using System.Collections;
using Interfaces;
using ScriptableObjects.Actions.BaseClassScripts;
using ScriptableObjects.Others;
using UnityEngine;

namespace ScriptableObjects.SkillActions.BaseClassScripts
{

    public class SkillActionAsset : ScriptableObject, ISkillActionAsset
    {
        protected ICoroutineTree LogicTree;
        protected ICoroutineTree VisualTree;

        public virtual void Target(IHero hero)
        {
            

        }

       




    }
}
