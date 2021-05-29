using UnityEngine;

namespace Visual
{
    public class SetSprite : MonoBehaviour
    {
        [SerializeField] private Sprite _loadSprite;

        public Sprite LoadSprite
        {
            set => _loadSprite = value;
        }
    }
}
