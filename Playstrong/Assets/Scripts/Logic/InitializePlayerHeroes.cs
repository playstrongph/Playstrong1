using System.Collections;
using Interfaces;
using References;
using UnityEngine;

namespace Logic
{
    public class InitializePlayerHeroes : MonoBehaviour, IInitializePlayerHeroes
    {
        public IEnumerator InitializeHeroes(ITeamHeroesAsset teamHeroesAsset, GameObject heroObjectPrefab, Transform boardLocation)
        {
            
            foreach (var heroAsset in teamHeroesAsset.TeamHeroes())
            {
                var hero = Instantiate(heroObjectPrefab, boardLocation);
                    
                hero.transform.SetParent(boardLocation);
                hero.transform.SetAsFirstSibling();
                hero.name = heroAsset.name;

                hero.GetComponent<HeroObjectReferences>().HeroLogicReferences.LoadHeroAttributes.LoadHeroAttributesFromHeroAsset((IHeroAsset)heroAsset);
                hero.GetComponent<HeroObjectReferences>().HeroVisualReferences.LoadHeroVisuals.LoadHeroVisualsFromHeroAsset((IHeroAsset)heroAsset);
                    
                    
            }

            yield return null;

        }
    }
}
