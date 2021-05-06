using System.Collections.Generic;
using UnityEngine;

namespace Interfaces
{
    public interface IObjectList
    {
        List<GameObject> ThisList { get; }
        Transform Transform { get; }


    }
}