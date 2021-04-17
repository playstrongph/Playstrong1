using Assets.Scripts.References;
using Assets.Scripts.Visual;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace Visual
{
    public class HeroVisual : MonoBehaviour
    {
        [SerializeField]
        private HeroObjectReferences heroObjectReferences;   
        
        [SerializeField]
        private Canvas heroCanvas;
        public Canvas HeroCanvas => heroCanvas;


        [SerializeField]
        private TauntFrame tauntFrame;
        public TauntFrame TauntFrame => tauntFrame;

        [SerializeField]
        private NormalFrame normalFrame;

        public NormalFrame NormalFrame => normalFrame;

        [SerializeField]
        private Image heroGraphic;

        public Sprite HeroGraphic
        {
            set => heroGraphic.sprite = value;
        }
        
        [SerializeField]
        private AttackVisual attackVisual;
        public AttackVisual AttackVisual => attackVisual;

        [SerializeField]
        private ArmorVisual armorVisual;
        public ArmorVisual ArmorVisual => armorVisual;


        [SerializeField]
        private HealthVisual healthVisual;
        public HealthVisual HealthVisual => healthVisual;

        [SerializeField]
        private EnergyVisual energyVisual;
        public EnergyVisual EnergyVisual => energyVisual;
    }
}
