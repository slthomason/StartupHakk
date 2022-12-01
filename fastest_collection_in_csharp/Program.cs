using System;
using System.Collections;
using System.Collections.Generic;

namespace _11_fastest_collection_in_csharp
{
    internal class Program
    {
        static void Main(string[] args)
        {

            #region Hashset


            // Creating HashSet
            // Using HashSet class
            HashSet<string> myhash1 = new HashSet<string>();

            // Add the elements in HashSet
            // Using Add method
            myhash1.Add("C");
            myhash1.Add("C++");
            myhash1.Add("C#");
            myhash1.Add("Java");
            myhash1.Add("Ruby");
            Console.WriteLine("Elements of myhash1:");

            // Accessing elements of HashSet
            // Using foreach loop
            foreach (var val in myhash1)
            {
                Console.WriteLine(val);
            }

            // Creating another HashSet
            // using collection initializer
            // to initialize HashSet
            HashSet<int> myhash2 = new HashSet<int>() {10,
                               100,1000,10000,100000};

            // Display elements of myhash2
            Console.WriteLine("Elements of myhash2:");
            foreach (var value in myhash2)
            {
                Console.WriteLine(value);
            }

            #endregion


            #region dictionary 

            // Creating a dictionary
            // using Dictionary<TKey,TValue> class
            Dictionary<int, string> My_dict1 =
                           new Dictionary<int, string>();

            // Adding key/value pairs 
            // in the Dictionary
            // Using Add() method
            My_dict1.Add(1123, "Welcome");
            My_dict1.Add(1124, "to");
            My_dict1.Add(1125, "Startuphakk");

            foreach (KeyValuePair<int, string> ele1 in My_dict1)
            {
                Console.WriteLine("{0} and {1}",
                          ele1.Key, ele1.Value);
            }
            Console.WriteLine();

            // Creating another dictionary
            // using Dictionary<TKey,TValue> class
            // adding key/value pairs without
            // using Add method
            Dictionary<string, string> My_dict2 =
                    new Dictionary<string, string>(){
                                  {"a.1", "Dog"},
                                  {"a.2", "Cat"},
                                {"a.3", "Pig"} };

            foreach (KeyValuePair<string, string> ele2 in My_dict2)
            {
                Console.WriteLine("{0} and {1}", ele2.Key, ele2.Value);
            }
            #endregion

            #region LinkedList

            // Creating a linkedlist
            // Using LinkedList class
            LinkedList<String> my_list = new LinkedList<String>();

            // Adding elements in the LinkedList
            // Using AddLast() method
            my_list.AddLast("Zoya");
            my_list.AddLast("Shilpa");
            my_list.AddLast("Rohit");
            my_list.AddLast("Rohan");
            my_list.AddLast("Juhi");
            my_list.AddLast("Zoya");

            Console.WriteLine("Best students of XYZ university:");

            // Accessing the elements of 
            // LinkedList Using foreach loop
            foreach (string str in my_list)
            {
                Console.WriteLine(str);
            }

            #endregion

            #region Stack

            Stack<int> myStack = new Stack<int>();
            myStack.Push(1);
            myStack.Push(2);
            myStack.Push(3);
            myStack.Push(4);

            foreach (var item in myStack)
                Console.Write(item + ","); //prints 4,3,2,1, 

            #endregion


            #region Queue

            // Creating a Queue 
            Queue myQueue = new Queue();

            // Inserting the elements into the Queue
            myQueue.Enqueue("one");

            // Displaying the count of elements
            // contained in the Queue
            Console.Write("Total number of elements in the Queue are : ");

            Console.WriteLine(myQueue.Count);

            myQueue.Enqueue("two");

            // Displaying the count of elements
            // contained in the Queue
            Console.Write("Total number of elements in the Queue are : ");

            Console.WriteLine(myQueue.Count);

            myQueue.Enqueue("three");

            // Displaying the count of elements
            // contained in the Queue
            Console.Write("Total number of elements in the Queue are : ");

            Console.WriteLine(myQueue.Count);

            myQueue.Enqueue("four");

            // Displaying the count of elements
            // contained in the Queue
            Console.Write("Total number of elements in the Queue are : ");

            Console.WriteLine(myQueue.Count);

            myQueue.Enqueue("five");

            // Displaying the count of elements
            // contained in the Queue
            Console.Write("Total number of elements in the Queue are : ");

            Console.WriteLine(myQueue.Count);

            myQueue.Enqueue("six");

            // Displaying the count of elements
            // contained in the Queue
            Console.Write("Total number of elements in the Queue are : ");

            Console.WriteLine(myQueue.Count);

            #endregion
        }
    }
}
