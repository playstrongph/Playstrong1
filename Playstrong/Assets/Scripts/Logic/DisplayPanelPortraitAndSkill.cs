using UnityEngine;
using Visual;

namespace Logic
{
    public class DisplayPanelPortraitAndSkill : MonoBehaviour
    {
        private ITargetHeroPreview _targetHeroPreview;
        private IPanelHeroPortrait _panelHeroPortrait;
        private IPanelHeroSkills _panelHeroSkills;

      
        private void Awake()
        {
            _targetHeroPreview = GetComponent<ITargetHeroPreview>();
        }

        public void OnMouseDown()
        {
            _targetHeroPreview.Hero.LivingHeroesReference.PanelPortaitAndSkillDisplay.PanelPortrait.SetActive(false);
            _targetHeroPreview.Hero.LivingHeroesReference.PanelPortaitAndSkillDisplay.PanelSkills.SetActive(false);

            _panelHeroPortrait = _targetHeroPreview.Hero.PanelHeroPortrait;
            _panelHeroSkills = _targetHeroPreview.Hero.PanelHeroSkills;
        
            _panelHeroPortrait.Portrait.SetActive(true);
            _panelHeroSkills.PanelSkills.SetActive(true);
            
            _targetHeroPreview.Hero.LivingHeroesReference.PanelPortaitAndSkillDisplay.PanelPortrait = _panelHeroPortrait.Portrait;
            _targetHeroPreview.Hero.LivingHeroesReference.PanelPortaitAndSkillDisplay.PanelSkills = _panelHeroSkills.PanelSkills;
            
        }

    
    }
}
