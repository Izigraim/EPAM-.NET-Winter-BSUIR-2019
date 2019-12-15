using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Task01GenericQueue
{
    /// <summary>
    /// Generic Queue.
    /// </summary>
    /// <typeparam name="T">Type.</typeparam>
    public class Queue<T> : IEnumerable
    {
        private T[] array;
        private int head;

        /// <summary>
        /// Initializes a new instance of the <see cref="Queue{T}"/> class.
        /// </summary>
        public Queue()
        {
            this.array = new T[5];
            this.Count = 0;
            this.head = 0;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Queue{T}"/> class.
        /// </summary>
        /// <param name="size">Size.</param>
        public Queue(int size)
        {
            if (size < 0)
            {
                throw new ArgumentOutOfRangeException($"{nameof(size)} can't be less then 0.");
            }

            this.array = new T[size];
            this.Count = 0;
            this.head = 0;
        }

        /// <summary>
        /// Gets count.
        /// </summary>
        /// <value>
        /// Count.
        /// </value>
        public int Count { get; private set; }

        /// <summary>
        /// Add element to queue.
        /// </summary>
        /// <param name="value">Element.</param>
        public void Enqueue(T value)
        {
            if (this.Count == this.array.Length)
            {
                Array.Resize(ref this.array, this.array.Length * 2);
            }

            T[] newArray = new T[this.array.Length];
            newArray[0] = value;

            for (int i = 0; i < this.Count; i++)
            {
                newArray[i + 1] = this.array[i];
            }

            this.array = newArray;
            this.head = this.Count;
            this.Count++;
        }

        /// <summary>
        /// Remove element from queue which was added firstly.
        /// </summary>
        /// <returns>Element.</returns>
        public T Dequeue()
        {
            if (this.Count == 0)
            {
                throw new InvalidOperationException("Queue is empty.");
            }

            T value = this.array[this.head];
            this.array[this.head] = default(T);
            this.head--;
            this.Count--;
            return value;
        }

        /// <summary>
        /// Show last added element.
        /// </summary>
        /// <returns>Element.</returns>
        public T Peek()
        {
            if (this.Count == 0)
            {
                throw new InvalidOperationException("Queue is empty.");
            }

            return this.array[this.head];
        }

        /// <summary>
        /// Get enumerator that iterates through a queue.
        /// </summary>
        /// <returns>An <see cref="IEnumerator{T}"/> object that can be used to iterate through queue.</returns>
        public IEnumerator GetEnumerator()
        {
            return new QueueEnumerator<T>(this);
        }

        /// <summary>
        /// Enumerator class.
        /// </summary>
        /// <typeparam name="T">Type.</typeparam>
        public class QueueEnumerator<T> : IEnumerator
        {
            private Queue<T> queue;
            private int currentIndex;
            private int head;

            public QueueEnumerator(Queue<T> queue)
            {
                this.currentIndex = -1;
                this.queue = queue ?? throw new ArgumentNullException(nameof(queue));
                this.head = queue.head;
            }

            public object Current
            {
                get
                {
                    if (this.currentIndex == -1 || this.currentIndex == this.queue.Count)
                    {
                        throw new InvalidOperationException();
                    }

                    return this.queue.array[this.currentIndex];
                }
            }

            public bool MoveNext()
            {
                if (this.currentIndex < this.queue.Count - 1)
                {
                    this.currentIndex++;
                    return true;
                }
                else
                {
                    return false;
                }

            }

            public void Reset()
            {
                this.currentIndex = -1;
            }
        }
    }
}
