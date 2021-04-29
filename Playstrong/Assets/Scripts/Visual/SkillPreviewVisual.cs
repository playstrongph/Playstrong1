using Interfaces;
using References;
using UnityEngine;
using Utilities;

namespace Visual
{
    public class SkillPreviewVisual : MonoBehaviour, ISkillPreviewVisual
    {

        [SerializeField] [RequireInterface(typeof(ISkillObjectReferences))]
        private Object _skillObjectReferences;
        public ISkillObjectReferences SkillObjectReferences => _skillObjectReferences as ISkillObjectReferences;

        [SerializeField] private Canvas _previewCanvas;
        public Canvas PreviewCanvas => _previewCanvas;
        
        


    }
}
