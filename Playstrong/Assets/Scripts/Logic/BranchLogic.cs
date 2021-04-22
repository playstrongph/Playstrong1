using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BranchLogic : MonoBehaviour, IBranchLogic
{
    public IEnumerator Wait(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        yield return null;

    }
}
