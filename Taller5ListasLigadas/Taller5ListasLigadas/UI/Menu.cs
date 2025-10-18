using System;
using Taller5ListasLigadas.Models;

namespace Taller5ListasLigadas.UI
{
    // Menu class - handles all the user interface
    public class Menu
    {
        private DoublyLinkedList<int> myList;

        public Menu()
        {
            // Create a new list (you can change int to string, double, etc.)
            myList = new DoublyLinkedList<int>();
        }

        // Main menu method
        public void Start()
        {
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

                // Validate input
                if (!int.TryParse(Console.ReadLine(), out option))
                {
                    Console.WriteLine("Invalid input!");
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
                        Console.WriteLine("Bye!");
                        break;

                    default:
                        Console.WriteLine("Invalid option!");
                        break;
                }
            }
        }

        // Helper method to add an element
        private void AddElement()
        {
            Console.Write("Enter element to add: ");
            if (int.TryParse(Console.ReadLine(), out int value))
            {
                myList.Add(value);
                Console.WriteLine("Element added!");
            }
            else
                Console.WriteLine("Invalid input!");
        }

        // Helper method to check if element exists
        private void CheckIfExists()
        {
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
        }

        // Helper method to delete first occurrence
        private void DeleteFirstOccurrence()
        {
            Console.Write("Enter element to delete: ");
            if (int.TryParse(Console.ReadLine(), out int delValue))
            {
                myList.DeleteFirstOccurrence(delValue);
            }
            else
                Console.WriteLine("Invalid input!");
        }

        // Helper method to delete all occurrences
        private void DeleteAllOccurrences()
        {
            Console.Write("Enter element to delete all occurrences: ");
            if (int.TryParse(Console.ReadLine(), out int delAllValue))
            {
                myList.DeleteAllOccurrences(delAllValue);
            }
            else
                Console.WriteLine("Invalid input!");
        }
    }
}