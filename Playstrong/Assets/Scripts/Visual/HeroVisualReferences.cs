using Interfaces;
using References;
using UnityEngine;
using Utilities;

namespace Visual
{
    public class HeroVisualReferences : MonoBehaviour, IHeroVisualReferences
    {
        // [SerializeField]
        // private HeroObjectReferences heroObjectReferences;

        [SerializeField]
        [RequireInterface(typeof(IHeroObjectReferences))]
        private Object _heroObjectReferences;
        public IHeroObjectReferences HeroObjectReferences => _heroObjectReferences as IHeroObjectReferences;
        
        
        
        [SerializeField]
        private Canvas heroCanvas;
        public Canvas HeroCanvas => heroCanvas;

        
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

        




    }
}
