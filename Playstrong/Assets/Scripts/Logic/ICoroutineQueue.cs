using System.Collections;
using UnityEngine;

namespace Logic
{
    public interface ICoroutineQueue
    {
        void CoroutineRunner(MonoBehaviour mono);
        void AddToCorQ(IEnumerator coroutine);
        void PlayFirstCommandFromQueue();
        bool CoroutineCompleted();
    }
}