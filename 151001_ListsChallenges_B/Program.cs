using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace _151001_ListsChallenges_B
{
    class Program
    {
        static void Main(string[] args)
        {
            //Create a console app that uses a list to hold student names. After adding, write out options: 
            //Add another student, Clear out all students, List all students, show count of students, save to a file, or exit.
            //Create methods for these operations.

            //Set up 
            Console.WriteLine("Welcome to the Student Name Database");
            Console.WriteLine("Options:");
            Console.WriteLine("Enter \"Add\" to add a student name.");
            Console.WriteLine("Enter \"Clear\" to clear all student names.");
            Console.WriteLine("Enter \"List\" to view a list of all student names.");
            Console.WriteLine("Enter \"Count\" to view the total number of student names.");
            Console.WriteLine("Enter \"Save\" to save the student names to a file.");
            Console.WriteLine("Enter \"Exit\" to exit the console.");

            List<string> names = new List<string>() { };

            //Call method (which calls the other methods)
            Interact(names);
        }

        static void Interact(List<string> names)
        {
            Console.Write("Enter command: ");
            string command = Console.ReadLine();

            //some more set up -- convert command to lower and create list
            command = command.ToLower();
            
            //check which command was given, then call correct method

            switch (command)
            {
                case "add":
                    Console.Write("Name: ");
                    AddName(Console.ReadLine(), names);
                    Console.WriteLine("The name {0} has been added.", names[names.Count - 1]);
                    Interact(names);
                    break;

                case "clear":
                    ClearList(names);
                    Console.WriteLine("The list has been cleared.");
                    Interact(names);
                    break;

                case "list":
                    ListNames(names);
                    Interact(names);
                    break;

                case "count":
                    CountNames(names);
                    Interact(names);
                    break;

                case "save":
                    SavetoFile(names);
                    Interact(names);
                    break;

                case "exit":
                    Environment.Exit(0);
                    break;

                default:
                    Console.WriteLine("unknown command");
                    Interact(names);
                    break;
            }
        }


        static List<string> AddName(string name, List<string> names)
        {
            names.Add(name);
            return names;            
        }

        static List<string> ClearList(List<string> names)
        {
            names.Clear();
            return names;
        }

        static void ListNames(List<string> names)
        {
            if (names.Count > 0)
            {
                foreach (string name in names)
                {
                    Console.WriteLine(name);
                }
            }
            else
            {
                Console.WriteLine("The list is empty.");
            }

        }

        static void CountNames(List<string> names)
        {
            Console.WriteLine(names.Count);
        }

        static void SavetoFile(List<string> names)
        {
            string fileName = "..\\..\\Names.txt";
            StreamWriter writer = new StreamWriter(fileName);
            using (writer)
            {
                if (names.Count > 0)
                {
                    foreach (string name in names)
                    {
                        writer.WriteLine(name);
                    }
                    Console.WriteLine("Names have been saved to {0}", fileName);
                }
                else
                {
                    Console.WriteLine("No names found to save.");
                }
            }
        }
    }
    
}

