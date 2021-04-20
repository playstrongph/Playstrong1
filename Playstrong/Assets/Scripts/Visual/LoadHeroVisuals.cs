using System;
using System.Collections;
using System.Collections.Generic;
using Interfaces;
using UnityEngine;
using Utilities;
using Object = UnityEngine.Object;

public class LoadHeroVisuals : MonoBehaviour
{
    [SerializeReference]
    private IHeroAsset _heroAsset;

    [SerializeReference]
    private IHeroVisualReferences _heroVisualReferences;

    private void Awake()
    {
        _heroVisualReferences = GetComponent<IHeroVisualReferences>();
    }

    public void SetHeroAsset(IHeroAsset heroAsset)
    {
        _heroAsset = heroAsset;
    }

    public void LoadHeroVisualsFromHeroAsset()
    {
           
    }



}
