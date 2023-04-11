using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractFactory
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ProductManager productManager = new ProductManager(new Factory2());
            productManager.GetAll();
            Console.ReadLine();
        }
    }


    public abstract class Logging
    {
        public abstract void Log();
    }


    public class Log4NetLogger : Logging
    {
        public override void Log()
        {
            Console.WriteLine("Log4NetLogger");
        }
    }

    public class NLogger : Logging
    {
        public override void Log()
        {
            Console.WriteLine("NLogger");
        }
    }


    public abstract class Caching
    {
        public abstract void Cache(string data);
    }

    public class MemCache : Caching
    {
        public override void Cache(string data)
        {
            Console.WriteLine("cached wiht MemCache");
        }
    }

    public class RedisCache : Caching
    {
        public override void Cache(string data)
        {
            Console.WriteLine("RedisCache");
        }
    }


    public abstract class CrossCuttingConcernsFactory
    {
        public abstract Logging CreateLogger();
        public abstract Caching CreateCaching();
    }

    public class Factory1 : CrossCuttingConcernsFactory
    {
        public override Caching CreateCaching()
        {
            return new RedisCache();
        }

        public override Logging CreateLogger()
        {
            return new Log4NetLogger();
        }
    }

    public class Factory2 : CrossCuttingConcernsFactory
    {
        public override Caching CreateCaching()
        {
            return new RedisCache();
        }

        public override Logging CreateLogger()
        {
            return new NLogger();
        }
    }

    public class ProductManager:IProductService
    {
        CrossCuttingConcernsFactory _CrossCuttingConcernsFactory;

        private Logging _logging;
        private Caching _caching;

        public ProductManager( CrossCuttingConcernsFactory crossCuttingConcernsFactory)
        {
            _CrossCuttingConcernsFactory = crossCuttingConcernsFactory;
            _logging = _CrossCuttingConcernsFactory.CreateLogger();
            _caching = _CrossCuttingConcernsFactory.CreateCaching();
        }
        public void GetAll()
        {
            _logging.Log();
            _caching.Cache("data");
            Console.WriteLine("Products Listed");
        }
    }

    public interface IProductService
    {
    }
}
