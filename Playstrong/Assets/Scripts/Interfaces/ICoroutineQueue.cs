using System.Collections;
using UnityEngine;

namespace Interfaces
{
    public interface ICoroutineQueue
    {
        /// <summary>
        /// Whether the queue is empty, that is there is nothing queued and nothing is currently being executed.
        /// </summary>
        bool Empty { get; }

        void CoroutineRunner(MonoBehaviour mono);
        void AddToCorQ(IEnumerator coroutine);
        void PlayFirstCommandFromQueue();
        bool CoroutineCompleted();
    }
}