using System;
using System.Collections.Generic;
using System.Linq;

namespace Taller5ListasLigadas.Models
{
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
                Console.WriteLine("¡La lista está vacía!");
                return;
            }

            Console.Write("Adelante: ");
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
                Console.WriteLine("¡La lista está vacía!");
                return;
            }

            Console.Write("Atrás: ");
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
                Console.WriteLine("¡La lista está vacía!");
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

            Console.WriteLine("¡Lista ordenada en orden descendente!");
        }

        // Find mode(s) - the most repeated element(s)
        public void ShowMode()
        {
            if (head == null)
            {
                Console.WriteLine("¡La lista está vacía!");
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
                Console.WriteLine("¡La lista está vacía!");
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

            Console.WriteLine("\nGráfico de ocurrencias:");
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
                Console.WriteLine("¡La lista está vacía!");
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

                    Console.WriteLine("Primera aparición de " + data + " eliminado!");
                    return;
                }

                current = current.Next;
            }

            Console.WriteLine("¡Elemento no encontrado!!");
        }

        // Delete all occurrences
        public void DeleteAllOccurrences(T data)
        {
            if (head == null)
            {
                Console.WriteLine("¡La lista está vacía!");
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
                Console.WriteLine(count + "¡Ocurrencia(s) de " + data + " eliminado!");
            else
                Console.WriteLine("¡Elemento no encontrado!");
        }
    }
}