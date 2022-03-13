using System.Collections.Generic;

namespace TicTacToe2
{
    public class LoopList<T> : Queue<T>
    {
        public T LoopQueue()
        {
            T element = Dequeue();
            Enqueue(element);
            return element;
        }
    }
}