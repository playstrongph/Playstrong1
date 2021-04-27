using UnityEngine;

namespace Visual
{
    public interface IDraggable
    {
        void SetDsiplacement(float zDisplacement, Vector3 pointerDisplacement);
        void EnableDraggable();

        void DisableDraggable();

    }
}