using FoundationsOfFullStackFinalProject.Models;
using System.Linq;
namespace FoundationsOfFullStackFinalProject.Service;
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
        string id = Console.ReadLine();
        Console.WriteLine("Enter Name: ");
        string name = Console.ReadLine();
        Console.WriteLine("Enter Price: ");
        string price = Console.ReadLine();
        Console.WriteLine("Enter quantity: ");
        string quantity = Console.ReadLine();
        Product newProduct = new(mId: id, mName: name, mPrice: price, mQuantity: quantity);

        var founded = _products.FirstOrDefault(ui => ui.Id == newProduct.Id);
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
        var EnteredId = Console.ReadLine();
        var founded = _products.FirstOrDefault(ui => ui.Id == EnteredId);
        if (founded != null)
        {
            Console.WriteLine("Product Founded (y/n)");
            string answer = Console.ReadLine();
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
        var id = Console.ReadLine();
        var found  = _products.FirstOrDefault(ui => ui.Id == id);
        if (found  == null)
            Console.WriteLine("Product Not Found");
        else
        {
            Console.Write("Enter new name (leave blank to keep current): ");
            string newName = Console.ReadLine();
            Console.Write("Enter new price (leave blank to keep current): ");
            string newPrice = Console.ReadLine();
            Console.Write("Enter new quantity (leave blank to keep current): ");
            string newQuantity = Console.ReadLine();

            if (!string.IsNullOrWhiteSpace(newName)) found.Name = newName;
            if (!string.IsNullOrWhiteSpace(newPrice)) found.Price = newPrice;
            if (!string.IsNullOrWhiteSpace(newQuantity)) found.Quantity = newQuantity;
            Console.WriteLine($"Product {id} updated.");
        }
    }
    public IEnumerable<Product> GetProducts() => _products;
    public Product? GetProductById(string id) => _products.FirstOrDefault(ui=>ui.Id == id);
    
}