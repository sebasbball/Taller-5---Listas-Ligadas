using System;
using System.Collections.Generic;
using System.Linq;

// Node class for the doubly linked list
public class Node<T> where T : IComparable<T>
{
    public T Data;
    public Node<T> Next;
    public Node<T> Prev;

    public Node(T data)
    {
        Data = data;
        Next = null;
        Prev = null;
    }
}

// Doubly Linked List class with all the menu operations
public class DoublyLinkedList<T> where T : IComparable<T>
{
    private Node<T> head;
    private Node<T> tail;

    public DoublyLinkedList()
    {
        head = null;
        tail = null;
    }

    // Add element in ascending order
    public void Add(T data)
    {
        Node<T> newNode = new Node<T>(data);

        // If list is empty
        if (head == null)
        {
            head = newNode;
            tail = newNode;
            return;
        }

        // Find the correct position to insert
        Node<T> current = head;
        while (current != null && current.Data.CompareTo(data) < 0)
        {
            current = current.Next;
        }

        // Insert at the beginning
        if (current == head)
        {
            newNode.Next = head;
            head.Prev = newNode;
            head = newNode;
        }
        // Insert at the end
        else if (current == null)
        {
            tail.Next = newNode;
            newNode.Prev = tail;
            tail = newNode;
        }
        // Insert in the middle
        else
        {
            newNode.Next = current;
            newNode.Prev = current.Prev;
            current.Prev.Next = newNode;
            current.Prev = newNode;
        }
    }

    // Display forward
    public void DisplayForward()
    {
        if (head == null)
        {
            Console.WriteLine("List is empty!");
            return;
        }

        Console.Write("Forward: ");
        Node<T> current = head;
        while (current != null)
        {
            Console.Write(current.Data + " ");
            current = current.Next;
        }
        Console.WriteLine();
    }

    // Display backward
    public void DisplayBackward()
    {
        if (tail == null)
        {
            Console.WriteLine("List is empty!");
            return;
        }

        Console.Write("Backward: ");
        Node<T> current = tail;
        while (current != null)
        {
            Console.Write(current.Data + " ");
            current = current.Prev;
        }
        Console.WriteLine();
    }

    // Sort in descending order
    public void SortDescending()
    {
        if (head == null)
        {
            Console.WriteLine("List is empty!");
            return;
        }

        // Get all elements
        List<T> elements = new List<T>();
        Node<T> current = head;
        while (current != null)
        {
            elements.Add(current.Data);
            current = current.Next;
        }

        // Sort descending and rebuild the list
        elements.Sort((a, b) => b.CompareTo(a));
        head = null;
        tail = null;

        foreach (T element in elements)
        {
            Node<T> newNode = new Node<T>(element);
            if (head == null)
            {
                head = newNode;
                tail = newNode;
            }
            else
            {
                tail.Next = newNode;
                newNode.Prev = tail;
                tail = newNode;
            }
        }

        Console.WriteLine("List sorted in descending order!");
    }

    // Find mode(s) - the most repeated element(s)
    public void ShowMode()
    {
        if (head == null)
        {
            Console.WriteLine("List is empty!");
            return;
        }

        // Count occurrences
        Dictionary<T, int> frequency = new Dictionary<T, int>();
        Node<T> current = head;
        while (current != null)
        {
            if (frequency.ContainsKey(current.Data))
                frequency[current.Data]++;
            else
                frequency[current.Data] = 1;

            current = current.Next;
        }

        // Find the maximum frequency
        int maxFreq = frequency.Values.Max();

        // Find all elements with maximum frequency
        Console.Write("Mode(s): ");
        var modes = frequency.Where(x => x.Value == maxFreq).Select(x => x.Key);
        foreach (T mode in modes)
        {
            Console.Write(mode + " ");
        }
        Console.WriteLine();
    }

    // Show a simple graph of occurrences
    public void ShowGraph()
    {
        if (head == null)
        {
            Console.WriteLine("List is empty!");
            return;
        }

        // Count occurrences
        Dictionary<T, int> frequency = new Dictionary<T, int>();
        Node<T> current = head;
        while (current != null)
        {
            if (frequency.ContainsKey(current.Data))
                frequency[current.Data]++;
            else
                frequency[current.Data] = 1;

            current = current.Next;
        }

        Console.WriteLine("\nGraph of Occurrences:");
        foreach (var item in frequency)
        {
            Console.Write(item.Key + "  ");
            for (int i = 0; i < item.Value; i++)
            {
                Console.Write("*");
            }
            Console.WriteLine();
        }
        Console.WriteLine();
    }

    // Check if an element exists
    public bool Exists(T data)
    {
        Node<T> current = head;
        while (current != null)
        {
            if (current.Data.CompareTo(data) == 0)
                return true;

            current = current.Next;
        }
        return false;
    }

