using InventoryManagementSystem.Models;
using System.Linq;
namespace InventoryManagementSystem.Service;
class ProductService
{
    private readonly List<Product> _products;
    public ProductService(List<Product> ? initProduct = null )
    {
        _products = initProduct ?? new List<Product>();
    }
    public bool AddNewProduct()
    {
         Console.WriteLine("Enter Id: ");
        string id = Console.ReadLine() ?? string.Empty;
        Console.WriteLine("Enter Name: ");
        string name = Console.ReadLine() ?? string.Empty;
        Console.WriteLine("Enter Price: ");
        string price = Console.ReadLine() ?? string.Empty;
        Console.WriteLine("Enter quantity: ");
        string quantity = Console.ReadLine() ?? string.Empty;
        Product newProduct = new(mId: id, mName: name, mPrice: price, mQuantity: quantity);

        Product? founded = _products.FirstOrDefault(ui => ui.Id == newProduct.Id);
        if (founded == null)
        {
            _products.Add(newProduct);
            Console.WriteLine($"Product {id} added");
            return true;
        }
        else Console.WriteLine("Add Failed");
        return false;
    }
    public void RemoveProduct()
    {
        Console.WriteLine("Enter id of product to remove");
        var EnteredId = Console.ReadLine() ?? string.Empty;
        Product? founded = _products.FirstOrDefault(ui => ui.Id == EnteredId);
        if (founded != null)
        {
            Console.WriteLine("Product Founded (y/n)");
            string answer = Console.ReadLine() ?? string.Empty;
            if (answer.Equals("y", StringComparison.OrdinalIgnoreCase))
            {
                _products.Remove(founded);
                Console.WriteLine("Product Removed");
            }
            else
            {
                Console.WriteLine("Process failed!");
            }
        }
        else
        {
            Console.WriteLine("Process failed!");
        }
    }

    public void UpdateProduct()
    {
        Console.WriteLine("Enter Product Id");
        var id = Console.ReadLine() ?? string.Empty;
        var found  = _products.FirstOrDefault(ui => ui.Id == id);
        if (found  == null)
            Console.WriteLine("Product Not Found");
        else
        {
            Console.Write("Enter new name (leave blank to keep current): ");
            string newName = Console.ReadLine() ?? string.Empty;
            Console.Write("Enter new price (leave blank to keep current): ");
            string newPrice = Console.ReadLine() ?? string.Empty;
            Console.Write("Enter new quantity (leave blank to keep current): ");
            string newQuantity = Console.ReadLine() ?? string.Empty;

            if (!string.IsNullOrWhiteSpace(newName)) found.Name = newName;
            if (!string.IsNullOrWhiteSpace(newPrice)) found.Price = newPrice;
            if (!string.IsNullOrWhiteSpace(newQuantity)) found.Quantity = newQuantity;
            Console.WriteLine($"Product {id} updated.");
        }
    }
    public void GetProducts()
    {
        for (int i = 0; i < _products.Count; i++)
        {
            var p = _products[i];
            Console.WriteLine("-----");
            Console.WriteLine($"Id: {p.Id}");
            Console.WriteLine($"Name: {p.Name}");
            Console.WriteLine($"Price: {p.Price}");
            Console.WriteLine($"Quantity: {p.Quantity}");
        }
    }

    public bool buyProduct()
    {
        Console.WriteLine("Enter Product Id for buy:");
        string pId = Console.ReadLine() ?? string.Empty;
        var found = _products.FirstOrDefault(ui => ui.Id == pId);
        if (found == null)
        {
            Console.WriteLine("Product not found!");
            return false;
        }
        Console.WriteLine("Enter quantity: ");
        string qtyInput = Console.ReadLine() ?? string.Empty;
        if (!int.TryParse(qtyInput, out int quantity) || quantity <= 0)
        {
            Console.WriteLine("Invalid quantity.");
            return false;
        }

        // parse existing product quantity (stored as string in model)
        if (!int.TryParse(found.Quantity, out int existingQty))
        {
            Console.WriteLine("Product quantity is invalid.");
            return false;
        }

        if (quantity > existingQty)
        {
            Console.WriteLine("Not enough stock.");
            return false;
        }

        existingQty -= quantity;
        found.Quantity = existingQty.ToString();
        Console.WriteLine($"Purchase successful. Remaining quantity: {found.Quantity}");
        return true;
    }
    public Product? GetProductById(string id) => _products.FirstOrDefault(ui=>ui.Id == id);
    
}