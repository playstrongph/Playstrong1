using System.Collections;
using UnityEngine;

namespace Interfaces
{
    public interface ICoroutineTree
    {
        /// <summary>
        /// Artificial root node.
        /// Does not contain an actual coroutine.
        /// Main parent or origin point for the family of coroutines
        /// </summary>
        ICoroutineNode Root { get; }
        

        /// <summary>
        /// Node which is currently being executed.
        /// Points to Root when the tree is empty.
        /// </summary>
        ICoroutineNode CurrentNode { get; }
        

        /// <summary>
        /// Returns true if the tree is empty, false otherwise.
        /// </summary>
        bool Empty { get; }

        void CoroutineRunner(MonoBehaviour mono);

        /// <summary>
        /// Start processing of the tree.
        /// Called during the Ctor initialization "new CoroutineTree"
        /// </summary>
        void Start();

        /// <summary>
        /// Add a coroutine as child of the current node.
        /// Currnet node is the node being processed
        /// </summary>
        /// <param name="value">Coroutine to add.</param>
        void AddCurrent(IEnumerator value);

        /// <summary>
        /// Add a coroutine as a child of the root node.
        /// </summary>
        /// <param name="value">Coroutine to add.</param>
        void AddRoot(IEnumerator value);

        /// <summary>
        /// Add a coroutine as a child of the current node which waits for specified amount of time.
        /// </summary>
        /// <param name="seconds"></param>
        void AddCurrentWait(float seconds);

        /// <summary>
        /// Add a coroutine as a child of the root node which waits for specified amount of time.
        /// </summary>
        /// <param name="seconds"></param>
        void AddRootWait(float seconds);

        /// <summary>
        /// Removes all pending coroutines.
        /// </summary>
        void CleanUp();
    }
}