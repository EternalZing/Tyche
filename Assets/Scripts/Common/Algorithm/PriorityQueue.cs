using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//算法库
namespace Assets.Common.Algorithm {
    //用以辅助计时器系统的优先队列
   public class PriorityQueue<T> :IEnumerable<T> {
        IComparer<T> comparer;
        T[] heap;
        public int Count { get; private set; }
        public PriorityQueue() : this( null ) { }
        public PriorityQueue(int capacity) : this( capacity, null ) { }
        public PriorityQueue(IComparer<T> comparer) : this( 16, comparer ) { }

        /// <summary>
        /// 优先队列的构造函数
        /// </summary>
        /// <param name="capacity"> 代表优先队列的大小(会自动扩增) </param> 
        /// <param name="comparer"> 代表优先队列的比较器,根据此维护优先队列 </param> 
        public PriorityQueue(int capacity, IComparer<T> comparer) {
            this.comparer = (comparer == null) ? Comparer<T>.Default : comparer;
            this.heap = new T[capacity];
        }
        /// <summary>
        /// 添加一个新的元素给优先队列
        /// </summary>
        /// <param name="v"> 添加的元素</param>
        public void Push(T v) {
            if(Count >= heap.Length) Array.Resize( ref heap, Count * 2 );
            heap[Count] = v;
            SiftUp( Count++ );
        }
        /// <summary>
        /// 将优先队列的第一个元素返回并弹出
        /// </summary>
        /// <returns>弹出的元素</returns>
        public T Pop() {
            var v = Top();
            heap[0] = heap[--Count];
            if(Count > 0) SiftDown( 0 );
            return v;
        }
        /// <summary>
        /// 将优先队列的第一个元素返回
        /// </summary>
        /// <returns>该元素</returns>
        public T Top() {
            if(Count > 0) return heap[0];
            throw new InvalidOperationException( "优先队列为空" );
        }
        /// <summary>
        /// 维护优先队列的的性质,上移某一元素
        /// </summary>
        /// <param name="n">需要维护的元素</param>
        void SiftUp(int n) {
            var v = heap[n];
            for(var n2 = n / 2; n > 0 && comparer.Compare( v, heap[n2] ) > 0; n = n2, n2 /= 2) heap[n] = heap[n2];
            heap[n] = v;
        }
        /// <summary>
        /// 维护优先队列的性质,下移某一元素
        /// </summary>
        /// <param name="n">需要维护的元素</param>
        void SiftDown(int n) {

            var v = heap[n];
            for(var n2 = n * 2; n2 < Count; n = n2, n2 *= 2) {
                if(n2 + 1 < Count && comparer.Compare( heap[n2 + 1], heap[n2] ) > 0) n2++;
                if(comparer.Compare( v, heap[n2] ) >= 0) break;
                heap[n] = heap[n2];
            }
            heap[n] = v;
        }

        /// <summary>
        /// 枚举器
        /// </summary>
        /// <returns></returns>
       IEnumerator IEnumerable.GetEnumerator() {
           return GetEnumerator();
       }
        /// <summary>
        /// 枚举器
        /// </summary>
        /// <returns></returns>
       public IEnumerator<T> GetEnumerator() {
           return new PriorityQueue<T>.HeapEnumerator<T>(this);
       }
        /// <summary>
        /// 定义的内部枚举器类
        /// </summary>
        /// <typeparam name="T"></typeparam>
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