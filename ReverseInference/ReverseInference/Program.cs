using System;
using ReverseInference.DiscussTree.Tree;
using ReverseInference.Fact;
using ReverseInference.Lecser;

internal class Program
{
    public static void Main(string[] args)
    {
        InitializeComponents();
        
        int menu = -1;
        
        Lecser lecser = new Lecser();

        while (menu != 0)
        {
            Console.WriteLine("1)Ввести комманду\n0)Выход");

            menu = Convert.ToInt32(Console.ReadLine());
            
            Console.Clear();
            
            switch (menu)
            {
                case 1:
                    lecser.InputCommandFromConsole();
                    Console.ReadKey();
                    break;
            }

            Console.Clear();
        }
    }

    private static void InitializeComponents()
    {
        new FactsLibrary();
        new DiscussTree();
    }
}