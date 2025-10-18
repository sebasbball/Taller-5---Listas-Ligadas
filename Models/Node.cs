using System;

namespace TuNombreDeProyecto.Models
{
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