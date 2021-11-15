using System;
using Interfaces;
using Logic;
using ScriptableObjects;
using ScriptableObjects.Others;
using UnityEngine;
using Utilities;
using Visual;
using Object = UnityEngine.Object;


namespace References
{
    public class Skill : MonoBehaviour, ISkill
    {

        [SerializeField] private string _skillName;

        public string SkillName
        {
            get => _skillName;
            set => _skillName = value;
        }

        [SerializeField] [RequireInterface(typeof(ISkillLogic))]
        private Object _skillLogic;
        public ISkillLogic SkillLogic => _skillLogic as ISkillLogic;
        
        [SerializeField] [RequireInterface(typeof(ISkillVisual))]
        private Object _skillVisual;
        public ISkillVisual SkillVisual => _skillVisual as ISkillVisual;
        
        [SerializeField] [RequireInterface(typeof(ISkillPreviewVisual))]
        private Object _skillPreviewVisual;
        public ISkillPreviewVisual SkillPreviewVisual => _skillPreviewVisual as ISkillPreviewVisual;
        
          
        [SerializeField] [RequireInterface(typeof(ITargetSkill))]
        private Object _targetSkill;
        public ITargetSkill TargetSkill => _targetSkill as ITargetSkill;

        [SerializeField] [RequireInterface(typeof(IHero))]
        private Object _hero;

        public IHero Hero
        {
            get => _hero as IHero;
            set => _hero = value as Object;
        }


        [SerializeField] [RequireInterface(typeof(ICoroutineTreesAsset))]
        private ScriptableObject _coroutineTreesAsset;
        public ICoroutineTreesAsset CoroutineTreesAsset => _coroutineTreesAsset as ICoroutineTreesAsset;

        [SerializeField] [RequireInterface(typeof(ISkill))]
        private Object _panelSkill;

        public ISkill PanelSkill
        {
            get => _panelSkill as ISkill;
            set => _panelSkill = value as Object;
        }

        
    }
}
