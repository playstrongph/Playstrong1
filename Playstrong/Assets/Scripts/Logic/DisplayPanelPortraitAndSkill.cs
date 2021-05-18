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
            _targetHero.Hero.LivingHeroes.PanelPortaitAndSkillDisplay.PanelPortrait.SetActive(false);
            _targetHero.Hero.LivingHeroes.PanelPortaitAndSkillDisplay.PanelSkills.SetActive(false);

            _panelHeroPortrait = _targetHero.Hero.PanelHeroPortrait;
            _panelHeroSkills = _targetHero.Hero.PanelHeroSkills;
        
            _panelHeroPortrait.Portrait.SetActive(true);
            _panelHeroSkills.PanelSkills.SetActive(true);
            
            _targetHero.Hero.LivingHeroes.PanelPortaitAndSkillDisplay.PanelPortrait = _panelHeroPortrait.Portrait;
            _targetHero.Hero.LivingHeroes.PanelPortaitAndSkillDisplay.PanelSkills = _panelHeroSkills.PanelSkills;
            
        }

    
    }
}
