using System;
using System.Collections.Generic;
using System.Threading;

class PrinterQueue
{
    static void Main()
    {
        Queue<string> printQueue = new Queue<string>();
        int choice;

        do
        {
            Console.WriteLine("\n=== PRINTER QUEUE MENU ===");
            Console.WriteLine("1. Add Document to Print Queue");
            Console.WriteLine("2. Print Next Document");
            Console.WriteLine("3. View Queue");
            Console.WriteLine("4. Exit");
            Console.Write("Enter your choice: ");

            if (!int.TryParse(Console.ReadLine(), out choice))
            {
                Console.WriteLine("Invalid input! Please enter a number.");
                continue;
            }

            switch (choice)
            {
                case 1:
                    Console.Write("Enter document name to add: ");
                    string docName = Console.ReadLine();
                    printQueue.Enqueue(docName);
                    Console.WriteLine($"✅ '{docName}' added to the print queue.");
                    break;

                case 2:
                    if (printQueue.Count > 0)
                    {
                        string nextDoc = printQueue.Dequeue();
                        Console.WriteLine($"🖨️ Printing '{nextDoc}'...");
                        Thread.Sleep(2000); // Simulate printing delay
                        Console.WriteLine($"✅ '{nextDoc}' printed successfully!");
                    }
                    else
                    {
                        Console.WriteLine("⚠️ Print queue is empty!");
                    }
                    break;

                case 3:
                    if (printQueue.Count > 0)
                    {
                        Console.WriteLine("\nDocuments in Queue:");
                        foreach (string doc in printQueue)
                            Console.WriteLine($" - {doc}");
                    }
                    else
                    {
                        Console.WriteLine("📂 No documents in the queue.");
                    }
                    break;

                case 4:
                    Console.WriteLine("Exiting printer program...");
                    break;

                default:
                    Console.WriteLine("Invalid choice! Please enter a number between 1 and 4.");
                    break;
            }

        } while (choice != 4);
    }
}