using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Task03BinarySearchTreee.Tree
{
    /// <summary>
    /// Generic Binaty Search Tree.
    /// </summary>
    /// <typeparam name="T">Parameter type.</typeparam>
    public class BinarySearchTree<T> : IEnumerable<T>
    {
        private Node<T> node;
        private IComparer<T> comparer;

        /// <summary>
        /// Initializes a new instance of the <see cref="BinarySearchTree{T}"/> class.
        /// </summary>
        public BinarySearchTree()
        {
            this.node = null;
            this.Count = 0;
            this.comparer = Comparer<T>.Default;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BinarySearchTree{T}"/> class.
        /// </summary>
        /// <param name="comparer">IComparer.</param>
        public BinarySearchTree(IComparer<T> comparer)
            : this()
        {
            this.comparer = comparer;
        }

        /// <summary>
        /// Gets or sets Count of elements in Tree.
        /// </summary>
        /// <value>
        /// Count of elements in Tree.
        /// </value>
        public int Count { get; set; }

        /// <summary>
        /// Add element to Binary Search Tree.
        /// </summary>
        /// <param name="element">Element to add.</param>
        public void Add(T element)
        {
            if (this.node == null)
            {
                this.node = new Node<T>(element);
                this.Count++;
                return;
            }

            this.Add(element, this.node);
        }

        /// <summary>
        /// Remove element from Binary Search Tree.
        /// </summary>
        /// <param name="element">Element.</param>
        public void Remove(T element)
        {
            if (this.node == null)
            {
                return;
            }

            this.Remove(element, this.node);
        }

        /// <summary>
        /// InOrder traversal.
        /// </summary>
        /// <returns>IEnumerable.</returns>
        public IEnumerable<T> InOrder()
        {
            if (this.node == null)
            {
                throw new InvalidOperationException("Tree is empty.");
            }

            return this.InOrder(this.node);
        }

        /// <summary>
        /// PostOrder traversal.
        /// </summary>
        /// <returns>IEnumerable.</returns>
        public IEnumerable<T> PostOrder()
        {
            if (this.node == null)
            {
                throw new InvalidOperationException("Tree is empty.");
            }

            return this.PostOrder(this.node);
        }

        /// <summary>
        /// PreOrder traversal.
        /// </summary>
        /// <returns>IEnumerable.</returns>
        public IEnumerable<T> PreOrder()
        {
            if (this.node == null)
            {
                throw new InvalidOperationException("Tree is empty.");
            }

            return this.PreOrder(this.node);
        }

        private void Add(T element, Node<T> node)
        {
            if (this.comparer.Compare(node.Element, element) > 0)
            {
                if (node.Left == null)
                {
                    node.Left = new Node<T>(element);
                    this.Count++;
                }
                else
                {
                    this.Add(element, node.Left);
                }
            }

            if (this.comparer.Compare(node.Element, element) <= 0)
            {
                if (node.Right == null)
                {
                    node.Right = new Node<T>(element);
                    this.Count++;
                }
                else
                {
                    this.Add(element, node.Right);
                }
            }
        }

        private void Remove(T element, Node<T> node)
        { 
            if (this.comparer.Compare(node.Element, element) > 0)
            {
                this.Remove(element, node.Left);
            }

            if (this.comparer.Compare(node.Element, element) < 0)
            {
                this.Remove(element, node.Right);
            }

            if (this.comparer.Compare(node.Element, element) == 0)
            {
                if (node.Left == null && node.Right == null)
                {
                    node = null;
                    return;
                }

                if (node.Left == null)
                {
                    node = node.Right;
                    node.Right = null;
                    this.Count--;
                    return;
                }

                if (node.Right == null)
                {
                    node = node.Left;
                    node.Left = null;
                    this.Count--;
                    return;
                }

                if (node.Right.Left == null)
                {
                    node = node.Right;
                    node.Right = null;
                    this.Count--;
                    return;
                }
                else
                {
                    Node<T> left = this.FindLeft(node.Right);
                    node.Element = left.Element;
                    this.Remove(left.Element);
                }
            }
        }

        private Node<T> FindLeft(Node<T> node)
        {
            if (node.Left != null)
            {
                this.FindLeft(node.Left);
            }

            return node;
        }

        private IEnumerable<T> InOrder(Node<T> node)
        {
            if (node.Left != null)
            {
                foreach (var elem in this.InOrder(node.Left))
                {
                    yield return elem;
                }
            }

            yield return node.Element;

            if (node.Right != null)
            {
                foreach (var elem in this.InOrder(node.Right))
                {
                    yield return elem;
                }
            }
        }

        private IEnumerable<T> PostOrder(Node<T> node)
        {
            if (node.Left != null)
            {
                foreach (var elem in this.PostOrder(node.Left))
                {
                    yield return elem;
                }
            }

            if (node.Right != null)
            {
                foreach (var elem in this.PostOrder(node.Right))
                {
                    yield return elem;
                }
            }

            yield return node.Element;
        }

        private IEnumerable<T> PreOrder(Node<T> node)
        {
            yield return node.Element;

            if (node.Left != null)
            {
                foreach (var elem in this.PreOrder(node.Left))
                {
                    yield return elem;
                }
            }

            if (node.Right != null)
            {
                foreach (var elem in this.PreOrder(node.Right))
                {
                    yield return elem;
                }
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            return this.InOrder().GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.InOrder().GetEnumerator();
        }
    }
}
