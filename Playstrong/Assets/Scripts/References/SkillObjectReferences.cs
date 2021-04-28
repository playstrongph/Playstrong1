using System;
using Interfaces;
using Logic;
using UnityEngine;
using Utilities;
using Visual;
using Object = UnityEngine.Object;


namespace References
{
    public class SkillObjectReferences : MonoBehaviour, ISkillObjectReferences
    {

        [SerializeField] [RequireInterface(typeof(ISkillLogicReferences))]
        private Object _skillLogicReferences;
        public ISkillLogicReferences SkillLogicReferences => _skillLogicReferences as ISkillLogicReferences;
        
        [SerializeField] [RequireInterface(typeof(ISkillVisualReferences))]
        private Object _skillVisualReferences;
        public ISkillVisualReferences SkillVisualReferences => _skillVisualReferences as ISkillVisualReferences;
        
        [SerializeField] [RequireInterface(typeof(ISkillPreviewVisual))]
        private Object _skillPreviewVisual;
        public ISkillPreviewVisual HeroPreviewVisual => _skillPreviewVisual as ISkillPreviewVisual;
        
       
        
    }
}
