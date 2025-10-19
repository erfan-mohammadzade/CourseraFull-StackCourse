using System.Runtime.Intrinsics.X86;

namespace InventoryManagementSystem.Models;

    class Product
    {
        public string Id { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string Price { get; set; } = string.Empty;
        public string Quantity { get; set; } = string.Empty;

        public Product(string mId, string mName, string mPrice, string mQuantity)
        {
            this.Id = mId;
            this.Name = mName;
            this.Price = mPrice;
            this.Quantity = mQuantity;
        }
    }

