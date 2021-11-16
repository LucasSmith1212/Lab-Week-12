/// Week 12 Lab 1
/// File Name: week12lab1.cs
/// Author: Lucas Smith
/// Date:  November 15, 2021
///
/// Problem Statement:  Create a phone lookup program. You should have the ability to add, delete, and find phones number. The key will be a person’s name, for the example use just a first name and this will retrieve a person’s phone number. 
/// 
/// 
/// Overall Plan:
/// 1) Declare Class phoneDirectory
/// 2) Declare the methods inside phoneLookup and create an infinite while loop inside the Main Method with which to test each method
/// 3) Test each method inside the loop and print the results
using System;
using System.Collections.Generic;

namespace Lab_1
{
    class Program
    {
        static void Main(string[] args)
        {
            char answer;
            phoneDirectory directory = new phoneDirectory();
            while (true) {
                Console.WriteLine("Menu: ");
                Console.WriteLine("Add Phone Number to Directory....(A)");
                Console.WriteLine("Delete Number from Directory.....(D)");
                Console.WriteLine("Look Up Number from Directory....(L)");
                Console.WriteLine("Destroy All Numbers..............(Z)");
                Console.WriteLine("Quit.............................(Q)");
                Console.WriteLine("What would you like to do?");
                answer = Convert.ToChar(Console.ReadLine());

                if (answer == 'A')
                {
                    Console.WriteLine("-----------------------------------------------------------");
                    Console.WriteLine("Add A Number");
                    Console.WriteLine("-----------------------------------------------------------");
                    Console.WriteLine("What is the name of the person to add to the directory?");
                    string name = Console.ReadLine();
                    Console.WriteLine("What is the number of the person to add to the directory?");
                    string number = Console.ReadLine();

                    directory.registerNumber(name, number);
                } else if (answer == 'D')
                {
                    Console.WriteLine("-----------------------------------------------------------");
                    Console.WriteLine("Delete A Number");
                    Console.WriteLine("-----------------------------------------------------------");
                    Console.WriteLine("What is the name registered to the number you wish to delete?");
                    string numberToDestroy = Console.ReadLine();

                    directory.deleteNumber(numberToDestroy);
                } else if (answer == 'L')
                {
                    Console.WriteLine("-----------------------------------------------------------");
                    Console.WriteLine("Look Up A Number");
                    Console.WriteLine("-----------------------------------------------------------");
                    Console.WriteLine("What is the name associated with the number?");
                    string lookupName = Console.ReadLine();

                    Console.WriteLine(directory.lookUp(lookupName));
                } else if (answer == 'Z')
                {
                    Console.WriteLine("-----------------------------------------------------------");
                    Console.WriteLine("Delete All Numbers");
                    Console.WriteLine("-----------------------------------------------------------");
                    directory.removeAll();
                } else if (answer == 'Q')
                {
                    Console.WriteLine("-----------------------------------------------------------");
                    Console.WriteLine("Thank You!");
                    Console.WriteLine("-----------------------------------------------------------");
                    System.Environment.Exit(0);
                }
            }
        }
    }

    public class phoneDirectory
    {
        private IDictionary<string, string> phoneNumbers = new Dictionary<string, string>() {
            //My number, plus the numbers used to dial in to a Zoom Call
            {"Lucas", "+1 (949) 613 - 3388"},
            {"San Jose", "+1 (669) 900 - 6833"},
            {"Tacoma", "+1 (253) 215 - 8782"},
            {"Houston", "+1 (346) 248 - 7799"},
            {"Chicago", "+1 (312) 626 - 6799"},
            {"New York","+1 (929) 205 - 6099"},
            {"Washington DC", "+1 (301) 715 - 8592"}
        };
        

        public void registerNumber(string name, string phone)
        {
            phoneNumbers.Add(name, phone);
        }

        public void deleteNumber(string key)
        {
            if(phoneNumbers.ContainsKey(key))
            {
                phoneNumbers.Remove(key);
            } else
            {
                Console.WriteLine("Number does not exist.");
            }            
        }

        public void removeAll()
        {
            Console.WriteLine("Are you sure you would like to remove all numbers?");
            string answer = Console.ReadLine();
            answer.ToLower();

            if (answer == "yes") {
                phoneNumbers.Clear();
            } else
            {
                Console.WriteLine("You decided not to remove all numbers.");
            }
        }

        public string lookUp(string numberToFind)
        {
          return phoneNumbers[numberToFind];  
        }
    }
}
