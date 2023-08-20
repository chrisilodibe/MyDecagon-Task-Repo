using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeekOneTask
{
    public class Queue<T>
    {
        /*These declared fields are for the Node front and back 
        * and a size field to keep track of the number of element in the queue*/
        
        private readonly LinkedList<T> linkedList;
        public Queue()
        {
            linkedList = new LinkedList<T>();
        }

        public void Enqueue(T item)
        {
            linkedList.Add(item);
        }

        public bool  IsEmpty()
        {
            return linkedList.Size == 0;
        }
       
        public T Dequeue()
        {
            if(IsEmpty())
                Console.WriteLine("Invalid item");

            T item = linkedList.head.Data;
            linkedList.Remove(item);
            return item;
        }

        public int Size () 
        {
            return linkedList.Size;
        }


    }


}



