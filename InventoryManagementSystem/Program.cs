// See https://aka.ms/new-console-template for more information
using InventoryManagementSystem.Models;
using InventoryManagementSystem.Service;
using System;
class Program()
{
    private static ProductService _service = new();
    private static void operationManeger(int operationID)
    {
        switch (operationID)
        {
            case 0:
                ShowMenu();
                break;
            case 1:
                _service.AddNewProduct();
                break;
            case 2:
                _service.RemoveProduct();
                break;

            case 3:
                _service.GetProducts();
                break;

            case 4:
                _service.UpdateProduct();
                break;
            case 5:
                _service.buyProduct();
                break;
        }
    }
    private static int ShowMenu()
    {
        Console.Clear();
        Console.WriteLine("1-Add");
        Console.WriteLine("2-Remove");
        Console.WriteLine("3-Get All");
        Console.WriteLine("4-Update");
        Console.WriteLine("5-Buy");
        Console.WriteLine("6-Exit");
        Console.WriteLine("Enter Item Number");
        if (int.TryParse(Console.ReadLine(), out int selection))
        {
            return selection;
        }
        return 0;
    }
    static void Main(string[] args)
    {
        while (true)
        {
            Console.WriteLine("show menu (y/n)");
            string reply = Console.ReadLine() ?? String.Empty;
            if (reply.Equals("y", StringComparison.InvariantCultureIgnoreCase))
            {
                int selection = ShowMenu();
                if (selection == 6)
                {
                    break;
                }
                else
                {
                    operationManeger(selection);
                }
            }
            else
            {
                Console.WriteLine("Exit (y/n)");
                reply = Console.ReadLine() ?? String.Empty;
                if (reply.Equals("y", StringComparison.InvariantCultureIgnoreCase))
                {
                   break;  
                }
            }
        }
    }
}