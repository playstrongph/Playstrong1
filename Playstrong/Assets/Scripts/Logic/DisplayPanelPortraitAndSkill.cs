using UnityEngine;
using Visual;

namespace Logic
{
    public class DisplayPanelPortraitAndSkill : MonoBehaviour
    {
        private ITargetHero _targetHero;
        private IPanelHeroPortrait _panelHeroPortrait;
        private IPanelHeroSkills _panelHeroSkills;

      
        private void Awake()
        {
            _targetHero = GetComponent<ITargetHero>();
        }

        public void OnMouseDown()
        {
            _targetHero.Hero.LivingHeroesReference.PanelPortaitAndSkillDisplay.PanelPortrait.SetActive(false);
            _targetHero.Hero.LivingHeroesReference.PanelPortaitAndSkillDisplay.PanelSkills.SetActive(false);

            _panelHeroPortrait = _targetHero.Hero.PanelHeroPortrait;
            _panelHeroSkills = _targetHero.Hero.PanelHeroSkills;
        
            _panelHeroPortrait.Portrait.SetActive(true);
            _panelHeroSkills.PanelSkills.SetActive(true);
            
            _targetHero.Hero.LivingHeroesReference.PanelPortaitAndSkillDisplay.PanelPortrait = _panelHeroPortrait.Portrait;
            _targetHero.Hero.LivingHeroesReference.PanelPortaitAndSkillDisplay.PanelSkills = _panelHeroSkills.PanelSkills;
            
        }

    
    }
}
