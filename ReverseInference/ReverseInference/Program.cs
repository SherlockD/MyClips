using System;
using System.Text;
using ReverseInference.Lecser;

internal class Program
{
    public static void Main(string[] args)
    {
        Console.InputEncoding = Encoding.UTF8;
        Console.OutputEncoding = Encoding.UTF8;

        Console.WriteLine(Console.InputEncoding);
        
        InitializeComponents();
        
        int menu = -1;
        
        Lecser lecser = new Lecser();

        while (menu != 0)
        {
            Console.WriteLine("1)Input command\n0)Exit");

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
        new DiscussTree();
    }
}