﻿using System;
using System.Collections;
using System.Collections.Generic;
using Interfaces;
using UnityEngine;

namespace Logic
{
    public class CreateHeroPortraitReferences : MonoBehaviour, ICreateHeroPortraitReferences
    {
        private IPlayerChildrenReferences _playerChildrenReferences;
        private IPlayerChildrenReferences PlayerChildrenReferences => _playerChildrenReferences;

        private int _index;
        private List<GameObject> _heroPortraits;

        private void Awake()
        {
            _playerChildrenReferences = GetComponent<IPlayerChildrenReferences>();
            _heroPortraits = new List<GameObject>();
            _index = 0;
           
        }

        public IEnumerator CreateReferences(ICoroutineTree tree)
        {
            GetPortraitsReference();
            LoadPortraitReference();
            yield return null;
            tree.EndSequence();
        }


        private void GetPortraitsReference()
        {
            var heroPortraits = PlayerChildrenReferences.HeroPortraitList.GetList();
            foreach (var portrait in heroPortraits)
            {
                _heroPortraits.Add(portrait);
            }
            
        }
        private void LoadPortraitReference()
        {
            var heroes = PlayerChildrenReferences.LivingHeroes.GetList();
            
            foreach (var hero in heroes)
            {
                var heroObjectReference = hero.GetComponent<IHeroPrefab>();
                var portraitReference = heroObjectReference.HeroPortrait;
                
                //set the reference here
                portraitReference.PortraitReference = _heroPortraits[_index];
                _index++;

            }
        }

        
    }
}
