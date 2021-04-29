using Interfaces;
using UnityEngine;

namespace Visual
{
    public class LoadSkillAttributes : MonoBehaviour, ILoadSkillAttributes
    {
        private ISkillLogicReferences _skillLogicReferences;
        private ISkillAttributes _skillAttributes;

        private void Awake()
        {
            _skillLogicReferences = GetComponent<ISkillLogicReferences>();
            _skillAttributes = _skillLogicReferences.SkillAttributes;
        
        }

        public void LoadSkillAttributesFromAsset(IHeroSkillAsset skillAsset)
        {
            _skillAttributes.Cooldown = skillAsset.Cooldown;
            _skillAttributes.BaseCooldown = skillAsset.Cooldown;
        }
        
        
    }
}
