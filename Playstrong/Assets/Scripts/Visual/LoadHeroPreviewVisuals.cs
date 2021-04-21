using System.Collections;
using System.Collections.Generic;
using Interfaces;
using UnityEngine;

public class LoadHeroPreviewVisuals : MonoBehaviour, ILoadHeroPreviewVisuals
{
   
    [SerializeReference]
    private IHeroPreviewVisual _heroPreviewVisualReferences;

    private void Awake()
    {
        _heroPreviewVisualReferences = GetComponent<IHeroPreviewVisual>();
    }

    public void LoadHeroPreviewVisualsFromAsset(IHeroAsset heroAsset)
    {
       
        _heroPreviewVisualReferences.HeroPreviewGraphic.SetHeroPreviewGraphic(heroAsset.HeroSprite);
        _heroPreviewVisualReferences.HeroPreviewName.SetHeroPreviewName(heroAsset.Name);
        _heroPreviewVisualReferences.HeroPreviewAttack.SetHeroPreviewAttack(heroAsset.Attack.ToString());
        _heroPreviewVisualReferences.HeroPreviewHealth.SetHeroPreviewHealth(heroAsset.Health.ToString());
        _heroPreviewVisualReferences.HeroPreviewSpeed.SetHeroPreviewSpeed(heroAsset.Speed.ToString());
        _heroPreviewVisualReferences.HeroPreviewChance.SetHeroPreviewChance(heroAsset.Chance.ToString());
        
    }

}
