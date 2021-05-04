using Interfaces;
using UnityEngine;
using Utilities;

namespace Visual
{
    public class LoadSkillAttributes : MonoBehaviour, ILoadSkillAttributes
    {
        [SerializeField]
        [RequireInterface(typeof(ISkillLogic))]
        private Object _skillLogic;
        public ISkillLogic SkillLogic => _skillLogic as ISkillLogic;

        public void LoadSkillAttributesFromAsset(IHeroSkillAsset skillAsset)
        {
            var skillAttributes = SkillLogic.SkillAttributes;
            
            skillAttributes.Cooldown = skillAsset.Cooldown;
            skillAttributes.BaseCooldown = skillAsset.Cooldown;
        }
        
        
    }
}
