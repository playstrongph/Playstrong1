using Interfaces;
using UnityEngine;

namespace Visual
{
   public class SkillCooldownVisual : MonoBehaviour, ISkillCooldownVisual
   {
      private ISkillVisual _skillVisual;

      private void Awake()
      {
         _skillVisual = GetComponent<ISkillVisual>();
      
      }

      public void UpdateCooldown(int value)
      {
         var cooldownText = _skillVisual.CooldownText;

         cooldownText.text = value.ToString();
         
         UpdatePanelSkillCooldownText(value);
      }

      private void UpdatePanelSkillCooldownText(int value)
      {
         var panelSkill = _skillVisual.Skill.PanelSkill;
         var cooldownText = panelSkill.SkillVisual.CooldownText;
         
         cooldownText.text = value.ToString();
      }



   }
}
