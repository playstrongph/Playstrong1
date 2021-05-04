using Interfaces;
using UnityEngine;

namespace Visual
{
    public class LoadSkillVisuals : MonoBehaviour, ILoadSkillVisuals
    {
        private ISkillVisual _skillVisual;
        private ISkillAttributes _skillAttributes;

        private void Awake()
        {
            _skillVisual = GetComponent<ISkillVisual>();
            _skillAttributes = _skillVisual.SkillPrefab.SkillLogic.SkillAttributes;
        }

        public void LoadSkillVisualsFromSkillAsset(IHeroSkillAsset heroSkillAsset)
        {
            _skillVisual.SkillGraphic.sprite = heroSkillAsset.SkillIcon;
            _skillVisual.CooldownText.text = _skillAttributes.Cooldown.ToString();
        }
    }
}
