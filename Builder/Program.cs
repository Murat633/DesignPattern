using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Builder
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ProductDirector director = new ProductDirector();
            var builder = new OldCustomerProductBuilder();
            director.GenerateProduct(builder);
            var model = builder.GetModel();

            Console.WriteLine(model.Id);
            Console.WriteLine(model.CategoryName);
            Console.WriteLine(model.ProductName);
            Console.WriteLine(model.DiscountedPrice);
            Console.WriteLine(model.IsDiscounted);
            Console.WriteLine(model.UnitPrice);

            Console.ReadLine();
        }
    }

    class ProductWievModel
    {
        public int Id { get; set; }
        public string CategoryName { get; set; }
        public string ProductName { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal DiscountedPrice { get; set; }
        public bool IsDiscounted { get; set; }
    }

    abstract class ProductBuilder
    {
        public abstract void GetProductData();
        public abstract void ApplyDiscount();
        public abstract ProductWievModel GetModel();
    }

    class NewCustomerProductBuilder : ProductBuilder
    {
        ProductWievModel model = new ProductWievModel();
        public override void GetProductData()
        {
            model.Id = 1;
            model.CategoryName = "Bevereges";
            model.ProductName = "Chai";
            model.UnitPrice = 20;
        }
        public override void ApplyDiscount()
        {
            model.DiscountedPrice = model.UnitPrice * (decimal)0.90;
            model.IsDiscounted = true;
        }

        public override ProductWievModel GetModel()
        {
            return model;
        }
    }

    class OldCustomerProductBuilder : ProductBuilder
    {
        ProductWievModel model = new ProductWievModel();

        public override void GetProductData()
        {
            model.Id = 1;
            model.CategoryName = "Bevereges";
            model.ProductName = "Chai";
            model.UnitPrice = 20;
        }
        public override void ApplyDiscount()
        {
            model.DiscountedPrice = 0;
            model.IsDiscounted = false;
        }

        public override ProductWievModel GetModel()
        {
            return model;
        }
    }

    class ProductDirector
    {
        public void GenerateProduct(ProductBuilder productBuilder)
        {
            productBuilder.GetProductData();
            productBuilder.ApplyDiscount();
        }
    }
}
