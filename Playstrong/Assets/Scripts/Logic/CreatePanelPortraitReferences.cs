using System;
using System.Collections;
using System.Collections.Generic;
using Interfaces;
using UnityEngine;

namespace Logic
{
    public class CreatePanelPortraitReferences : MonoBehaviour, ICreatePanelPortraitReferences
    {
        private IHeroesListReference _heroesListReference;
        private IHeroesListReference HeroesListReference => _heroesListReference;

        private int _index = 0;
        private List<GameObject> _panelHeroPortraits;

        
        private void Awake()
        {
            _heroesListReference = GetComponent<IHeroesListReference>();
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
            var heroPortraits = HeroesListReference.PanelPortraitList.GetList();
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
            var heroes = HeroesListReference.LivingHeroes.GetList();

            foreach (var hero in heroes)
            {
                var heroObjectReference = hero.GetComponent<IHeroObjectReferences>();
                var panelPortraitReference = heroObjectReference.PanelHeroPortrait;

                panelPortraitReference.PortraitReference = _panelHeroPortraits[_index];
                _index++;

            }
        }

        
    }
}
