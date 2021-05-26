using System.Collections.Generic;
using ScriptableObjects;
using UnityEngine;
using Utilities;
using Object = UnityEngine.Object;

namespace Logic
{
    public class HeroSkillsList : MonoBehaviour, IHeroSkillsList
    {
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
