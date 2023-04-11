using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Strategy
{
    internal class Program
    {
        static void Main(string[] args)
        {
            CreditCalculatorBase after2010 = new After2010CreditCalculator();
            CustomerManager customerManager = new CustomerManager(after2010);
            customerManager.SaveCredit();

            Console.ReadLine();
        }
    }

    abstract class CreditCalculatorBase
    {
        public abstract void Calculate();
    }

    class Before2010CreditCalculator : CreditCalculatorBase
    {
        public override void Calculate()
        {
            Console.WriteLine("Credit calculated using before 2010");
        }
    }

    class After2010CreditCalculator : CreditCalculatorBase
    {
        public override void Calculate()
        {
            Console.WriteLine("Credit calculated using After 2010");
        }
    }

    class CustomerManager
    {
        CreditCalculatorBase _creditCalculatorBase { get; set; }

        public CustomerManager(CreditCalculatorBase creditCalculatorBase)
        {
            _creditCalculatorBase = creditCalculatorBase;
        }

        public void SaveCredit()
        {
            _creditCalculatorBase.Calculate();
        }
    }
}
