using System.Collections.Generic;
using Interfaces;
using UnityEngine;
using Utilities;

namespace Logic
{
    public class HeroesListReference : MonoBehaviour, IHeroesListReference
    {
        [SerializeField] [RequireInterface(typeof(IHeroesList))]
        private Object _livingHeroes;
        public IHeroesList LivingHeroes => _livingHeroes as IHeroesList;
        
        [SerializeField] [RequireInterface(typeof(IHeroesList))]
        private Object _deadHeroes;
        public IHeroesList DeadHeroes => _deadHeroes as IHeroesList;

        [SerializeField] [RequireInterface(typeof(IHeroesList))]
        private Object _heroSkillsList;
        public IHeroesList HeroSkillsList => _heroSkillsList as IHeroesList;

        [SerializeField] [RequireInterface(typeof(IHeroPortraitList))]
        private Object _heroPortraitList;
        public IHeroPortraitList HeroPortraitList => _heroPortraitList as IHeroPortraitList;
        
        [SerializeField] [RequireInterface(typeof(IHeroesList))]
        private Object _panelSkillsList;
        public IHeroesList PanelSkillsList => _panelSkillsList as IHeroesList;
        
        [SerializeField] [RequireInterface(typeof(IHeroPortraitList))]
        private Object _panelPortraitList;
        public IHeroPortraitList PanelPortraitList => _panelPortraitList as IHeroPortraitList;





    }
}
