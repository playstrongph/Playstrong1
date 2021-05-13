using System;
using System.Collections;
using System.Collections.Generic;
using Interfaces;
using UnityEngine;
using Visual;

namespace Logic
{
    public class InitializeHeroPortraits : MonoBehaviour, IInitializeHeroPortraits
    {

        private IHeroesPortraits _heroesPortraits;
        
        private Transform _heroesListTransform;

        private IPlayer _player;
        
        private ICoroutineTree _logicTree;
        private ICoroutineTree _visualTree;

        private void Awake()
        {
            _player = GetComponent<IPlayer>();

            _heroesPortraits = _player.HeroesPortraits;

            _heroesListTransform = _heroesPortraits.Transform;

        }

        private void Start()
        {
            _logicTree = _player.GlobalTrees.MainLogicTree;
            _visualTree = _player.GlobalTrees.MainVisualTree;
        }

        public IEnumerator InitializePortraits(ITeamHeroesAsset teamHeroesAsset, GameObject heroPortraitPrefab, Transform boardLocation)
        {
            
            foreach (var heroAsset in teamHeroesAsset.TeamHeroes())
            {
                var heroPortrait = Instantiate(heroPortraitPrefab, boardLocation);
               
                heroPortrait.transform.SetParent(_heroesListTransform);
                heroPortrait.transform.SetAsLastSibling();
                heroPortrait.name = heroAsset.name;
                _heroesPortraits.List.Add(heroPortrait);

                var iHeroAsset = heroAsset as IHeroAsset;
                heroPortrait.GetComponent<IPortrait>().HeroPortraitImage.sprite = iHeroAsset.HeroSprite;
               
            }

            yield return null;
            _logicTree.EndSequence();

        }
    }
}
