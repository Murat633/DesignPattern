using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adapter
{
    internal class Program
    {
        static void Main(string[] args)
        {
            MyLogger myLogger = new MyLogger();
            Log4NetAdapter log4Net = new Log4NetAdapter();
            ProductManager productManager = new ProductManager(log4Net);
            productManager.Save();

            Console.ReadLine();

        }
    }

    class ProductManager
    {
        ILogger _logger;

        public ProductManager(ILogger logger)
        {
            _logger = logger;
        }

        public void Save()
        {
            _logger.Log("User Data");
            Console.WriteLine("Saved");
        }
    }


    interface ILogger
    {
        void Log(string message);
    }

    class MyLogger : ILogger
    {
        public void Log(string message)
        {
            Console.WriteLine(message);
        }
    }

    //Nuget
    class Log4Net
    {
        public void LogMessage(string message) 
        {
            Console.WriteLine(message);
        }
    }

    class Log4NetAdapter : ILogger
    {
        public void Log(string message)
        {
            Log4Net log4Net = new Log4Net();
            log4Net.LogMessage(message);
        }
    }


}
