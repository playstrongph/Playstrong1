using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Interfaces
{
    public class InitializePlayerHeroes : MonoBehaviour, IInitializePlayerHeroes
    {

        private IHeroesListReference _heroesList;
        private int _heroIndex;

        private void Awake()
        {
            _heroesList = GetComponent<IHeroesListReference>();
            _heroIndex = 0;
        }

        public IEnumerator InitializeHeroes(ITeamHeroesAsset teamHeroesAsset, GameObject heroObjectPrefab, Transform boardLocation, List<Transform> previewLocations, ICoroutineTree tree)
        {
            
            foreach (var heroAsset in teamHeroesAsset.TeamHeroes())
            {
                var hero = Instantiate(heroObjectPrefab, boardLocation);
                    
                hero.transform.SetParent(boardLocation);
                hero.transform.SetAsLastSibling();
                hero.name = heroAsset.name;
                _heroesList.LivingHeroes.HeroList.Add(hero);
                
                

                hero.GetComponent<IHeroObjectReferences>().HeroLogicReferences.LoadHeroAttributes.LoadHeroAttributesFromHeroAsset((IHeroAsset)heroAsset);
                
                hero.GetComponent<IHeroObjectReferences>().HeroVisualReferences.LoadHeroVisuals.LoadHeroVisualsFromHeroAsset((IHeroAsset)heroAsset);
                hero.GetComponent<IHeroObjectReferences>().HeroPreviewVisual.LoadHeroPreviewVisuals.LoadHeroPreviewVisualsFromAsset((IHeroAsset)heroAsset);

                hero.GetComponent<IHeroObjectReferences>().HeroPreviewVisual.PreviewTransform.position = previewLocations[_heroIndex].localPosition;
                _heroIndex++;





            }

            yield return null;
            tree.EndSequence();

        }
    }
}
