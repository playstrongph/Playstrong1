using System;
using Interfaces;
using UnityEngine;
using Utilities;
using Visual;
using Object = UnityEngine.Object;

namespace Logic
{
    public class SkillLogic : MonoBehaviour, ISkillLogic
    {
        private ISkillAttributes _skillAttributes;
        public ISkillAttributes SkillAttributes => _skillAttributes as ISkillAttributes;

        private ILoadSkillAttributes _loadSkillAttributes;
        public ILoadSkillAttributes LoadSkillAttributes => _loadSkillAttributes;

        private void Awake()
        {
            _skillAttributes = GetComponent<ISkillAttributes>();
            _loadSkillAttributes = GetComponent<ILoadSkillAttributes>();
        }
    }
}
