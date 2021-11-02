using System;
using System.Collections.Generic;
using System.Linq;
using Interfaces;
using UnityEngine;

namespace Logic
{
    public class StatusEffectImmunityList : MonoBehaviour, IStatusEffectImmunityList
    {
        [SerializeField] private List<ScriptableObject> heroImmunities;

        public List<IHeroStatusEffectImmunity> HeroImmunities
        {
            get
            {
                var heroImmunitiesList = new List<IHeroStatusEffectImmunity>();
                foreach (var immunityObject in this.heroImmunities)
                {
                    var immunity = immunityObject as IHeroStatusEffectImmunity;
                    heroImmunitiesList.Add(immunity);
                }

                return heroImmunitiesList;
            }
        }

        private IHeroLogic _heroLogic;

        private void Awake()
        {
            _heroLogic = GetComponent<IHeroLogic>();
        }


        public void AddToStatusEffectImmunityList(IHeroStatusEffectImmunity heroStatusEffectImmunity)
        {
            var heroStatusEffectImmunityObject = heroStatusEffectImmunity as ScriptableObject;
            heroImmunities.Add(heroStatusEffectImmunityObject);
            
        }
        
        public void RemoveFromStatusEffectImmunityList(IHeroStatusEffectImmunity heroStatusEffectImmunity)
        {
            var heroStatusEffectImmunityObject = heroStatusEffectImmunity as ScriptableObject;
            heroImmunities.Remove(heroStatusEffectImmunityObject);
            
        }




    }
}
