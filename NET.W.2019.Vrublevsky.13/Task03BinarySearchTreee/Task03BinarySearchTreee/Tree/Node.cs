using System;
using System.Collections.Generic;
using System.Text;

namespace Task03BinarySearchTreee.Tree
{
    /// <summary>
    /// Node of the Binary Search Tree.
    /// </summary>
    /// <typeparam name="T">Parameter type.</typeparam>
    public class Node<T>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Node{T}"/> class.
        /// </summary>
        /// <param name="element">Element.</param>
        public Node(T element)
        {
            this.Element = element;
            this.Left = null;
            this.Right = null;
        }

        /// <summary>
        /// Gets or sets element.
        /// </summary>
        /// <value>
        /// Element.
        /// </value>
        public T Element { get; set; }

        /// <summary>
        /// Gets or sets left <see cref="Node{T}"/>.
        /// </summary>
        /// <value>
        /// Left <see cref="Node{T}"/>.
        /// </value>
        public Node<T> Left { get; set; }

        /// <summary>
        /// Gets or sets right <see cref="Node{T}"/>.
        /// </summary>
        /// <value>
        /// Right <see cref="Node{T}"/>.
        /// </value>
        public Node<T> Right { get; set; }

    }
}
