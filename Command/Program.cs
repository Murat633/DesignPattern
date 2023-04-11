using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Command
{
    internal class Program
    {
        static void Main(string[] args)
        {
            StockManager stockManager = new StockManager();
            BuyStock buyStock = new BuyStock(stockManager);
            SellStock sellStock = new SellStock(stockManager);
            StockController stockController = new StockController();

            stockController.TakeOrder(buyStock);
            stockController.TakeOrder(sellStock);
            stockController.PlaceOrders();

            Console.ReadLine();
        }
    }

    class StockManager
    {
        private string _name = "Laptop";
        private int _quantity = 10;
        public void Buy()
        {
            _quantity = _quantity + 1;
            Console.WriteLine("Stock : {0},{1} bougth!",_name,_quantity);
        }

        public void Sell()
        {
            _quantity = _quantity - 1;
            Console.WriteLine("Stock : {0},{1} sold!",_name,_quantity);
        }
    }

    interface IOrder
    {
        void Execute();
    }

    class BuyStock : IOrder
    {
        StockManager _manager;
        public BuyStock(StockManager stockManager)
        {
            _manager = stockManager;
        }
        public void Execute()
        {
            _manager.Buy();
        }
    }

    class SellStock : IOrder
    {
        StockManager _manager;
        public SellStock(StockManager stockManager)
        {
            _manager = stockManager;
        }

        public void Execute()
        {
            _manager.Sell();
        }
    }

    class StockController
    {
        List<IOrder> _orders = new List<IOrder>();

        public void TakeOrder(IOrder order)
        {
            _orders.Add(order);
        }

        public void PlaceOrders()
        {
            foreach (var order in _orders)
            {
                order.Execute();
            }

            _orders.Clear();
        }
    }

}
