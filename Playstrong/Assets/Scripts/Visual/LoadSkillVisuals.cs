using Interfaces;
using UnityEngine;
using Utilities;

namespace Visual
{
    public class LoadSkillVisuals : MonoBehaviour, ILoadSkillVisuals
    {
        [SerializeField]
        [RequireInterface(typeof(ISkillVisual))]
        private Object _skillVisual;
        public ISkillVisual SkillVisual => _skillVisual as ISkillVisual;


        public void LoadSkillVisualsFromSkillAsset(IHeroSkillAsset heroSkillAsset)
        {
            var skillAttributes = SkillVisual.SkillPrefab.SkillLogic.SkillAttributes;
            
            SkillVisual.SkillGraphic.sprite = heroSkillAsset.SkillIcon;
            SkillVisual.CooldownText.text = skillAttributes.Cooldown.ToString();
        }
    }
}
