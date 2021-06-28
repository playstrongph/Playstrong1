using UnityEngine;

namespace ScriptableObjects.Modifiers
{
    [CreateAssetMenu(fileName = "Modifier", menuName = "SO's/Modifiers/Modifier")]
    public class Modifier : ScriptableObject, IModifier
    {

        [SerializeField] private float _modValue;

        public float ModValue => _modValue;

    }
}
