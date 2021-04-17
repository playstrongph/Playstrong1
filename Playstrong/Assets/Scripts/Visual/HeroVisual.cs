using Assets.Scripts.References;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Visual
{
    public class HeroVisual : MonoBehaviour
    {
        [SerializeField]
        private HeroObjectReferences _heroObjectReferences;   
        
        [SerializeField]
        private Canvas _heroCanvas;

        public Canvas HeroCanvas
        {
            get { return _heroCanvas; }
        }
        

        [SerializeField]
        private TauntFrame _tauntFrame;

        public TauntFrame TauntFrame
        {
            get { return _tauntFrame; }
        }
        
        [SerializeField]
        private NormalFrame _normalFrame;

        public NormalFrame NormalFrame
        {
            get { return _normalFrame; }
        }
        
        [SerializeField]
        private Image _heroGraphic;

        public Sprite HeroGraphic
        {
            set { _heroGraphic.sprite = value; }
        }
        
        
        [SerializeField]
        private AttackVisual _attackVisual;
        public AttackVisual AttackVisual
        {
            get { return _attackVisual; }
        }

        [SerializeField]
        private ArmorVisual _armorVisual;
        public ArmorVisual ArmorVisual
        {
            get { return _armorVisual; }
        }
        
        
        [SerializeField]
        private HealthVisual _healthVisual;
        public HealthVisual HealthVisual
        {
            get { return _healthVisual; }
        }
        
        [SerializeField]
        private EnergyVisual _energyVisual;
        public EnergyVisual EnergyVisual
        {
            get { return _energyVisual; }
        }

       

    }
}
