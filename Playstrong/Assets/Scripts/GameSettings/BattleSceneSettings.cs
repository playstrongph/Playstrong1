using Interfaces;
using UnityEngine;
using Utilities;

namespace GameSettings
{
    public class BattleSceneSettings : MonoBehaviour
    {

        [SerializeField] private GameObject _heroObjectPrefab;
        public GameObject HeroObjectPrefab => _heroObjectPrefab;

        [SerializeField] private GameObject _buffObjectPrefab;
        public GameObject BuffObjectPrefab => _buffObjectPrefab;

        [SerializeField] private GameObject _skillObjectPrefab;
        public GameObject SkillObjectPrefab => _skillObjectPrefab;


      
        







    }
}
