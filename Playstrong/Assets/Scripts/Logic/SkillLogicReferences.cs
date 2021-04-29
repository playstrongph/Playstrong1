using System;
using Interfaces;
using UnityEngine;
using Utilities;
using Object = UnityEngine.Object;

namespace Logic
{
    public class SkillLogicReferences : MonoBehaviour, ISkillLogicReferences
    {

        [SerializeField] [RequireInterface(typeof(ISkillAttributes))]
        private Object _skillAttributes;
        public ISkillAttributes SkillAttributes => _skillAttributes as ISkillAttributes;



    }
}
