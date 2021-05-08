using System.Collections.Generic;
using UnityEngine;

namespace Logic
{
    public interface IPanelSkills
    {
        List<GameObject> List { get; }
        Transform Transform { get; }
    }
}