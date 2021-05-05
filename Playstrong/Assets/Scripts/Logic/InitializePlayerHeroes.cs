using System.Collections;
using System.Collections.Generic;
using Interfaces;
using UnityEngine;

namespace Logic
{
    public class InitializePlayerHeroes : MonoBehaviour, IInitializePlayerHeroes
    {

        private IPlayerChildrenReferences _playerChildrenReferences;
        private int _heroIndex;

        private void Awake()
        {
            _playerChildrenReferences = GetComponent<IPlayerChildrenReferences>();
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
                _playerChildrenReferences.LivingHeroes.HeroList.Add(hero);
                
                

                hero.GetComponent<IHeroPrefab>().HeroLogic.LoadHeroAttributes.LoadHeroAttributesFromHeroAsset((IHeroAsset)heroAsset);
                
                hero.GetComponent<IHeroPrefab>().HeroVisual.LoadHeroVisuals.LoadHeroVisualsFromHeroAsset((IHeroAsset)heroAsset);
                hero.GetComponent<IHeroPrefab>().HeroPreviewVisual.LoadHeroPreviewVisuals.LoadHeroPreviewVisualsFromAsset((IHeroAsset)heroAsset);

                hero.GetComponent<IHeroPrefab>().HeroPreviewVisual.PreviewTransform.position = previewLocations[_heroIndex].localPosition;
                _heroIndex++;
                
                
            }

            yield return null;
            tree.EndSequence();

        }
    }
}
