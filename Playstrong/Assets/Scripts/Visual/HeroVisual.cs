using System;
using Interfaces;
using References;
using UnityEngine;
using Utilities;
using Object = UnityEngine.Object;

namespace Visual
{
    public class HeroVisual : MonoBehaviour, IHeroVisual
    {
       
        [SerializeField]
        [RequireInterface(typeof(IHero))]
        private Object _hero;
        public IHero Hero => _hero as IHero;
        

        [SerializeField]
        private Canvas _heroCanvas;
        public Canvas HeroCanvas => _heroCanvas;

        
        [SerializeField]
        [RequireInterface(typeof(ITauntFrameAndGlow))]
        private Object _tauntFrameAndGlow;
        public ITauntFrameAndGlow TauntFrameAndGlow => _tauntFrameAndGlow as ITauntFrameAndGlow;
        
        [SerializeField] 
        [RequireInterface(typeof(INormalFrameAndGlow))]
        private Object _normalFrameAndGlow;
        public INormalFrameAndGlow NormalFrameAndGlow => _normalFrameAndGlow as INormalFrameAndGlow;

        [SerializeField]
        [RequireInterface(typeof(ISetHeroGraphic))]
        private Object _heroGraphic;
        public ISetHeroGraphic HeroGraphic => _heroGraphic as ISetHeroGraphic;

        [SerializeField] [RequireInterface(typeof(ISetAttackVisual))]
        private Object _attackVisual;
        public ISetAttackVisual AttackVisual => _attackVisual as ISetAttackVisual;
        
        [SerializeField] [RequireInterface(typeof(ISetArmorVisual))]
        private Object _armorVisual;

        public ISetArmorVisual ArmorVisual => _armorVisual as ISetArmorVisual;
        
        [SerializeField] [RequireInterface(typeof(ISetHealthVisual))]
        private Object _healthVisual;
        public ISetHealthVisual HealthVisual => _healthVisual as ISetHealthVisual;
        
        [SerializeField] [RequireInterface(typeof(ISetEnergyVisual))]
        private Object _energyVisual;
        public ISetEnergyVisual EnergyVisual => _energyVisual as ISetEnergyVisual;

        [SerializeField] [RequireInterface(typeof(IFightingSpiritVisual))]
        private Object _fightingSpiritVisual;

        public IFightingSpiritVisual FightingSpiritVisual => _fightingSpiritVisual as IFightingSpiritVisual;

        
        [SerializeField] [RequireInterface(typeof(ILoadHeroVisuals))]
        private Object _loadHeroVisuals;

        public ILoadHeroVisuals LoadHeroVisuals => _loadHeroVisuals as ILoadHeroVisuals;

        [SerializeField] [RequireInterface(typeof(ISetHeroFrameAndGlow))]
        private Object _setHeroFrameAndGlow;
        public ISetHeroFrameAndGlow SetHeroFrameAndGlow => _setHeroFrameAndGlow as ISetHeroFrameAndGlow;
    }
}
