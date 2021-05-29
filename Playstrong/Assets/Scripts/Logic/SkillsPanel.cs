using System.Collections.Generic;
using Interfaces;
using ScriptableObjects;
using ScriptableObjects.Others;
using UnityEngine;
using Utilities;
using Object = UnityEngine.Object;

namespace Logic
{
    public class SkillsPanel : MonoBehaviour, ISkillsPanel
    {
        [SerializeField]
        [RequireInterface(typeof(IHero))]
        private Object _hero;

        public IHero Hero
        {
            get => _hero as IHero;
            set => _hero = value as Object;
        }
        
        
        [SerializeField]
        [RequireInterface(typeof(ICoroutineTreesAsset))]
        private Object _coroutineTreesAsset;
        
        public ICoroutineTreesAsset CoroutineTreesAsset => _coroutineTreesAsset as ICoroutineTreesAsset;

        [SerializeField] private List<GameObject> _skillList = new List<GameObject>();
        public List<GameObject> SkillList => _skillList;

        private IUpdateHeroSkills _updateHeroSkills;
        public IUpdateHeroSkills UpdateHeroSkills => _updateHeroSkills;

        private void Awake()
        {
            _updateHeroSkills = GetComponent<IUpdateHeroSkills>();
        }
    }
}
