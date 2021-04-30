using System.Collections;
using System.Collections.Generic;
using Interfaces;
using UnityEngine;
using Visual;

namespace Logic
{
    public class InitializeHeroPortraits : MonoBehaviour, IInitializeHeroPortraits
    {

        private IHeroPortraitList _heroesList;
        

        private void Awake()
        {
            _heroesList = GetComponent<IHeroPortraitList>();
            
        }

        public IEnumerator InitializePortraits(ITeamHeroesAsset teamHeroesAsset, GameObject heroPortraitPrefab, Transform boardLocation, ICoroutineTree tree)
        {
            
            foreach (var heroAsset in teamHeroesAsset.TeamHeroes())
            {
                var heroPortrait = Instantiate(heroPortraitPrefab, boardLocation);
                    
                heroPortrait.transform.SetParent(boardLocation);
                heroPortrait.transform.SetAsLastSibling();
                heroPortrait.name = heroAsset.name;
                //_heroesList.HeroList.Add(heroPortrait);

                var iHeroAsset = heroAsset as IHeroAsset;
                //heroPortrait.GetComponent<IHeroPortraitReferences>().HeroPortraitImage.sprite = iHeroAsset.HeroSprite;

            }

            yield return null;
            tree.EndSequence();

        }
    }
}
