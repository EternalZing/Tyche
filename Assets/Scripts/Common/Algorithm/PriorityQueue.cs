using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Assets.Common.Algorithm {
   public class PriorityQueue<T> :IEnumerable<T> {
        IComparer<T> comparer;
        T[] heap;
        public int Count { get; private set; }
        public PriorityQueue() : this( null ) { }
        public PriorityQueue(int capacity) : this( capacity, null ) { }
        public PriorityQueue(IComparer<T> comparer) : this( 16, comparer ) { }
       
        public PriorityQueue(int capacity, IComparer<T> comparer) {
            this.comparer = (comparer == null) ? Comparer<T>.Default : comparer;
            this.heap = new T[capacity];
        }
        public void Push(T v) {
            if(Count >= heap.Length) Array.Resize( ref heap, Count * 2 );
            heap[Count] = v;
            SiftUp( Count++ );
        }

        public T Pop() {
            var v = Top();
            heap[0] = heap[--Count];
            if(Count > 0) SiftDown( 0 );
            return v;
        }

        public T Top() {
            if(Count > 0) return heap[0];
            throw new InvalidOperationException( "优先队列为空" );
        }

        void SiftUp(int n) {
            var v = heap[n];
            for(var n2 = n / 2; n > 0 && comparer.Compare( v, heap[n2] ) > 0; n = n2, n2 /= 2) heap[n] = heap[n2];
            heap[n] = v;
        }

        void SiftDown(int n) {

            var v = heap[n];
            for(var n2 = n * 2; n2 < Count; n = n2, n2 *= 2) {
                if(n2 + 1 < Count && comparer.Compare( heap[n2 + 1], heap[n2] ) > 0) n2++;
                if(comparer.Compare( v, heap[n2] ) >= 0) break;
                heap[n] = heap[n2];
            }
            heap[n] = v;
        }

       IEnumerator IEnumerable.GetEnumerator() {
           return GetEnumerator();
       }

       public IEnumerator<T> GetEnumerator() {
           return new PriorityQueue<T>.HeapEnumerator<T>(this);
       }

       private class HeapEnumerator<T> :IEnumerator<T> {
           private PriorityQueue<T> priorityQueue;
           private int position = -1;
           public HeapEnumerator(PriorityQueue<T> priorityQueue) {
               this.priorityQueue = priorityQueue;
           }

           public bool MoveNext() {
               
                if(position < priorityQueue.Count-1) {
                    position++;
                    return true;
                }
                    return false;
            }

           public void Reset() {
                position = -1;
            }

           public T Current {
                
               get {
                  return priorityQueue.heap[position];
                }
         
           }

           object IEnumerator.Current {
               get { return Current; }
           }

           public void Dispose() {
           }
       }
   }
}