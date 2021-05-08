using System.Collections.Generic;
using UnityEngine;

namespace Logic
{
    public interface IPanelPortraits
    {
        List<GameObject> List { get; }
        Transform Transform { get; }
    }
}