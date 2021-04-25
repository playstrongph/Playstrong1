using System;
using System.Collections;
using System.Collections.Generic;
using Interfaces;
using References;
using UnityEngine;

namespace Logic
{
    public class InitializePlayerHeroes : MonoBehaviour, IInitializePlayerHeroes
    {

        private IHeroesListReference _heroesList;

        private void Awake()
        {
            _heroesList = GetComponent<IHeroesListReference>();
        }

        public IEnumerator InitializeHeroes(ITeamHeroesAsset teamHeroesAsset, GameObject heroObjectPrefab, Transform boardLocation, List<Transform> previewLocations, ICoroutineTree tree)
        {
            
            foreach (var heroAsset in teamHeroesAsset.TeamHeroes())
            {
                var hero = Instantiate(heroObjectPrefab, boardLocation);
                    
                hero.transform.SetParent(boardLocation);
                hero.transform.SetAsFirstSibling();
                hero.name = heroAsset.name;
                _heroesList.LivingHeroes.HeroList.Add(hero);
                
                

                hero.GetComponent<IHeroObjectReferences>().HeroLogicReferences.LoadHeroAttributes.LoadHeroAttributesFromHeroAsset((IHeroAsset)heroAsset);
                
                hero.GetComponent<IHeroObjectReferences>().HeroVisualReferences.LoadHeroVisuals.LoadHeroVisualsFromHeroAsset((IHeroAsset)heroAsset);
                hero.GetComponent<IHeroObjectReferences>().HeroPreviewVisual.LoadHeroPreviewVisuals.LoadHeroPreviewVisualsFromAsset((IHeroAsset)heroAsset, previewLocations);
                
                

            }

            yield return null;
            tree.EndSequence();

        }
    }
}
