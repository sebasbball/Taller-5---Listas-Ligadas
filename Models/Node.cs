using System;

namespace Taller5ListasLigadas.Models
{
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
}