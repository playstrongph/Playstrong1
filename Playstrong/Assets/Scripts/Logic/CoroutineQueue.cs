using System.Collections;
using System.Collections.Generic;
using Interfaces;
using UnityEngine;

namespace Logic
{
    public class CoroutineQueue : ICoroutineQueue
    {
    
        private Queue<IEnumerator> _queue;

        /// <summary>
        /// Whether the queue is empty, that is there is nothing queued and nothing is currently being executed.
        /// </summary>
        public bool Empty { get; private set; }


        private MonoBehaviour _mono;


        bool _playingQueue = false;

        /// <summary>
        /// Ctor for the queue.
        /// </summary>
        public CoroutineQueue()
        {
            _queue = new Queue<IEnumerator>();
            Empty = true;         
            

        }

        public void CoroutineRunner(MonoBehaviour mono)
        {
            this._mono = mono;
        }

        public void AddToCorQ(IEnumerator coroutine)
        {
            _queue.Enqueue(coroutine);
        
            if (!_playingQueue)
                PlayFirstCommandFromQueue();

        }

        public void PlayFirstCommandFromQueue()
        {
        
            _playingQueue = true;             
            _mono.StartCoroutine(_queue.Dequeue());       
       
        }

        public bool CoroutineCompleted()
        {
            if(_queue.Count > 0)
            {
                PlayFirstCommandFromQueue();
            }else
            {
                _playingQueue = false;
            }

            return true;
        }


    

    }
}