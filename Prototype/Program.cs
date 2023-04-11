using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prototype
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Customer customer1 = new Customer() { City = "Şanlıurfa", FirstName = "Murat", LastName = "Akyol" };
            
            var customerClone = (Customer)customer1.Clone();
            customerClone.FirstName = "Ahmet";
            
            Console.WriteLine(customer1.FirstName);
            Console.WriteLine(customerClone.FirstName);

            Console.ReadLine();
        }
    }

    public abstract class Person
    {
        public abstract Person Clone();
        public int Id { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
    }

    public class Customer : Person
    {
        public string City { get; set; }

        public override Person Clone()
        {
            return (Person)MemberwiseClone();
        }
    }
    public class Employee : Person
    {
        public string City { get; set; }

        public override Person Clone()
        {
            return (Person)MemberwiseClone();
        }
    }


}
