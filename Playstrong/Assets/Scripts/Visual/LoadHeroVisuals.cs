using Interfaces;
using UnityEngine;

namespace Visual
{
    public class LoadHeroVisuals : MonoBehaviour, ILoadHeroVisuals
    {
        
        private IHeroVisualReferences _heroVisualReferences;

        private void Awake()
        {
            _heroVisualReferences = GetComponent<IHeroVisualReferences>();
        }
        
        
        public void LoadHeroVisualsFromHeroAsset(IHeroAsset heroAsset)
        {
            _heroVisualReferences.HeroGraphic.SetHeroGraphic(heroAsset.HeroSprite);
            _heroVisualReferences.AttackVisual.SetAttackText(heroAsset.Attack.ToString());
            _heroVisualReferences.ArmorVisual.SetArmorText(heroAsset.Armor.ToString());
            _heroVisualReferences.HealthVisual.SetHealthText(heroAsset.Health.ToString());

        }



    }
}
