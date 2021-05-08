using System;
using System.Collections;
using System.Collections.Generic;
using Interfaces;
using UnityEngine;
using Visual;

namespace Logic
{
    public class InitializePanelPortraits : MonoBehaviour, IInitializePanelPortraits
    {

       private IPanelPortraits _panelPortraits;
        
       private Transform _panelPortraitsTransform;

        private void Awake()
        {
            var player = GetComponent<IPlayer>();
            
            _panelPortraits = player.PanelPortraits;
            
            _panelPortraitsTransform = _panelPortraits.Transform;
        }

        public IEnumerator InitializePortraits(ITeamHeroesAsset teamHeroesAsset, GameObject heroPortraitPrefab, Transform boardLocation, ICoroutineTree tree)
        {
            
            foreach (var heroAsset in teamHeroesAsset.TeamHeroes())
            {
                var panelPortrait = Instantiate(heroPortraitPrefab, boardLocation);
                
                panelPortrait.transform.SetParent(_panelPortraitsTransform);
                panelPortrait.transform.SetAsLastSibling();
                panelPortrait.name = heroAsset.name;
                _panelPortraits.List.Add(panelPortrait);
                
                var iHeroAsset = heroAsset as IHeroAsset;
                panelPortrait.GetComponent<IPortrait>().HeroPortraitImage.sprite = iHeroAsset.HeroSprite;
                
                //Hide Panel Portraits after loading
                panelPortrait.SetActive(false);

            }

            yield return null;
            tree.EndSequence();

        }
    }
}
