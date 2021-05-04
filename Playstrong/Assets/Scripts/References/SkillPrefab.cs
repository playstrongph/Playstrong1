using System;
using Interfaces;
using Logic;
using UnityEngine;
using Utilities;
using Visual;
using Object = UnityEngine.Object;


namespace References
{
    public class SkillPrefab : MonoBehaviour, ISkillPrefab
    {

        [SerializeField] [RequireInterface(typeof(ISkillLogic))]
        private Object _skillLogic;
        public ISkillLogic SkillLogic => _skillLogic as ISkillLogic;
        
        [SerializeField] [RequireInterface(typeof(ISkillVisualReferences))]
        private Object _skillVisualReferences;
        public ISkillVisualReferences SkillVisualReferences => _skillVisualReferences as ISkillVisualReferences;
        
        [SerializeField] [RequireInterface(typeof(ISkillPreviewVisual))]
        private Object _skillPreviewVisual;
        public ISkillPreviewVisual SkillPreviewVisual => _skillPreviewVisual as ISkillPreviewVisual;
        
       
        
    }
}
