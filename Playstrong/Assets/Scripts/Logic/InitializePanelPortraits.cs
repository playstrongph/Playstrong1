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
       
       private IPlayer _player;
       
       private ICoroutineTree _logicTree;
       private ICoroutineTree _visualTree;

        private void Awake()
        {
            _player = GetComponent<IPlayer>();
            
            _panelPortraits = _player.PanelPortraits;
            
            _panelPortraitsTransform = _panelPortraits.Transform;
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
            _logicTree.EndSequence();

        }
    }
}
