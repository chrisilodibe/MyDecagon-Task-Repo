using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeekOneTask
{
 
    public class LinkedList<T>
    {
        public Node head;
        public Node tail;
        private int size;
        public int Size { get { return size; } }
        public class Node
        {
            public T Data;
            public Node Next;
            public Node(T data)
            {
                this.Data = data;
            }
        }

        /*this method adds a newnode to the linked list 
         * by first checking if the linked list is empty 
         * if it is empty then the newnode is added to the head 
         * else the newnode will be added after the current tail 
         * and the tail is updated to the newnode resulting to increament in size*/
        public int Add(T item)
        {
            Node newNode = new Node(item);

            if (head == null)
            {
                head = newNode;
                tail = newNode;
            }
            else
            {
                tail.Next = newNode;
                tail = newNode;
            }
            size++;
            return size;
        }

        /*the remove methods returns a boolean after checking 
         * if a specified Node item is in the linked list and 
         * it is successfully remmoved. it performs required update on the linked list to ensure data is not lost */
        public bool Remove(T item)
        {
            Node current = head;
            Node previous = null;

            while(current != null)
            {
                if (current.Data.Equals(item))
                {
                    if (previous == null)
                    {
                        head = current.Next;
                        if (head == null)
                            tail = null;
                    }
                    else
                    {
                        previous.Next = current.Next;
                        if (current.Next == null)
                            tail = previous;
                    }
                    size--;
                    return true;
                }
                previous = current;
                current = current.Next;
            }
            return false;
            //if (head == null)
            //{
            //    return false;
            //}
            //if (head.Data.Equals(item))
            //{
            //    head = head.Next;
            //    size --;
            //    return true;    
            //}

            //Node TempNode = head;
            //while( TempNode != null )
            //{
            //    if(TempNode.Next.Data.Equals(item))
            //    {
            //        TempNode = TempNode.Next;
            //        size--;
            //        return true;
            //    }
            //    TempNode = TempNode.Next;
            //}
            //return false;

        }

        public bool Check(T item)
        {
            Node TempNode = head;
            while (TempNode != null)
            {
                if (TempNode.Data.Equals(item))
                {
                    return true;
                }
                TempNode = TempNode.Next;
            }
            return false;
        }

        public int Index(T item)
        {
            int index = 0;
            Node TempNode = head;
            while (TempNode != null)
            {
                if (TempNode.Data.Equals(item))
                {
                    return index;
                }
                index++;
                TempNode = TempNode.Next;
            }
            return -1;

        }

        
        
    }
}