    // Delete first occurrence
    public void DeleteFirstOccurrence(T data)
    {
        if (head == null)
        {
            Console.WriteLine("List is empty!");
            return;
        }

        Node<T> current = head;
        while (current != null)
        {
            if (current.Data.CompareTo(data) == 0)
            {
                // Delete from beginning
                if (current == head)
                {
                    head = current.Next;
                    if (head != null)
                        head.Prev = null;
                }
                // Delete from end
                else if (current == tail)
                {
                    tail = current.Prev;
                    if (tail != null)
                        tail.Next = null;
                }
                // Delete from middle
                else
                {
                    current.Prev.Next = current.Next;
                    current.Next.Prev = current.Prev;
                }

                Console.WriteLine("First occurrence of " + data + " deleted!");
                return;
            }

            current = current.Next;
        }

        Console.WriteLine("Element not found!");
    }

    // Delete all occurrences
    public void DeleteAllOccurrences(T data)
    {
        if (head == null)
        {
            Console.WriteLine("List is empty!");
            return;
        }

        int count = 0;
        Node<T> current = head;

        while (current != null)
        {
            if (current.Data.CompareTo(data) == 0)
            {
                Node<T> temp = current;
                current = current.Next;

                // Delete from beginning
                if (temp == head)
                {
                    head = current;
                    if (head != null)
                        head.Prev = null;
                }
                // Delete from end
                else if (temp == tail)
                {
                    tail = temp.Prev;
                    if (tail != null)
                        tail.Next = null;
                }
                // Delete from middle
                else
                {
                    temp.Prev.Next = temp.Next;
                    temp.Next.Prev = temp.Prev;
                }

                count++;
            }
            else
            {
                current = current.Next;
            }
        }

        if (count > 0)
            Console.WriteLine(count + " occurrence(s) of " + data + " deleted!");
        else
            Console.WriteLine("Element not found!");
    }
}

// Main program with menu
class Program
{
    static void Main()
    {
        // You can change the type to int, string, double, etc.
        DoublyLinkedList<int> myList = new DoublyLinkedList<int>();

        int option = 0;

        while (option != 10)
        {
            Console.WriteLine("\n========== DOUBLY LINKED LIST MENU ==========");
            Console.WriteLine("1. Add element");
            Console.WriteLine("2. Show forward");
            Console.WriteLine("3. Show backward");
            Console.WriteLine("4. Sort descending");
            Console.WriteLine("5. Show mode(s)");
            Console.WriteLine("6. Show graph");
            Console.WriteLine("7. Check if element exists");
            Console.WriteLine("8. Delete first occurrence");
            Console.WriteLine("9. Delete all occurrences");
            Console.WriteLine("10. Exit");
            Console.Write("\nChoose an option: ");

            if (!int.TryParse(Console.ReadLine(), out option))
            {
                Console.WriteLine("Invalid input!");
                continue;
            }

            switch (option)
            {
                case 1:
                    Console.Write("Enter element to add: ");
                    if (int.TryParse(Console.ReadLine(), out int value))
                    {
                        myList.Add(value);
                        Console.WriteLine("Element added!");
                    }
                    else
                        Console.WriteLine("Invalid input!");
                    break;

                case 2:
                    myList.DisplayForward();
                    break;

                case 3:
                    myList.DisplayBackward();
                    break;

                case 4:
                    myList.SortDescending();
                    break;

                case 5:
                    myList.ShowMode();
                    break;

                case 6:
                    myList.ShowGraph();
                    break;

                case 7:
                    Console.Write("Enter element to search: ");
                    if (int.TryParse(Console.ReadLine(), out int searchValue))
                    {
                        if (myList.Exists(searchValue))
                            Console.WriteLine("Element EXISTS!");
                        else
                            Console.WriteLine("Element DOES NOT exist!");
                    }
                    else
                        Console.WriteLine("Invalid input!");
                    break;

                case 8:
                    Console.Write("Enter element to delete: ");
                    if (int.TryParse(Console.ReadLine(), out int delValue))
                    {
                        myList.DeleteFirstOccurrence(delValue);
                    }
                    else
                        Console.WriteLine("Invalid input!");
                    break;

                case 9:
                    Console.Write("Enter element to delete all occurrences: ");
                    if (int.TryParse(Console.ReadLine(), out int delAllValue))
                    {
                        myList.DeleteAllOccurrences(delAllValue);
                    }
                    else
                        Console.WriteLine("Invalid input!");
                    break;

                case 10:
                    Console.WriteLine("Bye!");
                    break;

                default:
                    Console.WriteLine("Invalid option!");
                    break;
            }
        }
    }
}