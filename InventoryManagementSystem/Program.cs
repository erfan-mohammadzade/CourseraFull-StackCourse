// See https://aka.ms/new-console-template for more information
using InventoryManagementSystem.Models;
using InventoryManagementSystem.Service;
using System;
class Program()
{
    private static ProductService _service = new();
    private static void operationManeger(int operationID)
    {
        Console.Clear();
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
        }
    }
    private static int ShowMenu()
    {
        Console.WriteLine("1-Add");
        Console.WriteLine("2-Remove");
        Console.WriteLine("3-Get All");
        Console.WriteLine("4-Update");
        Console.WriteLine("5-Exit");
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
            int selection = ShowMenu();
            if (selection == 5) break;
            else operationManeger(selection);     
        }
    }
}