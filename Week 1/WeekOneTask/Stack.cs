using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeekOneTask
{
    public class Stack<T>
    {
        private readonly LinkedList<T> linkedList;

        public Stack()
        {
            linkedList = new LinkedList<T>();
        }

        public bool IsEmpty()
        {
            return linkedList.Size == 0;
        }
        public void Push(T item)
        {
            linkedList.Add(item);
        }

        public T Pop()
        {
            if(IsEmpty())
                Console.WriteLine("invalid item");

            T item = linkedList.tail.Data;
            linkedList.Remove(item);
            return item;
        }

        public T Peek()
        {
            if (IsEmpty())
                Console.WriteLine("Invalid item");
            return linkedList.tail.Data;
        }

        public int Size()
        {
            return linkedList.Size;
        }
      
    }
}
