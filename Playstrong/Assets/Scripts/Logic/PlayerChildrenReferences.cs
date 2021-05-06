using System.Collections.Generic;
using Interfaces;
using UnityEngine;
using Utilities;

namespace Logic
{
    public class PlayerChildrenReferences : MonoBehaviour, IPlayerChildrenReferences
    {
        [SerializeField] [RequireInterface(typeof(IObjectList))]
        private Object _livingHeroes;
        public IObjectList LivingHeroes => _livingHeroes as IObjectList;
        
        [SerializeField] [RequireInterface(typeof(IObjectList))]
        private Object _deadHeroes;
        public IObjectList DeadHeroes => _deadHeroes as IObjectList;

        [SerializeField] [RequireInterface(typeof(IObjectList))]
        private Object _heroSkillsList;
        public IObjectList HeroSkillsList => _heroSkillsList as IObjectList;

        [SerializeField] [RequireInterface(typeof(IHeroPortraitList))]
        private Object _heroPortraitList;
        public IHeroPortraitList HeroPortraitList => _heroPortraitList as IHeroPortraitList;
        
        [SerializeField] [RequireInterface(typeof(IObjectList))]
        private Object _panelSkillsList;
        public IObjectList PanelSkillsList => _panelSkillsList as IObjectList;
        
        [SerializeField] [RequireInterface(typeof(IHeroPortraitList))]
        private Object _panelPortraitList;
        public IHeroPortraitList PanelPortraitList => _panelPortraitList as IHeroPortraitList;





    }
}
