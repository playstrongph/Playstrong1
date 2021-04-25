using System;
using System.Collections;
using Interfaces;
using References;
using UnityEngine;

namespace Logic
{
    public class InitializePlayerHeroes : MonoBehaviour, IInitializePlayerHeroes
    {

        private IHeroesList _heroesList;

        private void Awake()
        {
            _heroesList = GetComponent<IHeroesList>();
        }

        public IEnumerator InitializeHeroes(ITeamHeroesAsset teamHeroesAsset, GameObject heroObjectPrefab, Transform boardLocation, ICoroutineTree tree)
        {
            
            foreach (var heroAsset in teamHeroesAsset.TeamHeroes())
            {
                var hero = Instantiate(heroObjectPrefab, boardLocation);
                    
                hero.transform.SetParent(boardLocation);
                hero.transform.SetAsFirstSibling();
                hero.name = heroAsset.name;
                _heroesList.HeroList.Add(hero);
                
                

                hero.GetComponent<HeroObjectReferences>().HeroLogicReferences.LoadHeroAttributes.LoadHeroAttributesFromHeroAsset((IHeroAsset)heroAsset);
                
                hero.GetComponent<HeroObjectReferences>().HeroVisualReferences.LoadHeroVisuals.LoadHeroVisualsFromHeroAsset((IHeroAsset)heroAsset);
                hero.GetComponent<HeroObjectReferences>().HeroPreviewVisual.LoadHeroPreviewVisuals.LoadHeroPreviewVisualsFromAsset((IHeroAsset)heroAsset);
                

            }

            yield return null;
            tree.EndSequence();

        }
    }
}
