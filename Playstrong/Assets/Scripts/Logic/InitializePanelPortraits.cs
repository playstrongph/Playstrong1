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

       private IObjectList _panelPortraitList;
        
       private Transform _portraitListTransform;

        private void Awake()
        {
            var player = GetComponent<IPlayer>();
            
           _panelPortraitList = player.PanelPortraitList;
            
           _portraitListTransform = _panelPortraitList.Transform;
        }

        public IEnumerator InitializePortraits(ITeamHeroesAsset teamHeroesAsset, GameObject heroPortraitPrefab, Transform boardLocation, ICoroutineTree tree)
        {
            
            foreach (var heroAsset in teamHeroesAsset.TeamHeroes())
            {
                var panelPortrait = Instantiate(heroPortraitPrefab, boardLocation);
                
                panelPortrait.transform.SetParent(_portraitListTransform);
                panelPortrait.transform.SetAsLastSibling();
                panelPortrait.name = heroAsset.name;
                _panelPortraitList.ThisList.Add(panelPortrait);
                
                var iHeroAsset = heroAsset as IHeroAsset;
                panelPortrait.GetComponent<IPortrait>().HeroPortraitImage.sprite = iHeroAsset.HeroSprite;


            }

            yield return null;
            tree.EndSequence();

        }
    }
}
