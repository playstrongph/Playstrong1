using System;
using System.Collections;
using System.Collections.Generic;
using Interfaces;
using UnityEngine;

namespace Logic
{
    public class CreatePanelPortraitReferences : MonoBehaviour, ICreatePanelPortraitReferences
    {
        private IPlayer _player;
        private IPlayer Player => _player;

        private int _index = 0;
        private List<GameObject> _panelHeroPortraits;

        
        private void Awake()
        {
            _player = GetComponent<IPlayer>();
            _panelHeroPortraits = new List<GameObject>();
        }
        
        
        public IEnumerator CreateReferences(ICoroutineTree tree)
        {
            GetPortraitsReference();
            LoadPortraitReference();
            
            yield return null;
            tree.EndSequence();
        }

        /// <summary>
        /// This is the source of the panel portrait GameObjects
        /// that we want to reference
        /// </summary>
        private void GetPortraitsReference()
        {
            var heroPortraits = Player.PanelPortraitList.ThisList;
            foreach (var portrait in heroPortraits)
            {
                _panelHeroPortraits.Add(portrait);
            }
        }
        
        /// <summary>
        /// This is the panel portrait reference at the Hero level (destination)
        /// that references the panel portraits at the Player Level
        /// </summary>
        private void LoadPortraitReference()
        {
            var heroes = Player.LivingHeroes.HeroesList;

            foreach (var hero in heroes)
            {
                var heroObjectReference = hero.GetComponent<IHero>();
                var panelPortraitReference = heroObjectReference.PanelHeroPortrait;

                panelPortraitReference.Portrait = _panelHeroPortraits[_index];
                _index++;

            }
        }

        
    }
}
