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

        private void Awake()
        {
            _player = GetComponent<IPlayer>();
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
            var heroPortraits = Player.HeroPortraitList.ThisList;
            foreach (var portrait in heroPortraits)
            {
                _heroPortraits.Add(portrait);
            }
            
        }
        private void LoadPortraitReference()
        {
            var heroes = Player.LivingHeroes.ThisList;
            
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
