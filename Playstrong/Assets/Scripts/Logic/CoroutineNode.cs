using System.Collections;
using System.Collections.Generic;
using Interfaces;

namespace Logic
{
    /// <summary>
    /// Data structure representing one coroutine as a node of a tree
    /// Class used in CoroutineTree
    /// <summary>

    public class CoroutineNode : ICoroutineNode
    {
    
        /// <summary>
        /// List of children nodes.
        /// </summary>
        private readonly List<CoroutineNode> _children = new List<CoroutineNode>(); 

        /// <summary>
        /// Actual coroutine.
        /// </summary>
        public IEnumerator Value { get; private set; }

        public CoroutineNode(IEnumerator value)
        {
            Value = value;
        } 

        /// <summary>
        /// Accessor for a children node.
        /// Does not check for index validity.
        /// </summary>
        /// <param name="i">Index of wanted child.</param>
        /// <returns></returns>
        public CoroutineNode this[int i] => _children[i];

        /// <summary>
        /// Parent node.
        /// Is null for root of a tree.
        /// </summary>
        public CoroutineNode Parent { get; private set; }

        /// <summary>
        /// Number of children this node has.
        /// </summary>
        public int ChildrenCount => _children.Count;


        /// <summary>
        /// Add a coroutine as a child of the node.
        /// </summary>
        /// <param name="coroutine">Coroutine to add.</param>
        /// <returns></returns>
        public CoroutineNode AddChild(IEnumerator coroutine)
        {
            var node = new CoroutineNode(coroutine) { Parent = this };
            _children.Add(node);
            return node;
        }
        
        //TEST
        public CoroutineNode AddChildAtStart(IEnumerator coroutine)
        {
            var node = new CoroutineNode(coroutine) { Parent = this };
            
            //_children.Add(node);
            
            _children.Insert(0,node);
            
            return node;
        }

        /// <summary>
        /// Remove all children of this node.
        /// </summary>
        public void ClearChildren()
        {
            _children.Clear();
        }

    }
}  
