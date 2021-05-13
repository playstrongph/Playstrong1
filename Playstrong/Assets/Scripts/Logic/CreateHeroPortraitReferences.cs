using System;
using System.Collections;
using System.Collections.Generic;
using Interfaces;
using UnityEngine;

namespace Logic
{
    public class CreateHeroPortraitReferences : MonoBehaviour, ICreateHeroPortraitReferences
    {
        private IPlayer _player;
        private IPlayer Player => _player;

        private int _index;
        private List<GameObject> _heroPortraits;
        
        private ICoroutineTree _logicTree;
        private ICoroutineTree _visualTree;

        private void Awake()
        {
            _player = GetComponent<IPlayer>();
            _heroPortraits = new List<GameObject>();
            _index = 0;
        }
        
        private void Start()
        {
            _logicTree = _player.GlobalTrees.MainLogicTree;
            _visualTree = _player.GlobalTrees.MainVisualTree;
        }
        

        public IEnumerator CreateReferences()
        {
            GetPortraitsReference();
            LoadPortraitReference();
            yield return null;
            _logicTree.EndSequence();
        }


        private void GetPortraitsReference()
        {
            var heroPortraits = Player.HeroesPortraits.List;
            foreach (var portrait in heroPortraits)
            {
                _heroPortraits.Add(portrait);
            }
            
        }
        private void LoadPortraitReference()
        {
            var heroes = Player.LivingHeroes.HeroesList;
            
            foreach (var hero in heroes)
            {
                var heroObjectReference = hero.GetComponent<IHero>();
                var portraitReference = heroObjectReference.HeroPortrait;
                
                //set the reference here
                portraitReference.Portrait = _heroPortraits[_index];
                _index++;

            }
        }

        
    }
}
