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

        private IHeroPortraitList _heroPortraitList;
        
        private Transform _heroesListTransform;
       

        private void Awake()
        {
            var player = GetComponent<IPlayer>();
            
            _heroPortraitList = player.HeroPortraitList;
            
            _heroesListTransform = _heroPortraitList.GetTransform();
            
        }

        public IEnumerator InitializePortraits(ITeamHeroesAsset teamHeroesAsset, GameObject heroPortraitPrefab, Transform boardLocation, ICoroutineTree tree)
        {
            
            foreach (var heroAsset in teamHeroesAsset.TeamHeroes())
            {
                var heroPortrait = Instantiate(heroPortraitPrefab, boardLocation);
               
                heroPortrait.transform.SetParent(_heroesListTransform);
                heroPortrait.transform.SetAsLastSibling();
                heroPortrait.name = heroAsset.name;
                _heroPortraitList.HeroList.Add(heroPortrait);

                var iHeroAsset = heroAsset as IHeroAsset;
                heroPortrait.GetComponent<IHeroPortraitReferences>().HeroPortraitImage.sprite = iHeroAsset.HeroSprite;
               
            }

            yield return null;
            tree.EndSequence();

        }
    }
}
