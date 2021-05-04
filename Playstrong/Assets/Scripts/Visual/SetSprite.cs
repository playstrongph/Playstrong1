using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;

public class SetSprite : MonoBehaviour
{
    [SerializeField] private Sprite _loadSprite;

    public Sprite LoadSprite
    {
        set => _loadSprite = value;
    }
}
