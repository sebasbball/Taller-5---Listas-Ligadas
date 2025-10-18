using System;
using Taller5ListasLigadas.Models;

namespace Taller5ListasLigadas.UI
{
    // Menu class - handles all the user interface
    public class Menu
    {
        private DoublyLinkedList<string> myList;

        public Menu()
        {
            // Create a new list (you can change string to int, double, etc.)
            myList = new DoublyLinkedList<string>();
        }

        // Main menu method
        public void Start()
        {
            int option = 0;

            while (option != 10)
            {
                Console.WriteLine("\n========== MENU - LISTA DOBLEMENTE LIGADA ==========");
                Console.WriteLine("1. Adicionar");
                Console.WriteLine("2. Mostrar hacia adelante");
                Console.WriteLine("3. Mostrar hacia atrás");
                Console.WriteLine("4. Ordenar decentemente");
                Console.WriteLine("5. Mostrar la(s) moda(s)");
                Console.WriteLine("6. Mostrar gráfico");
                Console.WriteLine("7. Existe");
                Console.WriteLine("8. Eliminar una ocurrencia");
                Console.WriteLine("9. Eliminar todas las ocurrencia");
                Console.WriteLine("10. Salir");
                Console.Write("\nElige una opción: ");

                // Validate input
                if (!int.TryParse(Console.ReadLine(), out option))
                {
                    Console.WriteLine("¡Datos Incorrectos!");
                    continue;
                }

                // Execute the selected option
                switch (option)
                {
                    case 1:
                        AddElement();
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
                        CheckIfExists();
                        break;

                    case 8:
                        DeleteFirstOccurrence();
                        break;

                    case 9:
                        DeleteAllOccurrences();
                        break;

                    case 10:
                        Console.WriteLine("¡Adiós!");
                        break;

                    default:
                        Console.WriteLine("¡Opción inválida!");
                        break;
                }
            }
        }

        // Helper method to add an element
        private void AddElement()
        {
            Console.Write("Ingresa el número a adicionar: ");
            if (int.TryParse(Console.ReadLine(), out int value))
            {
                myList.Add(value);
                Console.WriteLine("¡Número adicionado!");
            }
            else
                Console.WriteLine("¡Datos Incorrectos!");
        }

        // Helper method to check if element exists
        private void CheckIfExists()
        {
            Console.Write("Ingresa el número a buscar: ");
            if (int.TryParse(Console.ReadLine(), out int searchValue))
            {
                if (myList.Exists(searchValue))
                    Console.WriteLine("¡El número EXISTE!");
                else
                    Console.WriteLine("¡El número NO existe!");
            }
            else
                Console.WriteLine("¡Datos Incorrectos!");
        }

        // Helper method to delete first occurrence
        private void DeleteFirstOccurrence()
        {
            Console.Write("Ingresa el número a eliminar: ");
            if (int.TryParse(Console.ReadLine(), out int delValue))
            {
                myList.DeleteFirstOccurrence(delValue);
            }
            else
                Console.WriteLine("¡Datos Incorrectos!");
        }

        // Helper method to delete all occurrences
        private void DeleteAllOccurrences()
        {
            Console.Write("Ingresa el número a eliminar todas las ocurrencias: ");
            if (int.TryParse(Console.ReadLine(), out int delAllValue))
            {
                myList.DeleteAllOccurrences(delAllValue);
            }
            else
                Console.WriteLine("¡Datos Incorrectos!");
        }
    }
}