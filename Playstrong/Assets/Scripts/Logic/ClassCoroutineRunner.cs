using System.Collections;
using Interfaces;
using UnityEngine;

namespace Logic
{
    public class ClassCoroutineRunner : MonoBehaviour, IClassCoroutineRunner
    {
        private void Awake()
        {
            CoroutineQueue coroutineQueue = new CoroutineQueue();
            coroutineQueue.CoroutineRunner(this);
            CoroutineTree coroutineTree = new CoroutineTree();
            coroutineTree.CoroutineRunner(this);
        }

        public IEnumerator Wait(float seconds)
        {
            yield return new WaitForSeconds(seconds);
        }

       
    }
}
