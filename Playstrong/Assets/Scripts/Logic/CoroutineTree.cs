﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Logic
{
    /// <summary>
    /// COROUTINE TREE CLASS
    /// A tree of coroutines with depth-first order of execution.
    /// I.e. node -> children -> siblings.
    /// </summary>

    public class CoroutineTree
    {
        /// <summary>
        /// Artificial root node.
        /// Does not contain an actual coroutine.
        /// Main parent or origin point for the family of coroutines
        /// </summary>
        public CoroutineNode Root { get; private set; }

        public static CoroutineTree logicTree = new CoroutineTree();

        private MonoBehaviour mono; 
        
        /// <summary>
        /// Node which is currently being executed.
        /// Points to Root when the tree is empty.
        /// </summary>
        public CoroutineNode CurrentNode { get; private set; }

        public CoroutineQueue CorQ = new CoroutineQueue();

        public CoroutineTree()
        {
            Root = new CoroutineNode(null);
            CurrentNode = Root;
        
        }
        
        public void CoroutineRunner(MonoBehaviour mono)
        {
            this.mono = mono;
        }
        
    

        /// <summary>
        /// Start processing of the tree.
        /// Called during the Ctor initialization "new CoroutineTree"
        /// </summary>
        public void Start()
        {
            GlobalSettings.Instance.StartCoroutine(UpdateTree());
        }

    




        /// <summary>
        /// Add a coroutine as child of the current node.
        /// Currnet node is the node being processed
        /// </summary>
        /// <param name="value">Coroutine to add.</param>
        public void AddCurrent(IEnumerator value)
        {
            CurrentNode.AddChild(value);
        }

        /// <summary>
        /// Add a coroutine as a child of the root node.
        /// </summary>
        /// <param name="value">Coroutine to add.</param>
        public void AddRoot(IEnumerator value)
        {
            Root.AddChild(value);
        }

        /// <summary>
        /// Add a coroutine as a child of the current node which waits for specified amount of time.
        /// </summary>
        /// <param name="seconds"></param>
        public void AddCurrentWait(float seconds)
        {        
            CurrentNode.AddChild(GlobalSettings.Instance.Wait(seconds));
        }

        /// <summary>
        /// Add a coroutine as a child of the root node which waits for specified amount of time.
        /// </summary>
        /// <param name="seconds"></param>
        public void AddRootWait(float seconds)
        {
            Root.AddChild(GlobalSettings.Instance.Wait(seconds));
        }
     
        /// <summary>
        /// Returns true if the tree is empty, false otherwise.
        /// </summary>
        public bool Empty
        {
            get { return Root == CurrentNode && Root.ChildrenCount <= 0; }
        }


        /// <summary>
        /// Coroutine that start the nodes sequentially under the root
        /// Has a recursive function to process nodes under the current node before proceeding with the other nodes
        /// Priority:  Node -> Childre of the Node -> Siblings of the node
        /// Note that Coroutines get started without waiting for the others to finish
        /// This needs to be modified <ToDo> "queue" processing of coroutines
        /// </summary>
        private IEnumerator ProcessChildrenOfNode(CoroutineNode node)
        {
            int i = 0;
            while(i < node.ChildrenCount)
            {
                // Node -> children -> siblings.
                CurrentNode = node[i];

                //yield return GlobalSettings.Instance.StartCoroutine(node[i].Value);

                //new CTCommandLogic(node[i].Value).AddToQueue();

                CorQ.AddToCorQ(node[i].Value);

                yield return null;

                if (i >= node.ChildrenCount) yield break;

                if(node[i].ChildrenCount > 0)
                {
                    // Recursion on children.
                    yield return GlobalSettings.Instance.StartCoroutine(ProcessChildrenOfNode(node[i]));

                
                }                

                i++;
            }

            // Be defensive about clearing, do it only when everything was executed.
            if (node == Root)
            {
                CurrentNode = Root;
                Root.ClearChildren();
            }
        }

        /// <summary>
        /// Starts processing coroutines in the tree
        /// note that once started, this goes on continously
        /// </summary>
        private IEnumerator UpdateTree()
        {
            while (true)
            {
                if(CurrentNode == Root && Root.ChildrenCount > 0)
                {
                    yield return GlobalSettings.Instance.StartCoroutine(ProcessChildrenOfNode(Root));
                }
                else
                {
                    yield return null;
                }
            }
        }

        /// <summary>
        /// Removes all pending coroutines.
        /// </summary>
        public void CleanUp()
        {
            CurrentNode = Root;
            Root.ClearChildren();
        }


        /// <summary>
        /// Data structure representing one coroutine as a node of a tree
        /// Class used in CoroutineTree
        /// <summary>

        public class CoroutineNode
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
            public CoroutineNode this[int i]
            {
                get { return _children[i]; }
            }

            /// <summary>
            /// Parent node.
            /// Is null for root of a tree.
            /// </summary>
            public CoroutineNode Parent { get; private set; }

            /// <summary>
            /// Number of children this node has.
            /// </summary>
            public int ChildrenCount
            {
                get { return _children.Count; }
            }


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

            /// <summary>
            /// Remove all children of this node.
            /// </summary>
            public void ClearChildren()
            {
                _children.Clear();
            }

        }  /// <summary> End of CoroutineNode class </summary>




    }
}




