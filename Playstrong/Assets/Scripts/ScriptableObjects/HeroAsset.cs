using Assets.Scripts.Editor;
using UnityEngine;



namespace Assets.Scripts.ScriptableObjects
{
    [CreateAssetMenu(fileName = "New Hero", menuName = "SO's/New Hero")]
    public class HeroAsset : ScriptableObject
    {

        [SerializeField] [RequireInterface(typeof(IRarityEnum))]
        private ScriptableObject _rarity;
        public IRarityEnum Rarity => _rarity as IRarityEnum;

    }
}
