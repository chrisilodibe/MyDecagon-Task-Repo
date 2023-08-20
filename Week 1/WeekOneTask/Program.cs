using System;
using System.Collections.Generic;

namespace WeekOneTask
{

    public class Program
    {
        static void Main(string[] args)
        {

            LinkedList<int> linkedList = new LinkedList<int>();
            linkedList.Add(1);
            linkedList.Add(2);
            linkedList.Add(3);
            linkedList.Add(4);

            Console.WriteLine("Adding to Linked List \n");
            Console.WriteLine($"List Size:   {linkedList.Add(5)}");
            Console.WriteLine($"List Size:   {linkedList.Add(6)}\n");

            Console.WriteLine("Removing from Linked List \n");
            Console.WriteLine($"Removed:   {linkedList.Remove(3)}");
            Console.WriteLine($"Removed:   {linkedList.Remove(4)}\n");

            Console.WriteLine("Checking for item in Linked List \n");
            Console.WriteLine($"Checked:   {linkedList.Check(6)}");
            Console.WriteLine($"Checked:   {linkedList.Check(7)}\n");

            Console.WriteLine("Finding the Index of item in Linked List \n");
            Console.WriteLine($"Index:   {linkedList.Index(2)}");
            Console.WriteLine($"Index:   {linkedList.Index(9)}\n\n");



            Stack<int> stack = new Stack<int>();
            Console.WriteLine("STACK\n");

            Console.WriteLine($"Is an Empty Stack: {stack.IsEmpty()}\n");

            stack.Push(8);
            stack.Push(9);
            stack.Push(10);
            stack.Push(11);

            Console.WriteLine("STACK METHOD TEST\n");
            Console.WriteLine($"Is an Empty Stack: {stack.IsEmpty()}\n");
            Console.WriteLine($"Stack Size:   {stack.Size()}\n");
            Console.WriteLine($"stack last added item:   {stack.Peek()}\n");
            Console.WriteLine($"stack removed last item:   {stack.Pop()}\n");
            Console.WriteLine($"Stack Size:   {stack.Size()}\n");




            Queue<int> queue = new Queue<int>();
            Console.WriteLine("QUEUE\n");

            Console.WriteLine($"is an Empty Queue: {queue.IsEmpty()}\n");

            queue.Enqueue(15);
            queue.Enqueue(16);
            queue.Enqueue(17);
            queue.Enqueue(18);

            Console.WriteLine("QUEUE METHOD TEST\n");
            Console.WriteLine($"Is an Empty Stack: {queue.IsEmpty()}\n");
            Console.WriteLine($"Queue Size:   {queue.Size()}\n");
            Console.WriteLine($"Removed first item added is:   {queue.Dequeue()}\n");
            Console.WriteLine($"Queue Size:   {queue.Size()}\n");


        }
    }
}
