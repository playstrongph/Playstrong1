using Interfaces;
using UnityEngine;

namespace ScriptableObjects.Enums
{
    [CreateAssetMenu(fileName = "Rarity Enum", menuName = "SO's/Scriptable Enums/Rarity Enum")]
    public class RarityEnumAsset : ScriptableObject, IRarityEnumAsset
    {

        public void LoadRarityVisuals()
        {
        }

    }
}
