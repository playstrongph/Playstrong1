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
       

        private void Awake()
        {
            var player = GetComponent<IPlayer>();

            _heroesPortraits = player.HeroesPortraits;

            _heroesListTransform = _heroesPortraits.Transform;

        }

        public IEnumerator InitializePortraits(ITeamHeroesAsset teamHeroesAsset, GameObject heroPortraitPrefab, Transform boardLocation, ICoroutineTree tree)
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
            tree.EndSequence();

        }
    }
}
