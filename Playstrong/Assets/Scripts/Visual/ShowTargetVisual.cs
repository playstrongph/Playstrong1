using UnityEngine;
using Utilities;

namespace Visual
{
    public class ShowTargetVisual : MonoBehaviour
    {
        [SerializeField] [RequireInterface(typeof(ITargetVisualReferences))]
        private Object _targetVisualReferences;
        public ITargetVisualReferences TargetVisualReferences => _targetVisualReferences as ITargetVisualReferences;
    }
}
