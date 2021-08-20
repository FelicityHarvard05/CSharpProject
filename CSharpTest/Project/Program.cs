using System;
using System.Linq;

namespace Project
{
    class Program
    {
        public class LinkedList
        {
            Node head; // head of list

            /* Linked list Node. This inner class is made static so that
            main() can access it */
            public class Node
            {
                public int data;
                public Node next;
                public Node(int d)
                {
                    data = d;
                    next = null;
                } // Constructor
            }

            void deleteNode(int key)
            {
                // Store head node
                Node temp = head, prev = null;

                // If head node itself holds
                // the key to be deleted
                if (temp != null &&
                    temp.data == key)
                {
                    // Changed head
                    head = temp.next;
                    return;
                }

                // Search for the key to be
                // deleted, keep track of the
                // previous node as we need
                // to change temp.next
                while (temp != null &&
                       temp.data != key)
                {
                    prev = temp;
                    temp = temp.next;
                }

                // If key was not present
                // in linked list
                if (temp == null)
                    return;

                // Unlink the node from linked list
                prev.next = temp.next;
            }

            // Inserts a new Node at
            // front of the list.
            public void Push(int new_data)
            {
                Node new_node = new Node(new_data);
                new_node.next = head;
                head = new_node;
            }

            // This function prints contents
            // of linked list starting from
            // the given node
            public void printList()
            {
                Node tnode = head;
                while (tnode != null)
                {
                    Console.Write(tnode.data + " ");
                    tnode = tnode.next;
                }
            }
            public static void Main()
            {
                //need to be able to pull the numbers to create the linked list
                //need to make deletion on that linked list 


                string file = "";

                Console.WriteLine("                        Welcome to the program                         ");
                Console.WriteLine("In this software a file is given with items to be added and deleted for");
                Console.WriteLine("a linked list. The program will read the file and create the Linked List");
                Console.WriteLine("and make the requested delations");
                Console.WriteLine("Please enter the path to the file: ");
                file = Console.ReadLine();

                string text = System.IO.File.ReadAllText(@file);
                System.Console.WriteLine("Contents of WriteText.txt = {0}", text);
                string numericPhone = new String(text.Where(Char.IsDigit).ToArray()); //Pulls numbers out
                System.Console.WriteLine(numericPhone);

                LinkedList llist = new LinkedList();
                int num1 = (numericPhone[0]);
                Console.WriteLine(num1);
                llist.head = new Node(num1);
                Node second = new Node(numericPhone[1]);
                Node third = new Node(numericPhone[2]);
                llist.head.next = second;
                second.next = third;


                //Counts how many elements needed to be inserted into the Linekd list
                int count = 0;
                foreach (char c in text)
                    if (c == 'i')
                    {
                        int index1 = text.IndexOf(c);
                        int newindex = index1 + 2;
                        count++;
                    }
                Console.WriteLine(count);

            // Counts how many elments need to be deleted
                int deletCount = 0;
                foreach (char cr in text)
                    if (cr == 'd')
                    {
                        deletCount++;
                    }
                Console.WriteLine(deletCount);

                llist.printList();
            }

        }
       
        //Needed to create a loop that will insert the elements into a linkedlist 
        //Needed to find some way to pull the elements from the file (tried doing it with the for each but it only pulls the first i over again)
        

    }
}
