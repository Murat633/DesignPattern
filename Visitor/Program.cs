using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Visitor
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Manager murat = new Manager() { Name="Murat",Salary = 5000};
            Manager ahmet = new Manager() { Name="Ahmet",Salary = 5000};
            Worker salih = new Worker() { Name= "Salih", Salary = 5000};
            Worker derin = new Worker() { Name= "Derin", Salary = 5000};

            murat.Subordinates.Add(ahmet);
            ahmet.Subordinates.Add(derin);
            ahmet.Subordinates.Add(salih);

            OrganisationalStructure organisationalStructure = new OrganisationalStructure(murat);
            VisitorBase visitor = new PayriseVisitor();
            VisitorBase visitor2 = new PayrolVisitor();

            organisationalStructure.Accept(visitor);
            organisationalStructure.Accept(visitor2);

            Console.ReadLine();
        } 
    }

    class OrganisationalStructure
    {
        public EmployeeBase _employee;
        public OrganisationalStructure(EmployeeBase firstEmployee)
        {
            _employee = firstEmployee;
        }

        public void Accept(VisitorBase visitor)
        {
            _employee.Accept(visitor);
        }
    }

    abstract class EmployeeBase
    {
        public abstract void Accept(VisitorBase visitor);
        public abstract string Name { get; set; }
        public abstract decimal Salary { get; set; }
    }

    class Manager : EmployeeBase
    {
        public Manager()
        {
            Subordinates = new List<EmployeeBase>();
        }
        public List<EmployeeBase> Subordinates { get; set; }
        public override string Name { get; set; }
        public override decimal Salary { get ; set; }

        public override void Accept(VisitorBase visitor)
        {
            visitor.Visit(this);

            foreach(var employee in Subordinates)
            {
                employee.Accept(visitor);
            }
        }
    }

    class Worker : EmployeeBase
    {
        public override string Name { get; set; }
        public override decimal Salary { get; set; }
        public override void Accept(VisitorBase visitor)
        {
            visitor.Visit(this);
        }
    }

    abstract class VisitorBase
    {
        public abstract void Visit(Worker worker);
        public abstract void Visit(Manager manager);
    }

    class PayrolVisitor : VisitorBase
    {
        public override void Visit(Worker worker)
        {
            Console.WriteLine("{0} paid {1}",worker.Name,worker.Salary);
        }

        public override void Visit(Manager manager)
        {
            Console.WriteLine("{0} paid {1}",manager.Name,manager.Salary);
        }
    }

    class PayriseVisitor : VisitorBase
    {
        public override void Visit(Worker worker)
        {
            Console.WriteLine("{0} Salary increased {1}", worker.Name,worker.Salary);
        }

        public override void Visit(Manager manager)
        {
            Console.WriteLine("{0} Salary increased {1}", manager.Name, manager.Salary);
        }
    }
}
