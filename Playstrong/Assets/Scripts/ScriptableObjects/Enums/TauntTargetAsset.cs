using Logic;
using UnityEngine;

namespace ScriptableObjects.Enums
{
    [CreateAssetMenu(fileName = "TauntTarget", menuName = "SO's/Scriptable Enums/TauntTarget")]
    public class TauntTargetAsset : ScriptableObject, ITauntTargetAsset, ITargetStatus
    {
        
    }
}
