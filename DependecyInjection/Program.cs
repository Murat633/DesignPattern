using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DependecyInjection
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IKernel kernel = new StandardKernel();
            kernel.Bind<IProductDal>().To<EfProductDal>().InSingletonScope();
            kernel.Bind<IProductService>().To<ProductManager>().InSingletonScope();

            IProductDal productDal = new EfProductDal();
            IProductService productManager = kernel.Get<IProductService>();
            productManager.Save();

            Console.ReadLine();
        } 
    }

    interface IProductDal
    {
        void Save();
    }

    class ProductDal : IProductDal
    {
        public void Save()
        {
            Console.WriteLine("saved");
        }
    }

    class EfProductDal : IProductDal
    {
        public void Save()
        {
            Console.WriteLine("saved with Ef");
        }
    }

    class NhProductDal : IProductDal
    {
        public void Save()
        {
            Console.WriteLine("saved with Nh");
        }
    }

    interface IProductService
    {
        void Save();
    }

    class ProductManager:IProductService
    {
        private IProductDal _productDal;

        public ProductManager(IProductDal productDal)
        {
            _productDal = productDal;
        }

        public void Save()
        {
            // Bussines Code 
            _productDal.Save();
        }
    }

}
