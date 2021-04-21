using Interfaces;
using UnityEngine;

namespace Visual
{
    public class LoadHeroVisuals : MonoBehaviour, ILoadHeroVisuals
    {
        [SerializeReference]
        private IHeroAsset _heroAsset;

        [SerializeReference]
        private IHeroVisualReferences _heroVisualReferences;

        private void Awake()
        {
            _heroVisualReferences = GetComponent<IHeroVisualReferences>();
        }
        
        
        public void LoadHeroVisualsFromHeroAsset(IHeroAsset heroAsset)
        {
            _heroAsset = heroAsset;
            
            _heroVisualReferences.HeroGraphic.SetHeroGraphic(_heroAsset.HeroSprite);
            _heroVisualReferences.AttackVisual.SetAttackText(_heroAsset.Attack.ToString());
            _heroVisualReferences.ArmorVisual.SetArmorText(_heroAsset.Armor.ToString());
            _heroVisualReferences.HealthVisual.SetHealthText(_heroAsset.Health.ToString());

        }



    }
}
