﻿using System;
using System.Collections;
using System.Collections.Generic;
using Interfaces;
using ScriptableObjects;
using UnityEngine;
using Utilities;
using Object = UnityEngine.Object;

namespace Logic
{
    public class InitializePlayerHeroes : MonoBehaviour, IInitializePlayerHeroes
    {
        private IPlayer _player;
        private int _heroIndex;
        
        private ICoroutineTree _logicTree;
        private ICoroutineTree _visualTree;

        private void Awake()
        {
            _player = GetComponent<IPlayer>();
            _heroIndex = 0;
        }

        private void Start()
        {

            _logicTree = _player.GlobalTrees.MainLogicTree;
            _visualTree = _player.GlobalTrees.MainVisualTree;
        }

        public IEnumerator InitializeHeroes(ITeamHeroesAsset teamHeroesAsset, GameObject heroObjectPrefab, Transform boardLocation, List<Transform> previewLocations)
        {
            
            
            foreach (var heroAsset in teamHeroesAsset.TeamHeroes())
            {
                var heroObject = Instantiate(heroObjectPrefab, boardLocation);
                    
                heroObject.transform.SetParent(boardLocation);
                heroObject.transform.SetAsLastSibling();
                heroObject.name = heroAsset.name;
                _player.LivingHeroes.HeroesList.Add(heroObject);

                var hero = heroObject.GetComponent<IHero>();


                hero.HeroName =  heroObject.name;
                hero.HeroLogic.LoadHeroAttributes.LoadHeroAttributesFromHeroAsset((IHeroAsset)heroAsset);
                hero.HeroVisual.LoadHeroVisuals.LoadHeroVisualsFromHeroAsset((IHeroAsset)heroAsset);
                hero.HeroPreviewVisual.LoadHeroPreviewVisuals.LoadHeroPreviewVisualsFromAsset((IHeroAsset)heroAsset);
                hero.HeroPreviewVisual.PreviewTransform.position = previewLocations[_heroIndex].localPosition;
                _heroIndex++;
                
                
            }

            yield return null;
            _logicTree.EndSequence();

        }
    }
}
