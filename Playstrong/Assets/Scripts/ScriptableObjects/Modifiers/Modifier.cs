using UnityEngine;

namespace ScriptableObjects.Modifiers
{
    [CreateAssetMenu(fileName = "Modifier", menuName = "SO's/Modifiers/Modifier")]
    public class Modifier : ScriptableObject, IModifier
    {

        [SerializeField] private float _modValue;

        public float ModValue
        {
            get => _modValue;
            set => _modValue = value;
        }
    }

    }

