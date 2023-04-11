using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChainOfResponsibility
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Manager manager = new Manager();
            VicePresident vicePresident = new VicePresident();
            President president = new President();

            manager.SetSuccessor(vicePresident);
            vicePresident.SetSuccessor(president);

            Expense expense = new Expense() { Detail = "Training",Amount=1001};
            manager.HandleExpense(expense);

            Console.ReadLine();
        }
    }

    class Expense
    {
        public string Detail { get; set; }
        public decimal Amount { get; set; }
    } 

    abstract class ExpenseHandleBase
    {
        protected ExpenseHandleBase Successor;
        public abstract void HandleExpense(Expense expense);

        public void SetSuccessor(ExpenseHandleBase successor)
        {
            Successor = successor;
        }

    }

    class Manager : ExpenseHandleBase
    {
        public override void HandleExpense(Expense expense)
        {
            if (expense.Amount <= 100)
            {
                Console.WriteLine("Manager Handled the expense!");
            }else if(Successor != null)
            {
                Successor.HandleExpense(expense);
            }
        }
    }

    class VicePresident : ExpenseHandleBase
    {
        public override void HandleExpense(Expense expense)
        {
            if(expense.Amount > 100 && expense.Amount <= 1000)
            {
                Console.WriteLine("vice president handled the expense!");
            }
            else if(Successor != null) 
            {
                Successor.HandleExpense(expense);
            }
        }
    }

    class President : ExpenseHandleBase
    {
        public override void HandleExpense(Expense expense)
        {
            if (expense.Amount > 1000)
            {
                Console.WriteLine("president handled the expense!");
            }
        }
    }
}
