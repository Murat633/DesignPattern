using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Composite
{
    public class Program
    {
        static void Main(string[] args)
        {
            Employee murat = new Employee() { Name = "Murat Akyol" };
            Employee ahmet = new Employee() { Name = "Ahmet Akyol" };
            Employee derin = new Employee() { Name = "Derin Akyol" };
            Employee ali = new Employee() { Name = "Ali Akyol" };
            Employee salih = new Employee() { Name = "Salih Akyol" };

            murat.AddSubordinate(ahmet);
            murat.AddSubordinate(derin);
            derin.AddSubordinate(ali);
            ahmet.AddSubordinate(salih);

            Console.WriteLine(murat.Name);
            foreach (Employee manager in murat)
            {
                Console.WriteLine("  -{0}",manager.Name);
                foreach(IPerson employee in manager)
                {
                    Console.WriteLine("     -{0}",employee.Name);
                }
            }

            Console.ReadLine();

        }
    }

    interface IPerson
    {
        string Name { get; set; }
    }

    class Employee : IPerson,IEnumerable<IPerson>
    {
        List<IPerson> _suboridinates = new List<IPerson>();

        public void AddSubordinate(IPerson person)
        {
            _suboridinates.Add(person);
        }

        public void RemoveSubordinate(IPerson person)
        {
            _suboridinates.Remove(person);
        }

        public IPerson GetSubordinate(int index)
        {
            return _suboridinates[index];
        }

        public string Name { get; set; }

        public IEnumerator<IPerson> GetEnumerator()
        {
            foreach(var subordinate in _suboridinates)
            {
                yield return subordinate;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
