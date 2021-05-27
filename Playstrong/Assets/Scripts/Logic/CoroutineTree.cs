using System.Collections;
using System.Collections.Generic;
using Interfaces;
using UnityEngine;

namespace Logic
{
    /// <summary>
    /// COROUTINE TREE CLASS
    /// A tree of coroutines with depth-first order of execution.
    /// I.e. node -> children -> siblings.
    /// </summary>

    public class CoroutineTree : ICoroutineTree
    {
        /// <summary>
        /// Artificial root node.
        /// Does not contain an actual coroutine.
        /// Main parent or origin point for the family of coroutines
        /// </summary>
        public ICoroutineNode Root { get; private set; }

        /// <summary>
        /// Use to start coroutines
        /// and Wait function
        /// </summary>
        private MonoBehaviour mono; 
        
        /// <summary>
        /// Node which is currently being executed.
        /// Points to Root when the tree is empty.
        /// </summary>
        public ICoroutineNode CurrentNode { get; private set; }

        //private ICoroutineQueue CorQ => new CoroutineQueue();
        private ICoroutineQueue CorQ;

        

        public void EndSequence()
        {
            CorQ.CoroutineCompleted();
        }


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
            CorQ = new CoroutineQueue();
            CorQ.CoroutineRunner(mono);
            mono.StartCoroutine(UpdateTree());
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
        public void AddCurrentWait(float seconds, ICoroutineTree tree)
        {        
            CurrentNode.AddChild(mono.GetComponent<IBranchLogic>().Wait(seconds,tree));
        }

        /// <summary>
        /// Add a coroutine as a child of the root node which waits for specified amount of time.
        /// </summary>
        /// <param name="seconds"></param>
        public void AddRootWait(float seconds, ICoroutineTree tree)
        {
            Root.AddChild(mono.GetComponent<IBranchLogic>().Wait(seconds,tree));
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
        private IEnumerator ProcessChildrenOfNode(ICoroutineNode node)
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
                    yield return mono.StartCoroutine(ProcessChildrenOfNode(node[i]));

                
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
                    yield return mono.StartCoroutine(ProcessChildrenOfNode(Root));
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


        




    }
}




